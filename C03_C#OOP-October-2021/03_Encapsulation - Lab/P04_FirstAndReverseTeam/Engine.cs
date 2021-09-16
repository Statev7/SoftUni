namespace PersonsInfo
{
    using System;
    using System.Linq;

    public class Engine
    {
        public void Run()
        {
            var team = new Team("SoftUni");
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

                try
                {
                    var person = new Person(firstName, lastName, age, salary);
                    team.AddPlayer(person);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            PrintOutput(team);
        }

        private static void PrintOutput(Team team)
        {
            Console.WriteLine($"First team has {team.FirstTeam.Count} players.");
            Console.WriteLine($"Reverse team has {team.ReserveTeam.Count} players.");
        }
    }
}
