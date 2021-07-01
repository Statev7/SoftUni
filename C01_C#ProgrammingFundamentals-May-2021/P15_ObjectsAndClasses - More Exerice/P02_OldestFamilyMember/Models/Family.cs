namespace P02_OldestFamilyMember.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Family
    {
        public Family()
        {
            Person = new List<Person>();
        }

        public List<Person> Person { get; private set; }

        public void PrintOldestMember()
        {
            Person oldestMember = Person
                .OrderByDescending(x => x.Age)
                .Take(1)
                .SingleOrDefault();

            Console.WriteLine(oldestMember);
        }
    }
}
