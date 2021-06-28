namespace P04_Students
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using P04_Students.Models;

    public class StartUp
    {
        const string COMMAND_TO_STOP = "end";

        public static void Main()
        {
            List<Student> allStudents = new List<Student>();

            while (true)
            {
                string[] arguments = Console.ReadLine().Split(" ");

                bool isStopCommand = arguments[0] == COMMAND_TO_STOP;
                if (isStopCommand)
                {
                    break;
                }

                string firstName = arguments[0];
                string lastName = arguments[1];
                byte age = byte.Parse(arguments[2]);
                string homeTown = arguments[3];

                Student student = new Student(firstName, lastName, age, homeTown);
                allStudents.Add(student);
            }

            string cityFillter = Console.ReadLine();

            PrintResult(allStudents, cityFillter);
        }

        private static void PrintResult(List<Student> allStudents, string cityFillter)
        {
            List<Student> filtedStudents = allStudents
                .Where(x => x.HomeTown == cityFillter)
                .ToList();

            Console.WriteLine(string.Join(Environment.NewLine, filtedStudents));
        }
    }
}
