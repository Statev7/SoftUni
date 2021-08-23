namespace P05_FilterByAge
{
    class Person
    {
        public Person(string name, byte age)
        {
            this.Name = name;
            this.Age = age;
        }

        public string Name { get; set; }

        public byte Age { get; set; }
    }
}
