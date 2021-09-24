namespace CollectionHierarchy.Collections
{
    using System.Collections.Generic;

    using CollectionHierarchy.Collections.Interfaces;

    public class AddCollection : IAdd
    {
        private readonly Stack<string> date;
        private int index;

        public AddCollection()
        {
            this.date = new Stack<string>();
        }

        public int Add(string element)
        {
            this.date.Push(element);

            return index++;
        }
    }
}
