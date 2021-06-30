namespace P04_Students.Models
{
    public class Student
    {
        public Student(string firstName, string lastName, double grade)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Grade = grade;
        }

        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public double Grade { get; private set; }

        public override string ToString()
        {
            string result = $"{this.FirstName} {this.LastName}: {this.Grade:F2}";

            return result.ToString();
        }
    }
}
