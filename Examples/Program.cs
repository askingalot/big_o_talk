using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using CsvHelper;

namespace Examples {
    class Program {
        static void Main (string[] args) { 
            var schools = GetSchools();

            // O(1)
            var score = CalculateSimilarityScore(schools[3], schools[10]);

            // O(n)
            var twoRiversMiddle = GetByName(schools, "Two Rivers Middle");
            Console.WriteLine(twoRiversMiddle);

            // O(log n)
            var sorted = schools.OrderBy(s => s.SchoolName).ToList();
            var percyPriestElementary = GetByNameSorted(sorted, "Percy Priest Elementary");
            Console.WriteLine(percyPriestElementary);


            var first = schools.First();
            Console.WriteLine($"Computing Similarity to {first}");
            foreach (var school in schools.Take(10)) {
                Console.WriteLine($"{school}: " +
                    CalculateSimilarityScore(first, school)
                );
            }
        }

        private static School GetByName(List<School> schools, string name) {
            School found = null;
            foreach (var school in schools) {
                if (school.SchoolName == name) {
                    found = school;
                }
            }
            return found;
        }

        private static School GetByNameSorted(List<School> schools, string name) {
            School found = null;
            var start = 0;
            var end = schools.Count - 1;
            while (start < end) {
                var mid = end - start;
                if (schools[mid].SchoolName == name) {
                    found = schools[mid];
                    break;
                } else if (schools[mid].SchoolName.CompareTo(name) < 0) {
                    start = mid + 1;
                } else {
                    end = mid - 1;
                }
            }
            return found;
        }

        private static int CalculateSimilarityScore(School a, School b) {
            var score = 0;

            // Schools with the same level are similar
            if (a.SchoolLevel == b.SchoolLevel) {
                score += 2;
            }

            // Schools with similar numbers of students are similar
            var (minCount, maxCount) = a.TotalCount < b.TotalCount
                ? (a.TotalCount, b.TotalCount)
                : (b.TotalCount, a.TotalCount);
            if (maxCount * 0.75 < minCount) {
                score += 1;
            }

            // Schools with similar numbers of Limited English Proficiency are similar
            var (minLEP, maxLEP) = a.LimitedEnglishProficiencyCount < b.LimitedEnglishProficiencyCount
                ? (a.TotalCount, b.TotalCount)
                : (b.TotalCount, a.TotalCount);
            if (maxLEP * 0.75 < minLEP) {
                score += 1;
            }

            // Schools in the same zip code are similar
            if (a.ZipCode == b.ZipCode) {
                score += 1;
            }

            return score;
        }

        private static List<School> GetSchools () {
            using (var csvReader = new CsvReader (new StreamReader ("../Metro_Nashville_Public_Schools_Enrollment_and_Demographics-1.csv"))) {
                csvReader.Configuration.PrepareHeaderForMatch = header => header.Replace (" ", "");
                return csvReader.GetRecords<School>().ToList();
            }
        }
    }

    public class School {
        public int SchoolID { get; set; }
        public string SchoolName { get; set; }
        public string SchoolLevel { get; set; }
        public int Male { get; set; }
        public int Female { get; set; }
        public string LimitedEnglishProficiency { get; set;}
        public int LimitedEnglishProficiencyCount {
            get {
                var count = 0;
                int.TryParse(LimitedEnglishProficiency, out count);
                return count;
            }
        }

        public int TotalCount => Male + Female;
        public string ZipCode { get; set; }


        public override string ToString () {
            return $"{SchoolID}, {SchoolName}, {SchoolLevel}, {TotalCount}, {ZipCode}";
        }
    }
}