namespace ExplicitInterfaces
{
    using System;
    using System.Collections.Generic;

    using ExplicitInterfaces.Models;
    using ExplicitInterfaces.Models.Interfaces;

    public class StartUp
    {
        private const string COMMAND_TO_END_READ_ARGUMENTS = "End";

        public static void Main()
        {
            var citizens = new List<Citizen>();

            var input = Console.ReadLine();
            while (input != COMMAND_TO_END_READ_ARGUMENTS)
            {
                var cmdArguments = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                var name = cmdArguments[0];
                var country = cmdArguments[1];
                var age = int.Parse(cmdArguments[2]);

                var citizen = new Citizen(name, country, age);
                citizens.Add(citizen);

                input = Console.ReadLine();
            }

            PrintOutput(citizens);
        }

        private static void PrintOutput(List<Citizen> citizens)
        {
            foreach (var citizen in citizens)
            {
                Console.WriteLine(citizen.GetName());
                var citizenAsResident = (IResident)citizen;
                Console.WriteLine(citizenAsResident.GetName());
            }
        }
    }
}
