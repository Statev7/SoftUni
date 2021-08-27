namespace P09_PokemonTrainer
{
    public class Pokemon
    {
        public Pokemon()
        {

        }

        public Pokemon(string name, string element, int health)
        {
            this.Name = name;
            this.Element = element;
            this.Health = health;
        }

        public string Name { get; private set; }

        public string Element { get; private set; }

        public int Health { get; set; }
    }
}
