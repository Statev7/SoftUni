namespace P03_Stack
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class MyStack<TEntity> : IEnumerable<TEntity>
    {
        private Node<TEntity> top;

        public int Count { get; private set; }

        public bool Contains(TEntity item)
        {
            var currentTop = this.top;
            while (currentTop != null)
            {
                var currentItem = currentTop.Value;

                bool isEqual = currentItem.Equals(item);
                if (isEqual)
                {
                    return true;
                }

                currentTop = currentTop.Next;
            }

            return false;
        }

        public TEntity Peek()
        {
            ValidateIfThereAnyElements();

            return this.top.Value; 
        }

        public TEntity Pop()
        {
            ValidateIfThereAnyElements();

            var valueToReturn = this.top.Value;

            var newTop = this.top.Next;
            this.top = newTop;

            this.Count--;

            return valueToReturn;
        }

        public void Push(TEntity item)
        {
            var newTop = new Node<TEntity>(item);

            if (this.top == null)
            {
                this.top = newTop;
            }
            else
            {
                newTop.Next = this.top;
                this.top = newTop;
            }

            this.Count++;
        }

        public IEnumerator<TEntity> GetEnumerator()
        {
            var currentTop = this.top;
            while (currentTop != null)
            {
                yield return currentTop.Value;
                currentTop = currentTop.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();

        private void ValidateIfThereAnyElements()
        {
            bool areThereAnyElements = this.Count != 0;
            if (areThereAnyElements == false)
            {
                throw new InvalidOperationException();
            }
        }
    }
}
