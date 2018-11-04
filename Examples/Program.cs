using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using CsvHelper;

namespace Examples {
    class Program {

        static void Main(string[] args) {
            PrintRectangleStats(2, 4);
            
            "foo".ToUpper();

            var list = new List<int> { 1, 22, 8, 43, 7, 8, 1, 22 };
            var sorted = list.OrderBy(n => n).ToList();

            if (ContainsNumber(list, 7)) {
                Console.WriteLine("it's in there!");
            }

            if (ContainsNumberBinarySearch(sorted, 22)) {
                Console.WriteLine("it's in there!");
            }

            Console.WriteLine(string.Join(", ", FindDuplicates(list)));

            var perms = Permutations(new List<int> {1, 2, 3, 4});
            foreach (var perm in perms) {
                Console.WriteLine(string.Join(", ", perm));
            }
            Console.WriteLine(perms.Count);


            var bins = AllBinaryNumbers(5);
            Console.WriteLine(string.Join(", ", bins));
        }

        public static List<string> AllBinaryNumbers(int numDigits) {
            var result = new List<string>();
            var num = 0;

            for (var i=0; i<Math.Pow(2, numDigits); i++) {
                result.Add(
                    Convert.ToString(num, 2).PadLeft(numDigits, '0')
                );
                num++;
            }
            return result;
        }

        public static List<List<int>> Permutations(List<int> list) {
            if (list.Count == 1) {
                return new List<List<int>> { list };
            }

            var result = new List<List<int>>();
            for (var i=0; i<list.Count; i++) {
                var listWithoutI = list.Where((_, idx) => idx != i).ToList();

                var permsWithoutI = Permutations(listWithoutI);

                result.AddRange(
                    permsWithoutI.Select(p => {
                        p.Insert(0, list[i]);
                        return p;
                    })
                );
            }
            return result;
        }

        public static List<int> FindDuplicates(List<int> list) {
            var result = new List<int>();
            for (var i=0; i<list.Count; i++) {
                for  (var j=i+1; j<list.Count; j++) {
                    if (i == j) continue;
                    if (list[i] == list[j]) {
                        result.Add(list[i]);
                    }
                }
            }
            return result;
        }

        public static bool ContainsNumber(List<int> list, int number) {
            foreach (var n in list) {
                if (n == number) {
                    return true;
                }
            }
            return false;
        }

        public static bool ContainsNumberBinarySearch(List<int> list, int number) {
            return innerSearch(0, list.Count - 1);

            bool innerSearch(int first, int last) {
                if (first > last) {
                    return false;
                }

                var mid = (first + last) / 2;
                if (number == list[mid]) {
                    return true;
                }
                if (number < list[mid]) {
                    return innerSearch(first, mid - 1);
                }
                return innerSearch(mid + 1, last);
            }
        }


        public void PrintList(List<string> strings) {
            foreach(var str in strings) {
                var fromTheRoofTops = str.ToUpper();
                fromTheRoofTops = fromTheRoofTops + "!!!!";
                Console.WriteLine(fromTheRoofTops);
            }
        }

        static int SumThree(int a, int b, int c) {
            int sum;
            sum = a = b;
            sum += c;
            return sum;
        }

        static void PrintRectangleStats(int length, int width) {
            var area = length * width;
            var perimeter = (length + width) * 2;
            var isSquare = length == width;

            Console.WriteLine("The area is " + area);
            Console.WriteLine("The perimeter is " + perimeter);

            if (isSquare) {
                Console.WriteLine("It is a square");
            } else {
                Console.WriteLine("It is not a square");
            }
        }

        static void PrintSquares(List<int> numbers) {
            foreach (var num in numbers) {
                var square = num * num;
                Console.WriteLine("The square of " + num + " is " + square);
            }
        }


