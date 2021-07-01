namespace P02_OldestFamilyMember.Models
{
    public class Person
    {
        public Person(string name, byte age)
        {
            this.Name = name;
            this.Age = age;
        }

        public string Name { get; private set; }

        public byte Age { get; private set; }

        public override string ToString()
        {
            string result = $"{this.Name} {this.Age}";

            return result.ToString();
        }
    }
}
