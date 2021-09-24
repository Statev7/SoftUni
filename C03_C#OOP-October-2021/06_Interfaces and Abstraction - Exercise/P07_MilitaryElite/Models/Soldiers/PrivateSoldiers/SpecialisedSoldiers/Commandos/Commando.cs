namespace MilitaryElite.Models.Soldiers.PrivateSoldiers.SpecialisedSoldiers.Commandos
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using MilitaryElite.Models.Soldiers.PrivateSoldier.SpecialisedSoldier;

    public class Commando : SpecialisedSoldier
    {
        private readonly List<Mission> missions;

        public Commando(int id, string firstName, string lastName, decimal salary, string corps) 
            : base(id, firstName, lastName, salary, corps)
        {
            this.missions = new List<Mission>();
        }

        public void AddMission(Mission mission)
        {
            this.missions.Add(mission);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Name: {this.FirstName} {this.LastName} Id: {this.Id} Salary: {this.Salary:F2}");
            sb.AppendLine($"Corps: {this.Corps}");
            sb.AppendLine($"Missions:");
            foreach (var mission in this.missions)
            {
                sb.AppendLine($"  {mission}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
