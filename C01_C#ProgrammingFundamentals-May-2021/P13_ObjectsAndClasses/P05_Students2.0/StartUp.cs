namespace P05_Students2._0
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using P05_Students2._0.Models;

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
                string city = arguments[3];
                StudentUniqueName(allStudents, firstName, lastName, age, city);
            }

            string cityFilter = Console.ReadLine();
            allStudents = FilterStudents(allStudents, cityFilter);
            PrintResult(allStudents);
        }

        private static void StudentUniqueName(List<Student> allStudents, string firstName, string lastName, byte age, string city)
        {
            bool isAlreadyExist = false;

            Student student = new Student(firstName, lastName, age, city);
            if (allStudents.Count == 0)
            {
                allStudents.Add(student);
            }

            for (int index = 0; index < allStudents.Count; index++)
            {
                isAlreadyExist = firstName == allStudents[index].FirstName && lastName == allStudents[index].LastName;
                if (isAlreadyExist)
                {
                    allStudents[index].Age = age;
                    break;
                }
            }

            if (!isAlreadyExist)
            {
                allStudents.Add(student);
            }

        }

        private static List<Student> FilterStudents(List<Student> allStudents, string cityFilter)
        {
            allStudents = allStudents
                .Where(x => x.City == cityFilter)
                .ToList();
            return allStudents;
        }

        private static void PrintResult(List<Student> allStudents)
        {
            Console.WriteLine(string.Join(Environment.NewLine, allStudents));
        }
    }
}
