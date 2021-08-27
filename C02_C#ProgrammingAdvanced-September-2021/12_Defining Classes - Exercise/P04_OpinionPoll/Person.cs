namespace P04_OpinionPoll
{
    using System.Text;

    public class Person
    {
        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        public string Name { get; set; }

        public int Age { get; set; }

        public override string ToString()
        {
            StringBuilder str = new StringBuilder();
            str.Append($"{this.Name} - {this.Age}");

            return str.ToString(); 
        }
    }
}
