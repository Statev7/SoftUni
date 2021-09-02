namespace P01_GenericBoxOfString
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