        static void _Main (string[] args) { 
            var schools = GetSchools();

            /*********************************************************************/
            // O(1)
            var score3vs10 = CalculateSimilarityScore(schools[3], schools[10]);
            Console.WriteLine(score3vs10);

            /*********************************************************************/
            // O(n)
            var twoRiversMiddle = SearchByName(schools, "Two Rivers Middle");
            Console.WriteLine(twoRiversMiddle);

            /*********************************************************************/
            // O(log n)
            var sorted = schools.OrderBy(s => s.SchoolName).ToList();
            var percyPriestElementary = BinarySearchByName(sorted, "Percy Priest Elementary");
            Console.WriteLine(percyPriestElementary);

            /*********************************************************************/
            // O(n + log n)
            var (mcGavockHigh, mcGavockHighResults) = FindAndScore(sorted, "McGavock High");
            Console.WriteLine("---------------------");
            Console.WriteLine(mcGavockHigh);
            foreach (var (school, score) in mcGavockHighResults) {
                Console.WriteLine($"{school} -> {score}");
            }

            /*********************************************************************/
            // O(n^2)
            var allScoreResults = ScoreAll(schools);
            foreach(var result in allScoreResults) {
                //Console.WriteLine("---------------------");

                var (schoolA, schoolB, score) = result;
                //Console.WriteLine($"Score({schoolA}, {schoolB}) -> {score}");
            }


            /*********************************************************************/
            /* 
            var first = schools.First();
            Console.WriteLine($"Computing Similarity to {first}");
            foreach (var school in schools) {
                Console.WriteLine($"{school}: " +
                    CalculateSimilarityScore(first, school)
                );
            }
            */
        }

        private static School SearchByName(List<School> schools, string name) {
            School found = null;
            foreach (var school in schools) {
                if (school.SchoolName == name) {
                    found = school;
                }
            }
            return found;
        }

        private static School BinarySearchByName(List<School> sortedSchools, string name) {
            School found = null;
            var start = 0;
            var end = sortedSchools.Count - 1;
            while (start < end) {
                var mid = end - start;
                if (sortedSchools[mid].SchoolName == name) {
                    found = sortedSchools[mid];
                    break;
                } else if (sortedSchools[mid].SchoolName.CompareTo(name) < 0) {
                    start = mid + 1;
                } else {
                    end = mid - 1;
                }
            }
            return found;
        }

        private static (School, List<(School, int)>) FindAndScore(List<School> sortedSchools, string name) {
            var foundSchool = BinarySearchByName(sortedSchools, name);
            var results = sortedSchools.Select(s => 
                (s, CalculateSimilarityScore(foundSchool, s))
            ).ToList();
            return (foundSchool, results);
        }

        private static List<(School, School, int)> ScoreAll(List<School> schools) {
            var results = new List<(School, School, int)>();
            foreach(var schoolA in schools) {
                foreach(var schoolB in schools) {
                    results.Add(
                        (schoolA, schoolB, CalculateSimilarityScore(schoolA, schoolB))
                    );
                }
            }
            return results;
        }



        private static int CalculateSimilarityScore(School a, School b) {
            var score = 0;

            // Schools with the same level are similar
            if (a.SchoolLevel == b.SchoolLevel) {
                score += 2;
            }

            // Schools in the same zip code are similar
            if (a.ZipCode == b.ZipCode) {
                score += 1;
            }

            // Schools with similar numbers of students are similar
            var (minCount, maxCount) = a.TotalCount < b.TotalCount
                ? (a.TotalCount, b.TotalCount)
                : (b.TotalCount, a.TotalCount);
            if (maxCount * 0.75 < minCount) {
                score += 1;
            }

            // Schools with similar percentage of Limited English Proficiency are similar
            var schoolA_LEPPercent = (int) (a.LEPCount / (a.TotalCount * 1.0) * 100);
            var schoolB_LEPPercent = (int) (b.LEPCount / (b.TotalCount * 1.0) * 100);
            var (minLEP, maxLEP) = schoolA_LEPPercent < schoolB_LEPPercent
                ? (schoolA_LEPPercent, schoolB_LEPPercent)
                : (schoolB_LEPPercent, schoolA_LEPPercent);
            if (maxLEP * 0.75 < minLEP) {
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

    class School {
        public int SchoolID { get; set; }
        public string SchoolName { get; set; }

        public string SchoolLevel { get; set; }

        public int Male { get; set; }
        public int Female { get; set; }
        public int TotalCount => Male + Female;

        public string LimitedEnglishProficiency { get; set;}
        public int LEPCount {
            get {
                var count = 0;
                int.TryParse(LimitedEnglishProficiency, out count);
                return count;
            }
        }

        public string ZipCode { get; set; }

        public override string ToString () {
            return $"School({SchoolID}, {SchoolName}, {SchoolLevel}, {ZipCode}, {TotalCount}, {LEPCount})";
        }
    }
}