namespace P06_StoreBoxes.Models
{
    public class Item
    {
        public Item(string name, decimal price)
        {
            this.Name = name;
            this.Price = price;
        }

        public string Name { get; private set; }

        public decimal Price { get; private set; }
    }
}
