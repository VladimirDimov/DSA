//A text file students.txt holds information about students and their courses in the following format:
//Using SortedDictionary<K,T> print the courses in alphabetical order and for each of them prints the students ordered by family and then by name:

//Kiril  | Ivanov   | C#
//Stefka | Nikolova | SQL
//Stela  | Mineva   | Java
//Milena | Petrova  | C#
//Ivan   | Grigorov | C#
//Ivan   | Kolev    | SQL

//C#: Ivan Grigorov, Kiril Ivanov, Milena Petrova
//Java: Stela Mineva
//SQL: Ivan Kolev, Stefka Nikolova
namespace SortedDictionary
{
    using System;
    using System.IO;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            var path = "../../input/input.txt";

            var courses = GetCoursesFromFile(path);
            Console.WriteLine(courses.ToString());
        }

        private static Courses GetCoursesFromFile(string path)
        {
            var reader = new StreamReader(path);
            var courses = new Courses();

            while (!reader.EndOfStream)
            {
                var lineParams = reader.ReadLine().Split('|').Select(x => x.Trim()).ToList();
                var courseName = lineParams[2];
                var student = new Student(lineParams[0], lineParams[1]);

                courses.AddStudent(courseName, student);
            }

            return courses;
        }
    }
}
