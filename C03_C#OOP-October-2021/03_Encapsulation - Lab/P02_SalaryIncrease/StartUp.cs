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
                decimal salary = decimal.Parse(personArguments[3]);

                var person = new Person(firstName, lastName, age, salary);
                people.Add(person);
            }

            var parcentage = decimal.Parse(Console.ReadLine());
            people.ForEach(p => p.IncreaseSalary(parcentage));
            people.ForEach(p => Console.WriteLine(p.ToString()));
        }
    }
}
