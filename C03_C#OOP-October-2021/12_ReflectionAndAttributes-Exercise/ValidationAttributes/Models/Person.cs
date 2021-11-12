using ValidationAttributes.Attributes;

namespace ValidationAttributes.Models
{
    public class Person
    {
        private const int MIN_AGE_VALUE = 12;
        private const int MAX_AGE_VALUE = 90;

        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }

        [MyRequired]
        public string Name { get; private set; }

        [MyRange(MIN_AGE_VALUE, MAX_AGE_VALUE)]
        public int Age { get; private set; }
    }
}
