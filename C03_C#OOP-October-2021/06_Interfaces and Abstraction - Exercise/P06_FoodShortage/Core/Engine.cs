namespace FoodShortage.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using FoodShortage.Models;

    public class Engine
    {
        private const string COMMAND_TO_END_READ_ARGUMENTS = "End";

        private readonly HashSet<Person> people;

        public Engine()
        {
            this.people = new HashSet<Person>();
        }

        public void Run()
        {
            this.CreatePeple();
            this.ExecuteCommands();
            this.PrintOutput();
        }

        private void CreatePeple()
        {
            var peopleCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < peopleCount; i++)
            {
                var arguments = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (arguments.Length == 4)
                {
                    this.AddCitizen(arguments);
                }
                else
                {
                    this.AddRebel(arguments);
                }
            }
        }

        private void AddRebel(string[] arguments)
        {
            var name = arguments[0];
            var age = int.Parse(arguments[1]);
            var group = arguments[2];

            var rebel = new Rebel(name, age, group);
            this.people.Add(rebel);
        }

        private void AddCitizen(string[] arguments)
        {
            var name = arguments[0];
            var age = int.Parse(arguments[1]);
            var id = arguments[2];
            var birthDate = arguments[3];

            var citizen = new Citizen(name, age, id, birthDate);
            this.people.Add(citizen);
        }

        private void ExecuteCommands()
        {
            var name = Console.ReadLine();
            while (name != COMMAND_TO_END_READ_ARGUMENTS)
            {
                var person = this.people.Where(x => x.Name == name).SingleOrDefault();

                if (person != null)
                {
                    person.BuyFood();
                }

                name = Console.ReadLine();
            }
        }

        private void PrintOutput()
        {
            var sum = 0;
            foreach (var person in this.people)
            {
                sum += person.Food;
            }
            Console.WriteLine(sum);
        }
    }
}
