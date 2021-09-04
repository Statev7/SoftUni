namespace P02_Collection
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class ListyIterator<T> : IEnumerable<T>
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
            bool canMove = this.index + 1 < this.date.Count;
            if (canMove)
            {
                this.index++;
            }

            return canMove;
        }

        public bool HasNext()
        {
            return this.index + 1 < this.date.Count;
        }

        public T Print()
        {
            if (this.date.Count <= 0)
            {
                throw new Exception("Invalid Operation!");
            }

            return this.date[index];
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var item in this.date)
            {
                yield return item;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
