namespace P06_StoreBoxes.Models
{
    using System.Text;

    public class Box
    {
        public Box(string serialNumber, Item item, int itemQuantity)
        {
            this.SerialNumber = serialNumber;
            this.Item = item;
            this.ItemQuantity = itemQuantity;
        }

        public string SerialNumber { get; private set; }

        public Item Item { get; private set; }

        public int ItemQuantity { get; private set; }

        public decimal BoxPrice => this.ItemQuantity * this.Item.Price;

        public override string ToString()
        {
            StringBuilder str = new StringBuilder();

            str.AppendLine($"{this.SerialNumber}");
            str.AppendLine($"-- {this.Item.Name} - ${this.Item.Price:F2}: {this.ItemQuantity}");
            str.AppendLine($"-- ${this.BoxPrice:F2}");

            return str.ToString();
        }
    }
}
