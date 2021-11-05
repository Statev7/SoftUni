namespace P07_CustomException
{
    using System.Linq;

    public class Student
    {
        private const string INVALID_NAME_ERRROR_MESSAGE = "The name cannot contain numbers, special characters or blank characters";

        private string firstName;

        public Student(string firstName, string mail)
        {
            this.FirstName = firstName;
            this.Mail = mail;
        }

        public string FirstName
        {
            get
            {
                return this.firstName;
            }
            private set
            {
                bool isInvalid = value.Any(x => char.IsDigit(x) || char.IsWhiteSpace(x) || char.IsPunctuation(x));
                if (isInvalid)
                {
                    throw new InvalidPersonNameException(INVALID_NAME_ERRROR_MESSAGE);
                }

                this.firstName = value;
            }
        }

        public string Mail { get; private set; }

        public override string ToString()
        {
            return $"{this.FirstName} {this.Mail}";
        }
    }
}
