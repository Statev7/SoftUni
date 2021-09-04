namespace P03_Stack
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class MyStack<T> : IEnumerable<T>
    {
        private T[] date;

        public MyStack()
        {
            this.date = new T[4];
        }

        public int Count { get; private set; }

        public void Push(T element)
        {
            if (this.Count == this.date.Length)
            {
                this.Resize();
            }

            this.date[this.Count] = element;
            this.Count++;
        }

        public void Pop()
        {
            if (this.Count <= 0)
            {
                Console.WriteLine("No elements");
            }
            else
            {
                this.date[--Count] = default;
            }
        }

        private void Resize()
        {
            var newDate = new T[this.date.Length * 2];

            for (int i = 0; i < this.Count; i++)
            {
                newDate[i] = this.date[i];
            }

            this.date = newDate;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < 2; i++)
            {
                for (int j = this.Count - 1; j >= 0; j--)
                {
                    yield return this.date[j];
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
