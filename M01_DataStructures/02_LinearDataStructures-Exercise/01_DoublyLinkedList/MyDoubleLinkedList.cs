namespace _01_DoublyLinkedList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    using _01_DoublyLinkedList.Contracts;

    public class MyDoubleLinkedList<TEntity> : IAbstractLinkedList<TEntity>
    {
        private Node<TEntity> head;
        private Node<TEntity> tail;

        public int Count { get; private set; }

        public void AddFirst(TEntity item)
        {
            var newHead = new Node<TEntity>(item);
            if (this.Count == 0)
            {
                this.head = newHead;
                this.tail = newHead;
            }
            else
            {
                newHead.Next = this.head;
                this.head.Previous = newHead;
                this.head = newHead;
            }

            this.Count++;
        }

        public void AddLast(TEntity item)
        {
            var newTail = new Node<TEntity>(item);
            if (this.Count == 0)
            {
                this.head = newTail;
                this.tail = newTail;
            }
            else
            {
                this.tail.Next = newTail;
                newTail.Previous = this.tail;
                this.tail = newTail;
            }

            this.Count++;
        }

        public TEntity RemoveFirst()
        {
            this.ValidateCollection();

            var newHead = this.head.Next;
            var valueToReturn = this.head.Value;
            this.head = newHead;

            this.Count--;
            return valueToReturn;
        }

        public TEntity RemoveLast()
        {
            this.ValidateCollection();

            var newTail = this.tail.Previous;
            var valueToReturn = this.tail.Value;
            this.tail = newTail;

            this.Count--;
            return valueToReturn;
        }

        public TEntity GetFirst()
        {
            this.ValidateCollection();

            return this.head.Value;
        }

        public TEntity GetLast()
        {
            this.ValidateCollection();

            return this.tail.Value;
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

        private void ValidateCollection()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException();
            }
        }
    }
}
