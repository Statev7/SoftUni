namespace BirthdayCelebrations.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using BirthdayCelebrations.Models;
    using BirthdayCelebrations.Models.Interfaces;

    public class Engine
    {
        private const string COMMNAD_TO_END_READ_ARGUMENTS = "End";

        private readonly List<IBirthble> citizens;

        public Engine()
        {
            this.citizens = new List<IBirthble>();
        }

        public void Run()
        {
            this.ExecuteCommands();

            string filter = Console.ReadLine();
            this.PrintOutput(filter);
        }

        private void ExecuteCommands()
        {
            var input = Console.ReadLine();

            while (input != COMMNAD_TO_END_READ_ARGUMENTS)
            {
                var cmdArg = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                var type = cmdArg[0];

                switch (type)
                {
                    case "Citizen": this.AddCitizen(cmdArg); break;
                    case "Pet": this.AddPet(cmdArg); break;
                }

                input = Console.ReadLine();
            }
        }

        private void AddPet(string[] cmdArg)
        {
            var name = cmdArg[1];
            var birthDate = (cmdArg[2]);

            var pet = new Pet(name, birthDate);
            this.citizens.Add(pet);
        }

        private void AddCitizen(string[] cmdArg)
        {
            var name = cmdArg[1];
            var age = int.Parse(cmdArg[2]);
            var id = cmdArg[3];
            var birthDate = (cmdArg[4]);

            var citizen = new Citizens(name, age, id, birthDate);
            this.citizens.Add(citizen);
        }

        private void PrintOutput(string filter)
        {
            foreach (var citizen in this.citizens)
            {
                if (citizen.BirthDate.EndsWith(filter))
                {
                    Console.WriteLine(citizen.BirthDate);
                }
            }
        }
    }
}
