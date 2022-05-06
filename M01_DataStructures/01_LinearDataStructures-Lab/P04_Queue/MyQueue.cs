namespace P04_Queue
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class MyQueue<TEntity> : IEnumerable<TEntity>
    {
        private Node<TEntity> head;
        private Node<TEntity> last;

        public int Count { get; private set; }

        public void Enqueue(TEntity item)
        {
            var newLast = new Node<TEntity>(item);
            if (this.head == null)
            {
                this.head = newLast;
                this.last = newLast;
            }
            else
            {
                this.last.Next = newLast;
                this.last = newLast;
            }

            this.Count++; 
        }

        public TEntity Dequeue()
        {
            this.EnsureNotEmpty();

            var newHead = this.head.Next;
            var valueToReturn = this.head.Value;
            this.head = newHead;

            this.Count--;
            return valueToReturn;
        }

        public TEntity Peek()
        {
            this.EnsureNotEmpty();

            return this.head.Value;

        }

        public bool Contains(TEntity item)
        {
            var node = this.head;
            while (node != null)
            {
                if (node.Value.Equals(item))
                {
                    return true;
                }

                node = node.Next;
            }

            return false;
        }

        public IEnumerator<TEntity> GetEnumerator()
        {
            var node = this.head;
            while (node != null)
            {
                yield return node.Value;
                node = node.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();

        private void EnsureNotEmpty()
        {
            if (this.Count <= 0)
            {
                throw new InvalidOperationException();
            }
        }
    }
}
