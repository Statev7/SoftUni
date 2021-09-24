namespace MilitaryElite.Models.Soldiers.PrivateSoldiers.SpecialisedSoldiers.Commandos
{
    using System;

    using MilitaryElite.Models.Soldiers.Interfaces;

    public class Mission : IMission
    {
        public Mission(string codeName, string state)
        {
            this.CodeName = codeName;
            this.State = state;
        }

        public string State { get; private set; }

        public string CodeName { get; private set; }

        public void CompleteMission()
        {
            this.State = "Finished";
        }

        public override string ToString()
        {
            return $"Code Name: {this.CodeName} State: {this.State}";
        }
    }
}
