namespace P03_OldestFamilyMember
{
    using System.Collections.Generic;
    using System.Linq;

    public class Family
    {
        public Family()
        {
            FamilyMembers = new List<Person>();
        }

        public List<Person> FamilyMembers { get; set; }

        public void AddMember(Person member)
        {
            FamilyMembers.Add(member);
        }

        public Person GetOldestMember()
        {
            Person oldestMember = this.FamilyMembers
                .OrderByDescending(x => x.Age)
                .FirstOrDefault();

            return oldestMember;
        }
    }
}
