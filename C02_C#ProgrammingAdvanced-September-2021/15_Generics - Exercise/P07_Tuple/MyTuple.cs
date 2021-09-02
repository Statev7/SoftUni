namespace P07_Tuple
{
    using System.Text;

    public class MyTuple<Item1, Item2>
    {
        public MyTuple(Item1 firstItem, Item2 secondItem)
        {
            this.FirstItem = firstItem;
            this.SecondItem = secondItem;
        }

        public Item1 FirstItem { get; private set; }

        public Item2 SecondItem { get; private set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"{this.FirstItem} -> {this.SecondItem}");

            return sb.ToString().TrimEnd(); 
        }
    }
}
