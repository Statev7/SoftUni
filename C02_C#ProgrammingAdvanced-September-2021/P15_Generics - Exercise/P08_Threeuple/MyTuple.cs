namespace P08_Threeuple
{
    using System.Text;

    public class MyTuple<Item1, Item2, Item3>
    {
        public MyTuple(Item1 firstItem, Item2 secondItem, Item3 thirdItem)
        {
            this.FirstItem = firstItem;
            this.SecondItem = secondItem;
            this.ThirdItem = thirdItem;
        }

        public Item1 FirstItem { get; set; }

        public Item2 SecondItem { get; set; }

        public Item3 ThirdItem { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"{this.FirstItem} -> {this.SecondItem} -> {this.ThirdItem}");

            return sb.ToString().TrimEnd(); 
        }
    }
}
