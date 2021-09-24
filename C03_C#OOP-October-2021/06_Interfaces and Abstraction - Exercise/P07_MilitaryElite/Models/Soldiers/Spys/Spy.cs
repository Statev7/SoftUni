namespace MilitaryElite.Models.Soldiers.Spys
{
    using System;
    using System.Text;

    using MilitaryElite.Models.Soldiers.Interfaces;

    public class Spy : Soldier, ISpy
    {
        public Spy(int id, string firstName, string lastName, int codeNumber) 
            : base(id, firstName, lastName)
        {
            this.CodeNumber = codeNumber;
        }

        public int CodeNumber { get; private set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Name: {this.FirstName} {this.LastName} Id: {this.Id}");
            sb.Append($"Code Number: {this.CodeNumber}");

            return sb.ToString().TrimEnd();
        }
    }
}
