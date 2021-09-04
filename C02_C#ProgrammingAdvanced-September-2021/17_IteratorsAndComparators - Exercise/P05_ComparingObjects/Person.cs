namespace P05_ComparingObjects
{
    using System;
    using System.Diagnostics.CodeAnalysis;

    public class Person : IComparable<Person>
    {
        public Person(string name, int age, string town)
        {
            this.Name = name;
            this.Age = age;
            this.Town = town;
        }

        public string Name { get; set; }

        public int Age { get; private set; }

        public string Town { get; set; }

        public int CompareTo([AllowNull] Person other)
        {
            var compare = 1;
            bool isValid = this.Name.CompareTo(other.Name) == 0 &&
                            this.Age.CompareTo(other.Age) == 0 &&
                            this.Town.CompareTo(other.Town) == 0;
            if (isValid)
            {
                compare = 0;
            }

            return compare;
        }
    }
}
