namespace Person
{
    using System;
    using System.Text;

    public class Person
    {
        private const int PERSON_MIN_AGE_VALUE = 0;

        private int age;

        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        public string Name { get; set; }

        public int Age
        {
            get
            {
                return this.age;
            }
            private set
            {
                if (value < PERSON_MIN_AGE_VALUE)
                {
                    throw new Exception("Age cannot be negative");
                }

                this.age = value;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"Name: {this.Name}, Age: {this.Age}");
            return sb.ToString(); 
        }
    }
}
