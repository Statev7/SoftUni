namespace P06_EqualityLogic
{
    using System;
    using System.Diagnostics.CodeAnalysis;

    public class Person : IComparable<Person>
    {
        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        public string Name { get; private set; }

        public int Age { get; private set; }

        public int CompareTo([AllowNull] Person other)
        {
            var result = this.Name.CompareTo(other.Name);
            if (result == 0)
            {
                result = this.Age.CompareTo(other.Age);
            }

            return result;
        }

        public override bool Equals(Object obj)
        {
            if (obj is Person person)
            {
                return this.Name == person.Name && this.Age == person.Age;
            }

            return false;    
        }

        public override int GetHashCode()
        {
            return this.Name.GetHashCode() + this.Age.GetHashCode();  
        }
    }
}
