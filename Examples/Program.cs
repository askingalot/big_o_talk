using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using CsvHelper;

namespace Examples {
    class Program {
        static void Main (string[] args) { 
            var schools = GetSchools();

            foreach (var school in schools) {
                Console.WriteLine(school);
            }
        }

        private int CalculateSimilarityScore(School a, School b) {
            var score = 0;
            if (a.SchoolLevel == b.SchoolLevel) {
                score += 2;
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

        public int TotalSchools => Male + Female;

        public override string ToString () {
            return $"{SchoolID}, {SchoolName}, {SchoolLevel}, {Male}, {Female}, {TotalSchools}";
        }
    }
}