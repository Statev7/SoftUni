namespace Zoo
{
    public class Animal
    {
        public Animal(string name)
        {
            this.Name = name;
        }

        public string Name { get; set; }

        public override string ToString()
        {
            return $"{this.Name}";
        }
    }
}
