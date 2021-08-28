namespace P01_ImplementationList
{
    using System;

    public class MyList<T>
    {
        private T[] date;
        private int capacity;

        public MyList()
            :this(4)
        {

        }

        public MyList(int capacity)
        {
            this.date = new T[capacity];
            this.capacity = capacity;
        }

        public int Count { get; private set; }

        public void Add(T element)
        {
            this.Resize();

            this.date[this.Count] = element;

            this.Count++;
        }

        public void Remove(T element)
        {
            this.CheckDateIsEmpty();

            bool isElementCointains = Contains(element);
            if (!isElementCointains)
            {
                throw new Exception("Element not exist.");
            }

            int indexOfElement = IndexOf(element);
            this.RemoveElementLogic(indexOfElement);
        }

        public void RemoveAt(int index)
        {
            this.IsIndexValid(index);
            this.RemoveElementLogic(index);
        }

        public void Insert(int index, T element)
        {
            this.IsIndexValid(index);
            this.Resize();

            for (int i = this.Count; i > index; i--)
            {
                this.date[i] = this.date[i - 1];
            }

            this.date[index] = element;
            this.Count++;
        }

        public bool Contains(T element)
        {
            for (int index = 0; index < this.Count; index++)
            {
                if (this.date[index].Equals(element))
                {
                    return true;
                }
            }

            return false;
        }

        public int IndexOf(T element)
        {
            int index = -1;
            for (int i = 0; i < this.Count; i++)
            {
                if (this.date[i].Equals(element))
                {
                    index = i;
                }
            }

            return index;
        }

        public void Swap(int firstIndex, int secondIndex)
        {
            this.IsSwapIndexValid(firstIndex);
            this.IsSwapIndexValid(secondIndex);

            var firstValue = this.date[firstIndex];
            this.date[firstIndex] = this.date[secondIndex];
            this.date[secondIndex] = firstValue;
        }

        public void Clear()
        {
            this.date = new T[this.capacity];
            this.Count = 0;
        }

        public T this[int index]
        {
            get
            {
                this.IsIndexValid(index);
                return this.date[index];
            }
            set
            {
                this.IsIndexValid(index);
                this.date[index] = value;
            }
        }

        private void Resize()
        {
            if (this.Count == this.date.Length)
            {
                var newDate = new T[capacity * 2];

                for (int index = 0; index < this.Count; index++)
                {
                    newDate[index] = this.date[index];
                }

                this.date = newDate;
            }
        }

        private void RemoveElementLogic(int startIndex)
        {
            for (int index = startIndex; index < this.Count - 1; index++)
            {
                this.date[index] = this.date[index + 1];
            }

            this.date[this.Count - 1] = default;
            this.Count--;
        }

        private void CheckDateIsEmpty()
        {
            if (this.Count == 0)
            {
                throw new Exception("The list is empty.");
            }
        }

        private void IsIndexValid(int index)
        {
            bool isIndexValid = index >= 0 && this.date.Length > index;
            if (!isIndexValid)
            {
                throw new Exception("Invalid index");
            }
        }

        private void IsSwapIndexValid(int index)
        {
            bool isValid = this.Count > index && index >= 0;
            if (!isValid)
            {
                throw new Exception("Cannot swap a value with one that is the default");
            }
        }
    }
}
