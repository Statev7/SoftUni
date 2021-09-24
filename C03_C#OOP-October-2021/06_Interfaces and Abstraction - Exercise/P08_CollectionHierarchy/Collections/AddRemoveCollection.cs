namespace CollectionHierarchy.Collections
{
    using System.Collections.Generic;

    using CollectionHierarchy.Collections.Interfaces;

    public class AddRemoveCollection : IAdd, IRemove
    {
        private readonly List<string> date;

        public AddRemoveCollection()
        {
            this.date = new List<string>();
        }

        public int Add(string element)
        {
            this.date.Insert(0, element);

            return 0;
        }

        public string Remove()
        {
            var index = this.date.Count - 1;
            var element = this.date[index];
            this.date.RemoveAt(index);

            return element;
        }
    }
}
