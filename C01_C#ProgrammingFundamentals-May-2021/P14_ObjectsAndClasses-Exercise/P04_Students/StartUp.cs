namespace P04_Students
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using P04_Students.Models;

    public class StartUp
    {
        public static void Main()
        {
            int studentsCount = int.Parse(Console.ReadLine());

            List<Student> allStudents = new List<Student>();

            for (int i = 0; i < studentsCount; i++)
            {
                string[] arguments = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string firstName = arguments[0];
                string lastName = arguments[1];
                double grade = double.Parse(arguments[2]);

                Student student = new Student(firstName, lastName, grade);

                allStudents.Add(student);
            }

            allStudents = OrderByDescendingTheStudents(allStudents);

            PrintResult(allStudents);
        }

        private static List<Student> OrderByDescendingTheStudents(List<Student> allStudents)
        {
            allStudents = allStudents
                            .OrderByDescending(x => x.Grade)
                            .ToList();
            return allStudents;
        }

        private static void PrintResult(List<Student> allStudents)
        {
            Console.WriteLine(string.Join(Environment.NewLine, allStudents));
        }
    }
}
