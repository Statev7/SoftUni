namespace WildFarm.Models.Foods
{
    using WildFarm.Models.Foods.Contacts;

    public abstract class Food : IFood
    {
        public Food(int quantity)
        {
            this.Quantity = quantity;
        }

        public int Quantity { get; private set; }
    }
}
