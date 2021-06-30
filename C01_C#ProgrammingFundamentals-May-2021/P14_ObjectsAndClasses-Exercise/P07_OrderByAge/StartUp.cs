namespace P07_OrderByAge
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using P07_OrderByAge.Models;

    public class StartUp
    {
        const string COMMAND_TO_STOP = "End";

        public static void Main()
        {
            List<Person> allPeoples = new List<Person>();

            while (true)
            {
                string[] arg = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                bool isStopCommand = arg[0] == COMMAND_TO_STOP;
                if (isStopCommand)
                {
                    break;
                }

                string name = arg[0];
                string id = arg[1];
                byte age = byte.Parse(arg[2]);

                Person person = new Person(name, id, age);
                allPeoples.Add(person);
            }

            allPeoples = allPeoples
                .OrderBy(x => x.Age)
                .ToList();

            PrintAllPeoples(allPeoples);
        }

        private static void PrintAllPeoples(List<Person> allPeoples)
        {
            foreach (var person in allPeoples)
            {
                Console.WriteLine(person);
            }
        }
    }
}
