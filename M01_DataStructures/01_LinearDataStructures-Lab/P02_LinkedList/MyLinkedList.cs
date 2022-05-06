namespace P02_LinkedList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class MyLinkedList<TEnity> : IEnumerable<TEnity>
    {
        public Node<TEnity> Head { get; set; }

        public Node<TEnity> Tail { get; set; }

        public int Count { get; private set; }

        public void AddFirst(TEnity item)
        {
            var newHead = new Node<TEnity>(item);
            if (this.Head == null)
            {
                this.Tail = newHead;
            }
            else
            {
                newHead.Next = this.Head;
                this.Head.Previous = newHead;
            }
            
            this.Head = newHead;
            this.Count++;
        }

        public void AddLast(TEnity item)
        {
            var newTail = new Node<TEnity>(item);
            if (this.Head == null)
            {
                this.Head = newTail;
            }
            else
            {
                newTail.Previous = this.Tail;
                this.Tail.Next = newTail;
            }

            this.Tail = newTail;
            this.Count++;
        }

        public TEnity RemoveFirst()
        {
            this.ValidateIfThereAnyElements();

            var valueToReturn = this.Head.Value;

            var newHead = this.Head.Next;
            this.Head = newHead;
            this.Count--;

            return valueToReturn;
        }

        public TEnity RemoveLast()
        {
            this.ValidateIfThereAnyElements();

            var valueToReturn = this.Tail.Value;

            var newTail = this.Tail.Previous;
            this.Tail = newTail;
            this.Count--;

            return valueToReturn;
        }

        public TEnity GetFirst()
        {
            this.ValidateIfThereAnyElements();

            return this.Head.Value;
        }

        public TEnity GetLast()
        {
            this.ValidateIfThereAnyElements();

            return this.Tail.Value;
        }

        public IEnumerator<TEnity> GetEnumerator()
        {
            var currentNode = this.Head;
            while (currentNode != null)
            {
                var newNode = currentNode.Next;

                yield return currentNode.Value;

                currentNode = newNode;
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
