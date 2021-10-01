namespace WildFarm.Factoris
{
    using WildFarm.Models.Foods;

    public class FoodFactory
    {
        public Food Create(string[] arg)
        {
            Food food = null;

            var foodType = arg[0];
            var quantity = int.Parse(arg[1]);

            switch (foodType)
            {
                case "Vegetable": food = new Vegetable(quantity); break;
                case "Fruit": food = new Fruit(quantity); break;
                case "Meat": food = new Meat(quantity); break;
                case "Seeds": food = new Seeds(quantity); break;
            }

            return food;
        }
    }
}
