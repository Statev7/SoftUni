namespace P05_Students2._0.Models
{
    public class Student
    {
        const string RESULT_MESSAGE = "{0} {1} is {2} years old.";

        public Student(string firstName, string lastName, byte age, string city)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
            this.City = city;
        }

        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public byte Age { get; set; }

        public string City { get; private set; }

        public override string ToString()
        {
            string result = string.Format(RESULT_MESSAGE, this.FirstName, this.LastName, this.Age);
            return result.ToString();
        }

    }
}
