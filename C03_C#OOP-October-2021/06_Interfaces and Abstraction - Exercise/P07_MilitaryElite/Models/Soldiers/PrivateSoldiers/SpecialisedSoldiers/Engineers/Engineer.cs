namespace MilitaryElite.Models.Soldiers.PrivateSoldiers.SpecialisedSoldiers.Engineers
{
    using System.Text;
    using System.Collections.Generic;

    using MilitaryElite.Models.Soldiers.Interfaces;
    using MilitaryElite.Models.Soldiers.PrivateSoldier.SpecialisedSoldier;
    using System;

    public class Engineer : SpecialisedSoldier, IEngineer
    {
        private readonly List<Repair> repairs;

        public Engineer(int id, string firstName, string lastName, decimal salary, string corps) 
            : base(id, firstName, lastName, salary, corps)
        {
            this.repairs = new List<Repair>();
        }

        public void Add(Repair repair)
        {
            this.repairs.Add(repair);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Name: {this.FirstName} {this.LastName} Id: {this.Id} Salary: {this.Salary:F2}");
            sb.AppendLine($"Corps: {this.Corps}");
            sb.AppendLine($"Repairs:");
            foreach (var repair in this.repairs)
            {
                sb.AppendLine($"  {repair}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
