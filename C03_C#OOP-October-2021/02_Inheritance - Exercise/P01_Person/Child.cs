namespace Person
{
    using System;

    public class Child : Person
    {
        private const int CHILD_AGE_MAX_VALUE = 15;

        public Child(string name, int age)
            :base(name, age)
        {
            
        }
    }
}
