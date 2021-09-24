namespace BirthdayCelebrations.Models
{
    using System;

    using BirthdayCelebrations.Models.Interfaces;

    public class Pet : IBirthble
    {
        public Pet(string name, string birthDate)
        {
            this.Name = name;
            this.BirthDate = birthDate;
        }

        public string Name { get; private set; }

        public string BirthDate { get; private set; }
    }
}
