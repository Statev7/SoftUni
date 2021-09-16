namespace PersonsInfo
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Engine
    {
        private readonly List<Person> people;

        public Engine()
        {
            this.people = new List<Person>();
        }

        public void Run()
        {
            var lines = int.Parse(Console.ReadLine());
            for (int i = 0; i < lines; i++)
            {
                var personArguments = Console.ReadLine()
                    .Split()
                    .ToArray();

                string firstName = personArguments[0];
                string lastName = personArguments[1];
                int age = int.Parse(personArguments[2]);
                decimal salary = decimal.Parse(personArguments[3]);

                try
                {
                    var person = new Person(firstName, lastName, age, salary);
                    this.people.Add(person);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            PrintOutput(this.people);
        }

        private static void PrintOutput(List<Person> people)
        {
            foreach (var person in people)
            {
                Console.WriteLine(person);
            }
        }
    }
}
