using System.Collections.Generic;

namespace Day04_StudentGradeTracker
{
    // CLASS — blueprint for a Student object
    class Student
    {
        // PROPERTIES — data the object holds
        public string Name { get; set; }
        public int Maths { get; set; }
        public int Science { get; set; }
        public int English { get; set; }

        // CONSTRUCTOR — runs when object is created
        public Student(string name, int maths, int science, int english)
        {
            Name = name;
            Maths = maths;
            Science = science;
            English = english;
        }

        // METHOD — belongs to the object, calculates average
        public double GetAverage()
        {
            return (Maths + Science + English) / 3.0;
        }

        // METHOD — returns grade based on average
        public string GetGrade()
        {
            double avg = GetAverage();
            if (avg >= 90) return "A+";
            if (avg >= 80) return "A";
            if (avg >= 70) return "B";
            if (avg >= 60) return "C";
            if (avg >= 50) return "D";
            return "F";
        }
    }

    class Program
    {
        static void Main()
        {
            // LIST — collection of Student objects
            List<Student> students = new List<Student>();

            Console.WriteLine("╔══════════════════════════════════╗");
            Console.WriteLine("║     STUDENT GRADE TRACKER        ║");
            Console.WriteLine("╚══════════════════════════════════╝");
            Console.WriteLine();

            // Input loop — add students
            while (true)
            {
                Console.Write("Enter Student Name (or 'done' to finish): ");
                string name = Console.ReadLine() ?? "";

                if (name.ToLower() == "done") break;

                Console.Write("Enter Maths marks (0-100): ");
                int maths = int.Parse(Console.ReadLine() ?? "0");

                Console.Write("Enter Science marks (0-100): ");
                int science = int.Parse(Console.ReadLine() ?? "0");

                Console.Write("Enter English marks (0-100): ");
                int english = int.Parse(Console.ReadLine() ?? "0");

                // Create a new Student OBJECT and add to list
                students.Add(new Student(name, maths, science, english));
                Console.WriteLine($"Student {name} is added!\n");
            }

            if (students.Count == 0)
            {
                Console.WriteLine("No students added. Exiting.");
                return;
            }

            // Display results table
            Console.WriteLine();
            Console.WriteLine("══════════════════════════════════════════════════════════");
            Console.WriteLine($"  {"Name",-15} {"Maths",6} {"Science",8} {"English",8} {"Avg",6} {"Grade",6}");
            Console.WriteLine("──────────────────────────────────────────────────────────");

            // FOREACH — loop through each student
            foreach (Student s in students)
            {
                Console.WriteLine($"  {s.Name,-15} {s.Maths,6} {s.Science,8} {s.English,8} {s.GetAverage(),6:N1} {s.GetGrade(),6}");
            }

            Console.WriteLine("══════════════════════════════════════════════════════════");

            // LINQ — query the list
            Console.WriteLine();
            Console.WriteLine("         CLASS STATISTICS (LINQ)");
            Console.WriteLine("──────────────────────────────────────────────────────────");
            Console.WriteLine($"  Class Average  : {students.Average(s => s.GetAverage()):N1}");
            Console.WriteLine($"  Highest Score  : {students.Max(s => s.GetAverage()):N1}");
            Console.WriteLine($"  Lowest Score   : {students.Min(s => s.GetAverage()):N1}");

            // LINQ OrderBy — top performer
            Student topper = students.OrderByDescending(s => s.GetAverage()).First();
            Console.WriteLine($"  Top Student    : {topper.Name} ({topper.GetAverage():N1})");

            // LINQ Where — students who failed
            List<Student> failed = students.Where(s => s.GetAverage() < 50).ToList();
            Console.WriteLine($"  Failed Students: {failed.Count}");

            if (failed.Count > 0)
            {
                foreach (Student f in failed)
                    Console.WriteLine($"    → {f.Name} ({f.GetAverage():N1})");
            }

            Console.WriteLine("══════════════════════════════════════════════════════════");
            Console.WriteLine();
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}