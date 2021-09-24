namespace MilitaryElite.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using MilitaryElite.Models.Soldiers;
    using MilitaryElite.Models.Soldiers.PrivateSoldier;
    using MilitaryElite.Models.Soldiers.PrivateSoldier.LieutenantGeneral;
    using MilitaryElite.Models.Soldiers.PrivateSoldiers.SpecialisedSoldiers.Commandos;
    using MilitaryElite.Models.Soldiers.PrivateSoldiers.SpecialisedSoldiers.Engineers;
    using MilitaryElite.Models.Soldiers.Spys;

    public class Engine
    {
        private const string COMMAND_TO_END_READ_ARGUMENTS = "End";

        private readonly List<Soldier> soldiers;

        public Engine()
        {
            this.soldiers = new List<Soldier>();
        }

        public void Run()
        {
            this.ExecuteCommands();
            this.PrintOutput();
        }

        private void ExecuteCommands()
        {
            var input = Console.ReadLine();
            while (input != COMMAND_TO_END_READ_ARGUMENTS)
            {
                var cmdArg = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                var command = cmdArg[0];

                var id = int.Parse(cmdArg[1]);
                var firstName = cmdArg[2];
                var lastName = cmdArg[3];

                switch (command)
                {
                    case "Private": this.AddPrivateSoldier(cmdArg, id, firstName, lastName); break;
                    case "LieutenantGeneral": this.AddLieutenantGeneral(cmdArg, id, firstName, lastName); break;
                    case "Engineer": this.AddEngineer(cmdArg, id, firstName, lastName); break;
                    case "Commando": this.AddCommando(cmdArg, id, firstName, lastName); break;
                    case "Spy": this.AddSpy(cmdArg, id, firstName, lastName); break;
                }

                input = Console.ReadLine();
            }
        }

        private void AddSpy(string[] cmdArg, int id, string firstName, string lastName)
        {
            var codeNumber = int.Parse(cmdArg[4]);
            var spy = new Spy(id, firstName, lastName, codeNumber);

            this.soldiers.Add(spy);
        }

        private void AddCommando(string[] cmdArg, int id, string firstName, string lastName)
        {
            var salary = decimal.Parse(cmdArg[4]);
            var corps = cmdArg[5];
            if (corps == "Airforces" || corps == "Marines")
            {
                var commando = new Commando(id, firstName, lastName, salary, corps);
                if (cmdArg.Length >= 6)
                {
                    for (int i = 6; i < cmdArg.Length; i += 2)
                    {
                        var missionCodeName = cmdArg[i];
                        var state = cmdArg[i + 1];

                        if (state == "inProgress" || state == "Finished")
                        {
                            var mission = new Mission(missionCodeName, state);
                            commando.AddMission(mission);
                        }
                    }
                }

                this.soldiers.Add(commando);
            }
        }

        private void AddEngineer(string[] cmdArg, int id, string firstName, string lastName)
        {
            var salary = decimal.Parse(cmdArg[4]);
            var corps = cmdArg[5];

            if (corps == "Airforces" || corps == "Marines")
            {
                var engineer = new Engineer(id, firstName, lastName, salary, corps);
                if (cmdArg.Length >= 6)
                {
                    for (int i = 6; i < cmdArg.Length; i += 2)
                    {
                        var partName = cmdArg[i];
                        var hoursWorked = int.Parse(cmdArg[i + 1]);

                        var repair = new Repair(partName, hoursWorked);
                        engineer.Add(repair);
                    }
                }

                this.soldiers.Add(engineer);
            }
        }

        private void AddLieutenantGeneral(string[] cmdArg, int id, string firstName, string lastName)
        {
            var salary = decimal.Parse(cmdArg[4]);

            var leutenantGeneral = new LieutenantGeneral(id, firstName, lastName, salary);
            if (cmdArg.Length >= 5)
            {
                for (int i = 5; i < cmdArg.Length; i++)
                {
                    var searchId = int.Parse(cmdArg[i]);
                    var privateSoldier = this.soldiers.Where(x => x.Id == searchId).SingleOrDefault();

                    leutenantGeneral.Add((Private)privateSoldier);
                }
            }

            this.soldiers.Add(leutenantGeneral);
        }

        private void AddPrivateSoldier(string[] cmdArg, int id, string firstName, string lastName)
        {
            var salary = decimal.Parse(cmdArg[4]);

            var privateSoldier = new Private(id, firstName, lastName, salary);
            this.soldiers.Add(privateSoldier);
        }

        private void PrintOutput()
        {
            foreach (var soldier in this.soldiers)
            {
                Console.WriteLine(soldier);
            }
        }
    }
}
