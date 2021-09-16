namespace Animals
{
    using System;
    using System.Collections.Generic;

    public class Engine
    {
        private const string COMMAND_TO_END_READ_ARGUMENTS = "Beast!";

        private readonly List<Animal> animals;

        public Engine()
        {
            this.animals = new List<Animal>();
        }

        public void Run()
        {
            string animalType = Console.ReadLine();
            while (animalType != COMMAND_TO_END_READ_ARGUMENTS)
            {
                string[] animalArg = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                Animal animal = null;
                try
                {
                    animal = CreateAnimal(animalType, animalArg);
                    animals.Add(animal);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                animalType = Console.ReadLine();
            }

            PrintAnimals(animals);
        }

        private static void PrintAnimals(List<Animal> animals)
        {
            foreach (var animal in animals)
            {
                Console.WriteLine(animal);
            }
        }

        private static Animal CreateAnimal(string animalType, string[] animalArg)
        {
            string name = animalArg[0];
            int age = int.Parse(animalArg[1]);
            string gender = string.Empty;

            if (animalArg.Length >= 3)
            {
                gender = animalArg[2];
            }

            Animal animal = null;
            if (animalType == "Cat")
            {
                animal = new Cat(name, age, gender);
            }
            else if (animalType == "Dog")
            {
                animal = new Dog(name, age, gender);
            }
            else if (animalType == "Frog")
            {
                animal = new Frog(name, age, gender);
            }
            else if (animalType == "Tomcat")
            {
                animal = new Tomcat(name, age);
            }
            else if (animalType == "Kitten")
            {
                animal = new Kitten(name, age);
            }

            return animal;
        }
    }
}
