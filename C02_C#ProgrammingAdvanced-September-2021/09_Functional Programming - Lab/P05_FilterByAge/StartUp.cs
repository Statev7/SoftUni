namespace P05_FilterByAge
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        public static void Main()
        {
            int peopleCount = int.Parse(Console.ReadLine());

            List<Person> people = new List<Person>();

            for (int i = 0; i < peopleCount; i++)
            {
                var personDate = Console.ReadLine()
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries);

                string personName = personDate[0];
                byte personAge = byte.Parse(personDate[1]);

                Person person = new Person(personName, personAge);
                people.Add(person);
            }

            string conditionFilter = Console.ReadLine();
            byte ageFilter = byte.Parse(Console.ReadLine());
            string format = Console.ReadLine();

            Func<Person, bool> ageFunc = GetAge(conditionFilter, ageFilter);
            Action<Person> formatFunc = Print(format);

            foreach (var person in people)
            {
                if (ageFunc(person))
                {
                    formatFunc(person);
                }
            }
        }

        private static Func<Person, bool> GetAge(string conditionFilter, byte ageFilter)
        {
            switch (conditionFilter)
            {
                case "older": return p => p.Age >= ageFilter;
                case "younger": return p => p.Age < ageFilter;
                default: return null;
            }
        }

        private static Action<Person> Print(string format)
        {
            switch (format)
            {
                case "name age": return p => Console.WriteLine($"{p.Name} - {p.Age}");
                case "name": return p => Console.WriteLine($"{p.Name}");
                case "age": return p => Console.WriteLine($"{p.Age}");
                default: return null;
            }
        }
    }
}
