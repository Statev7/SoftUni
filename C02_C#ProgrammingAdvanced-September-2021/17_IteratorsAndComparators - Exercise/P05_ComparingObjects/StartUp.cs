namespace P05_ComparingObjects
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        private const string COMMAND_TO_STOP_READ_PERSON_INFORMATION = "END";

        public static void Main()
        {
            List<Person> people = new List<Person>();

            var personArg = Console.ReadLine();
            while (personArg != COMMAND_TO_STOP_READ_PERSON_INFORMATION)
            {
                var splited = personArg
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string name = splited[0];
                int age = int.Parse(splited[1]);
                string town = splited[2];

                var person = new Person(name, age, town);
                people.Add(person);

                personArg = Console.ReadLine();
            }

            int personToComapreIndex = int.Parse(Console.ReadLine());
            var personToCompare = people[personToComapreIndex - 1];
            people.Remove(personToCompare);
            int count = 1;

            foreach (var person in people)
            {
                if (personToCompare.CompareTo(person) == 0)
                {
                    count++;
                }
            }

            var result = count > 1 ? $"{count} {(people.Count + 1) - count} {people.Count + 1}" : "No matches";
            Console.WriteLine(result);
        }
    }
}
