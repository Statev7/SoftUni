namespace P03_OldestFamilyMember
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            int peopleCount = int.Parse(Console.ReadLine());
            Family family = new Family();

            for (int i = 0; i < peopleCount; i++)
            {
                var personArgs = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string name = personArgs[0];
                int age = int.Parse(personArgs[1]);

                Person person = new Person(name, age);
                family.AddMember(person);
            }

            Console.WriteLine(family.GetOldestMember());
        }
    }
}
