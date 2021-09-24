namespace MilitaryElite.Models.Soldiers.PrivateSoldier.LieutenantGeneral
{
    using System;
    using System.Text;
    using System.Collections.Generic;

    using MilitaryElite.Models.Soldiers.Interfaces;

    public class LieutenantGeneral : Private, ILieutenantGeneral
    {
        private readonly List<Private> privates;

        public LieutenantGeneral(int id, string firstName, string lastName, decimal salary) 
            : base(id, firstName, lastName, salary)
        {
            this.privates = new List<Private>();
        }

        public void Add(Private privateToAdd)
        {
            this.privates.Add(privateToAdd);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Name: {this.FirstName} {this.LastName} Id: {this.Id} Salary: {this.Salary:F2}");
            sb.AppendLine("Privates:");
            foreach (var @private in this.privates)
            {
                sb.AppendLine($"  {@private}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
