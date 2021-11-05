namespace P06_ValidPerson
{
    using System;

    public class Person
    {
        private const string INVALID_NAME_LENGHT_ERROR_MESSAGE = "The {0} name cannot be null or empty.";
        private const string INVALID_AGE_ERROR_MESSAGE = "Age should be in the range [{0} .. {1}].";

        private const int MIN_AGE_VALUE = 0;
        private const int MAX_AGE_VALUE = 120;

        private string firstName;
        private string lastName;
        private int age;

        public Person(string firstName, string lastName, int age)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
        }

        public string FirstName
        {
            get
            {
                return this.firstName;
            }
            private set
            {
                this.CheckNameLenght(value, nameof(firstName));
                this.firstName = value;
            }
        }

        public string LastName
        {
            get
            {
                return this.lastName;
            }
            private set
            {
                this.CheckNameLenght(value, nameof(lastName));
                this.lastName = value;
            }
        }

        public int Age
        {
            get
            {
                return this.age;
            }
            private set
            {
                bool isInvalid = value < MIN_AGE_VALUE || MAX_AGE_VALUE < value;
                if (isInvalid)
                {
                    var message = string.Format(INVALID_AGE_ERROR_MESSAGE, MIN_AGE_VALUE, MAX_AGE_VALUE);
                    throw new ArgumentOutOfRangeException("value", message);
                }
                this.age = value;
            }
        }

        private void CheckNameLenght(string value, string nameType)
        {
            if (string.IsNullOrEmpty(value))
            {
                var message = nameType.Contains("first") ? string.Format(INVALID_NAME_LENGHT_ERROR_MESSAGE, "first") 
                                                         : string.Format(INVALID_NAME_LENGHT_ERROR_MESSAGE, "last");
                throw new ArgumentNullException("value", message);
            }
        }

        public override string ToString()
        {
            return $"{this.FirstName} {this.LastName} {this.Age}";
        }
    }
}
