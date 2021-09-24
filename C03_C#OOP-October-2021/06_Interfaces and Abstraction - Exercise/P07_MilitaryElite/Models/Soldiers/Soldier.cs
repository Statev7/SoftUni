namespace MilitaryElite.Models.Soldiers
{
    using System.Text;

    using MilitaryElite.Models.Soldiers.Interfaces;

    public abstract class Soldier : ISoldier
    {
        protected Soldier(int id, string firstName, string lastName)
        {
            this.Id = id;
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        public int Id { get; private set; }

        public string FirstName { get; private set; }

        public string LastName { get; private set; }
    }
}
