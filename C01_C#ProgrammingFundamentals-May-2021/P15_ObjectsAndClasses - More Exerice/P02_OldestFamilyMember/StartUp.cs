namespace P02_OldestFamilyMember
{
    using System;

    using P02_OldestFamilyMember.Models;

    public class StartUp
    {
        public static void Main()
        {
            int familyCount = int.Parse(Console.ReadLine());

            Family family = new Family();

            for (int i = 0; i < familyCount; i++)
            {
                string[] arguments = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string name = arguments[0];
                byte age = byte.Parse(arguments[1]);

                Person person = new Person(name, age);
                family.Person.Add(person);
            }

            family.PrintOldestMember();
        }
    }
}
