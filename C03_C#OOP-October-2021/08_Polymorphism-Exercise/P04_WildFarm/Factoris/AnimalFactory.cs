namespace WildFarm.Factoris
{
    using WildFarm.Models.Animals;
    using WildFarm.Models.Animals.Birds;
    using WildFarm.Models.Animals.Mammal;
    using WildFarm.Models.Animals.Mammal.Felines;

    public class AnimalFactory 
    {
        public Animal Create(string[] arg)
        {
            Animal animal = null;
            var wingSize = 0.0;
            string breed = string.Empty;
            string livingRegion = string.Empty;

            var animalType = arg[0];
            var name = arg[1];
            var weight = double.Parse(arg[2]);

            switch (animalType)
            {
                case "Hen":
                    wingSize = double.Parse(arg[3]);
                    animal = new Hen(name, weight, wingSize); 
                    break;
                case "Owl":
                    wingSize = double.Parse(arg[3]);
                    animal = new Owl(name, weight, wingSize); 
                    break;
                case "Mouse":
                    livingRegion = arg[3];
                    animal = new Mouse(name, weight, livingRegion); 
                    break;
                case "Cat":
                    livingRegion = arg[3];
                    breed = arg[4];
                    animal = new Cat(name, weight, livingRegion, breed);
                    break;
                case "Dog":
                    livingRegion = arg[3];
                    animal = new Dog(name, weight, livingRegion);
                    break;
                case "Tiger":
                    livingRegion = arg[3];
                    breed = arg[4];
                    animal = new Tiger(name, weight, livingRegion, breed);
                    break;
            }

            return animal;
        }
    }
}
