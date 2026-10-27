using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqOvningar
{
    public class Student
    {
        public int Id { get; set; }
        public string Namn { get; set; } = "";
        public int Alder { get; set; }
        public string Klass { get; set; } = "";
        public int Poang { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            // Exempeldata
            List<Student> studenter = new List<Student>
             {
             new Student { Id = 1, Namn = "Anna", Alder = 19, Klass = "A", Poang = 85 },
             new Student { Id = 2, Namn = "Bertil", Alder = 22, Klass = "B", Poang = 72 },
             new Student { Id = 3, Namn = "Cecilia", Alder = 20, Klass = "A", Poang = 91 },
             new Student { Id = 4, Namn = "David", Alder = 24, Klass = "C", Poang = 64 },
             new Student { Id = 5, Namn = "Eva", Alder = 19, Klass = "B", Poang = 85 },
             new Student { Id = 6, Namn = "Felix", Alder = 21, Klass = "A", Poang = 77 },
             new Student { Id = 7, Namn = "Gustav", Alder = 23, Klass = "C", Poang = 58 },
             new Student { Id = 8, Namn = "Hanna", Alder = 20, Klass = "B", Poang = 95 }
             };

            Console.WriteLine("LINQ-ÖVNINGAR MED STUDENTER\n");   

        }
    

        //Hämta alla student som är äldre än 20.
        private List<Student> GetOlderThan20(List<Student> students)
        {

            return students.Where(s => s.Alder > 20).ToList();
        
        }

        //Hämta alla studenter som har mer än 80 poäng.
        private List<Student> GetScoreGreaterThan80(List<Student> students)
        {

            return students.Where(s => s.Poang > 80).ToList();

        }

        //Visa bara namnen på alla student.
        private void PrintNamesOfStudents(List<Student> students)
        {
            foreach(string namn in students.Select(s=> s.Namn))
            {
                Console.WriteLine(namn);
            }
        }

        //Visa namn och poäng i en ny anonym typ.
        private void ShowNameAndScore(List<Student> students)
        {
            foreach (var student in students.Select(s => new { s.Namn, s.Poang }))
            {
                Console.WriteLine($"{student.Namn} {student.Poang}");
            }
            
        }

        //Sortera studenter efter ålder.
        private List<Student> SortByAge(List<Student> students)
        {

            return students.OrderBy(s => s.Alder).ToList();

        }

        //Sortera studenter efter poäng, högst först.
        private List<Student> SortByScoreDescending(List<Student> students)
        {

            return students.OrderByDescending(s => s.Poang).ToList();

        }

        //Räknar hur många studenter som finns.
        private int CountStudents(List<Student> students)
        {
            return students.Count();

        }

        //Räkna hur många som går i klass A
        private int CountStudentsInClassA(List<Student> students)
        {
            return students.Count(s => s.Klass == "A");

        }

        //Ta ut de tre första studenterna.
        private List<Student> GetThreeFirstStudents(List<Student> students)
        {

            return students.Skip(3).ToList();

        }

        //Ta ut de två bästa poängen efter sortering.
        private List<Student> GetTwobestScores(List<Student> students)
        {

            return students.OrderByDescending(s => s.Poang).Skip(2).ToList();

        }

        //Visa alla unika classnamn.
        private void ShowUniqueClassNames(List<Student> students)
        {
            var UniqueClassNames = students.Select(s => s.Klass).Distinct();
            foreach(var uniqueClass in UniqueClassNames)
            {
                Console.WriteLine(uniqueClass);
            }          

        }

        //Visa alla unika åldrar.

        private void ShowUniqueAges(List<Student> students)
        {
            var UniqueAges = students.Select(s => s.Alder).Distinct();
            foreach (var uniqueAge in UniqueAges)
            {
                Console.WriteLine(uniqueAge);
            }

        }
    }


}