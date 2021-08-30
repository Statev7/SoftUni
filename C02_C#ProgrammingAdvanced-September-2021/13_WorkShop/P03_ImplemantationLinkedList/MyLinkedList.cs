namespace P03_ImplemantationLinkedList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class MyLinkedList<T> : IEnumerable<T>
    {
        private ListNote<T> head;
        private ListNote<T> tail;

        public int Count { get; private set; }

        public void AddFirst(T element)
        {
            bool isListEmpty = this.Count == 0;
            if (isListEmpty)
            {
                this.AddHeadAndTail(element);
            }
            else
            {
                var newHead = new ListNote<T>(element);
                newHead.NextNode = this.head;
                this.head.PreviosNode = newHead;
                this.head = newHead;
            }

            this.Count++;
        }

        public void AddLast(T element)
        {
            bool isListEmpty = this.Count == 0;
            if (isListEmpty)
            {
                this.AddHeadAndTail(element);
            }
            else
            {
                var newTail = new ListNote<T>(element);
                this.tail.NextNode = newTail;
                newTail.PreviosNode = this.tail;
                this.tail = newTail;
            }

            this.Count++;
        }

        public T RemoveFirst()
        {
            this.IsListEmpty();
            T removedElement = this.head.Value;

            this.head = head.NextNode;
            if (this.head != null)
            {
                this.head.PreviosNode = null;
            }
            else
            {
                this.head = null;
            }

            this.Count--;
            return removedElement;
        }

        public T RemoveLast()
        {
            this.IsListEmpty();
            T removedElement = this.tail.Value;

            this.tail = this.tail.PreviosNode;
            if (this.tail != null)
            {
                this.tail.NextNode = null;
            }
            else
            {
                this.tail = null;
            }

            this.Count--;
            return removedElement;
        }

        public void ForEach(Action<T> filter)
        {
            this.IsListEmpty();

            var currentHead = this.head;
            while (currentHead != null)
            {
                filter(currentHead.Value);
                currentHead = currentHead.NextNode;
            }
        }

        public T[] ToArray()
        {
            var array = new T[this.Count];
            int index = 0;

            var currentHead = this.head;
            while (currentHead != null)
            {
                array[index++] = currentHead.Value;
                currentHead = currentHead.NextNode;
            }

            return array;
        }

        private void IsListEmpty()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("The list is empty!");
            }
        }

        private void AddHeadAndTail(T element)
        {
            this.head = this.tail = new ListNote<T>(element);
        }

        public IEnumerator<T> GetEnumerator()
        {
            var currentHead = this.head;
            while (currentHead != null)
            {
                yield return currentHead.Value;
                currentHead = currentHead.NextNode;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
