namespace CollectionHierarchy.Collections
{
    using System.Collections.Generic;

    using CollectionHierarchy.Collections.Interfaces;

    public class MyList : IAdd, IRemove, IMyList
    {
        private readonly List<string> date;

        public MyList()
        {
            this.date = new List<string>();
        }

        public int Used => this.date.Count;

        public int Add(string element)
        {
            this.date.Insert(0, element);

            return 0;
        }

        public string Remove()
        {
            var element = this.date[0];
            this.date.RemoveAt(0);

            return element;
        }
    }
}
