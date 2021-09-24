namespace MilitaryElite.Models.Soldiers.PrivateSoldier.SpecialisedSoldier
{
    using System;

    using MilitaryElite.Models.Soldiers.Interfaces;

    public abstract class SpecialisedSoldier : Private, ISpecialisedSoldier
    {
        private string corps;

        public SpecialisedSoldier(int id, string firstName, string lastName, decimal salary, string corps) 
            : base(id, firstName, lastName, salary)
        {
            this.Corps = corps;
        }

        public string Corps { get; private set; }
        
    }
}
