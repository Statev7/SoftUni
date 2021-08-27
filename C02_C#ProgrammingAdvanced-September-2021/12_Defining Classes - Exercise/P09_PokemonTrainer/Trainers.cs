namespace P09_PokemonTrainer
{
    using System.Collections.Generic;
    using System.Text;

    public class Trainers
    {
        public Trainers()
        {
            this.Badges = 0;
            this.Pokemons = new List<Pokemon>();
        }

        public Trainers(string name)
            :this()
        {
            this.Name = name;
        }

        public string Name { get; private set; }

        public int Badges { get; set; }

        public List<Pokemon> Pokemons { get; set; }

        public override string ToString()
        {
            StringBuilder str = new StringBuilder();
            str.Append($"{this.Name} {this.Badges} {this.Pokemons.Count}");

            return str.ToString(); 
        }
    }
}
