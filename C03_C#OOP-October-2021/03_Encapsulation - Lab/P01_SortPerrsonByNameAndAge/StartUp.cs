namespace PersonsInfo
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            var people = new List<Person>();
            var lines = int.Parse(Console.ReadLine());
            for (int i = 0; i < lines; i++)
            {
                var personArguments = Console.ReadLine()
                    .Split()
                    .ToArray();

                string firstName = personArguments[0];
                string lastName = personArguments[1];
                int age = int.Parse(personArguments[2]);
                var person = new Person(firstName, lastName, age);
                people.Add(person);
            }

            people.OrderBy(p => p.FirstName)
                  .ThenBy(p => p.Age)
                  .ToList()
                  .ForEach(p => Console.WriteLine(p.ToString()));

        }
    }
}
