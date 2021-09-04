namespace P01_ListyIterator
{
    using System.Collections.Generic;
    using System;

    public class ListyIterator<T>
    {
        private List<T> date;
        private int index;

        public ListyIterator(List<T> list)
        {
            this.date = list;
            this.index = 0;
        }

        public bool Move()
        {
            if (this.index + 1 < this.date.Count)
            {
                this.index++;
                return true;
            }
            return false;
        }

        public bool HasNext()
        {
            bool hasNext = this.index + 1 < this.date.Count;
            if (hasNext)
            {
                return true;
            }
            return false;
        }

        public void Print()
        {
            bool isListEmpty = this.date.Count <= 0;
            if (isListEmpty)
            {
                Console.WriteLine("Invalid Operation!");
            }
            else
            {
                Console.WriteLine(this.date[index]);
            }
        }
    }
}
