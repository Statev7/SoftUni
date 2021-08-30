namespace P02_ImplemantationStack
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public class MyStack<T> : IEnumerable<T>
    {
        private T[] date;
        private int capacity;

        public MyStack()
            :this(4)
        {

        }

        public MyStack(int capacity)
        {
            this.capacity = capacity;
            this.date = new T[capacity];
        }

        public int Count { get; private set; }

        public void Push(T element)
        {
            if (this.date.Length == this.Count)
            {
                this.Resize();
            }

            this.date[Count] = element;
            this.Count++;
        }

        public T Pop()
        {
            this.IsStackEmpty();

            var element = this.date[this.Count - 1];
            this.Count--;

            return element;
        }

        public T Peak()
        {
            this.IsStackEmpty();

            return date[this.Count - 1];
        }

        public void Clear()
        {
            this.date = new T[capacity];
            this.Count = 0;
        }

        public void ForEach(Action<T> filter)
        {
            for (int i = this.Count - 1; i >= 0; i--)
            {
                filter(this.date[i]);
            }
        }

        private void Resize()
        {
            var newDate = new T[capacity * 2];

            for (int i = 0; i < this.Count; i++)
            {
                this.date[i] = newDate[i];
            }

            this.date = newDate;
        }

        private void IsStackEmpty()
        {
            bool isEmpty = this.Count == 0;
            if (isEmpty)
            {
                throw new Exception("Stack is empty");
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            return this.date.Take(this.Count).Reverse().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
