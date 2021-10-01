namespace WildFarm.Core
{
    using System.Collections.Generic;
    using System.Linq;

    using WildFarm.Common.Exeptions;
    using WildFarm.Core.Contracts;
    using WildFarm.Factoris;
    using WildFarm.IO.Contracts;
    using WildFarm.Models.Animals;
    using WildFarm.Models.Animals.Contracts;
    using WildFarm.Models.Foods;

    public class Engine : IEngine
    {
        private const string COMMAND_TO_END_READ_ARG = "End";

        private readonly ICollection<IAnimal> animals;
        private IReader reader;
        private IWriter writer;

        private Engine()
        {
            this.animals = new List<IAnimal>();
        }

        public Engine(IReader reader, IWriter writer)
            :this()
        {
            this.reader = reader;
            this.writer = writer;
        }

        public void Run()
        {
            this.ExecuteCommands();
            this.PrintOutput();
        }

        private void ExecuteCommands()
        {
            var animalFactory = new AnimalFactory();
            var foodFactory = new FoodFactory();
            Animal animal = null;
            Food food = null;
            var counter = 0;

            var input = reader.ReadLine();
            while (input != COMMAND_TO_END_READ_ARG)
            {
                var arg = input
                    .Split(" ", System.StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                if (counter % 2 == 0)
                {
                    animal = animalFactory.Create(arg);
                    this.animals.Add(animal);
                }
                else
                {
                    food = foodFactory.Create(arg);
                    writer.WriteLine(animal.MakeSound());
                    try
                    {
                        animal.Eat(food);
                    }
                    catch (EatExeption ex)
                    {
                        writer.WriteLine(ex.Message);
                    }
                }

                counter++;
                input = reader.ReadLine();
            }
        }

        private void PrintOutput()
        {
            foreach (var animal in this.animals)
            {
                writer.WriteLine(animal.ToString());
            }
        }
    }
}
