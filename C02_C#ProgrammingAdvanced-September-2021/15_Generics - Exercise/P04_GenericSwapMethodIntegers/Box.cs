namespace P04_GenericSwapMethodIntegers
{
    using System.Collections.Generic;
    using System.Text;

    public class Box<T>
    {
        private readonly List<T> collection;
        public Box()
        {
            collection = new List<T>();
        }

        public void Add(T item)
        {
            this.collection.Add(item);
        }

        public void Swap(int firstIndex, int secondIndex)
        {
            var firstValue = this.collection[firstIndex];
            this.collection[firstIndex] = this.collection[secondIndex];
            this.collection[secondIndex] = firstValue;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var item in this.collection)
            {
                sb.AppendLine($"{item.GetType()}: {item}");
            }

            return sb.ToString().TrimEnd(); 
        }
    }
}
