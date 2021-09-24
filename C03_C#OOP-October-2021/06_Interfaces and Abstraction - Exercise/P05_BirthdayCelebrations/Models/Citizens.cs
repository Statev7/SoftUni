namespace BirthdayCelebrations.Models
{
    using System;

    using BirthdayCelebrations.Models.Interfaces;

    public class Citizens : ICreature, IBirthble
    {
        public Citizens(string name, int age, string id, string birthDate)
        {
            this.Name = name;
            this.Age = age;
            this.Id = id;
            this.BirthDate = birthDate;
        }

        public string Name { get; private set; }

        public int Age { get; private set; }

        public string Id { get; private set; }

        public string BirthDate { get; private set; }
    }
}
