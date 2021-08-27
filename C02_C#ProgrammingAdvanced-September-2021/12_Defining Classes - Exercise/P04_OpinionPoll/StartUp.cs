namespace P04_OpinionPoll
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            List<Person> people = new List<Person>();

            int peopleCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < peopleCount; i++)
            {
                var peopleArg = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string name = peopleArg[0];
                int age = int.Parse(peopleArg[1]);
                Person person = new Person(name, age);
                people.Add(person);
            }

            foreach (var person in people
                .Where(x => x.Age > 30)
                .OrderBy(x => x.Name))
            {
                Console.WriteLine(person);
            }
        }
    }
}
