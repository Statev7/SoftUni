namespace P01_CompanyRoster.Models
{
    public class Employee
    {
        public Employee(string name, decimal salary, string department)
        {
            this.Name = name;
            this.Salary = salary;
            this.Department = department;
        }

        public string Name { get; private set; }

        public decimal Salary { get; private set; }

        public string Department { get; private set; }

        public override string ToString()
        {
            string result = ($"{this.Name} {this.Salary:F2}");

            return result.ToString();
        }
    }
}
