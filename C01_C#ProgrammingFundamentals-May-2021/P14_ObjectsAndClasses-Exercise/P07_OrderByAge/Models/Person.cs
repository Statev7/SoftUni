namespace P07_OrderByAge.Models
{
    public class Person
    {
        public Person(string name, string id, byte age)
        {
            this.Name = name;
            this.Id = id;
            this.Age = age;
        }

        public string Name { get; private set; }

        public string Id { get; private set; }

        public byte Age { get; private set; }

        public override string ToString()
        {
            string result = $"{this.Name} with ID: {this.Id} is {this.Age} years old.";
            return result.ToString();
        }
    }
}
