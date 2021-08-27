namespace P09_PokemonTrainer
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        private const string COMMAND_TO_STOP_READ_POKEMONS = "Tournament";
        private const string COMMAND_TO_STOP_TORNAMENT = "End";

        public static void Main()
        {
            List<Trainers> allTrainers = new List<Trainers>();

            string pokemonsArg = Console.ReadLine();
            while (pokemonsArg != COMMAND_TO_STOP_READ_POKEMONS)
            {
                var splited = pokemonsArg
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string trainerName = splited[0];
                string pokemonName = splited[1];
                string pokemonElement = splited[2];
                int pokemonHeal = int.Parse(splited[3]);

                Trainers trainer = new Trainers();
                Pokemon pokemon = new Pokemon(pokemonName, pokemonElement, pokemonHeal);

                trainer = allTrainers.Where(x => x.Name == trainerName).SingleOrDefault();
                if (trainer != null)
                {
                    trainer.Pokemons.Add(pokemon);
                }
                else
                {
                    trainer = new Trainers(trainerName);
                    trainer.Pokemons.Add(pokemon);
                    allTrainers.Add(trainer);
                }

                pokemonsArg = Console.ReadLine();
            }

            string elementInput = Console.ReadLine();
            while (elementInput != COMMAND_TO_STOP_TORNAMENT)
            {
                var pokemonsToRemove = new List<Pokemon>();

                foreach (var trainer in allTrainers)
                {
                    var validPokemons = trainer.Pokemons.Where(x => x.Element == elementInput).ToList();
                    if (validPokemons.Count == 0)
                    {
                        foreach (var pokemon in trainer.Pokemons)
                        {
                            pokemon.Health -= 10;
                            if (pokemon.Health <= 0)
                            {
                                pokemonsToRemove.Add(pokemon);
                            }
                        }

                        if (pokemonsToRemove.Count > 0)
                        {
                            foreach (var pokemonToRemove in pokemonsToRemove)
                            {
                                trainer.Pokemons.Remove(pokemonToRemove);
                            }
                        }
                    }
                    else
                    {
                        trainer.Badges += 1;
                    }
                }
                

                elementInput = Console.ReadLine();
            }

            foreach (var trainer in allTrainers
                .OrderByDescending(x => x.Badges))
            {
                Console.WriteLine(trainer);
            }
        }
    }
}
