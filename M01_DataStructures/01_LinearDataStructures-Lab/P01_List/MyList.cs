namespace P01_List
{
    using System;

    public class MyList<TEntity>
    {
        private TEntity[] date;

        public MyList(int capacity = 4)
        {
            this.date = new TEntity[capacity];
        }

        public int Count { get; private set; }

        public TEntity this[int i]
        {
            get
            {
                this.ValidateIndex(i);
                return this.date[i];
            }
            set
            {
                this.ValidateIndex(i);
                this.date[i] = value;
            }
        }

        public void Add(TEntity element)
        {
            this.GrowIfNecessary();

            this.date[this.Count++] = element;
        }

        public void Insert(int index, TEntity element)
        {
            this.ValidateIndex(index);
            this.GrowIfNecessary();

            for (int i = this.Count; i > index; i--)
            {
                this.date[i] = this.date[i - 1];
            }

            this.date[index] = element;
            this.Count++;
        }

        public void RemoveAt(int index)
        {
            this.ValidateIndex(index);

            for (int i = index; i < this.Count - 1; i++)
            {
                this.date[i] = this.date[i + 1];
            }

            this.date[this.Count--] = default;
        }

        public bool Contains(TEntity item)
        {
            for (int i = 0; i < this.Count; i++)
            {
                bool isEqual = this.date[i].Equals(item);
                if (isEqual)
                {
                    return true;
                }
            }

            return false;
        }

        public int IndexOf(TEntity item)
        {
            bool isItemExist = this.Contains(item);
            if (isItemExist)
            {
                for (int i = 0; i < this.Count; i++)
                {
                    bool isEqual = this.date[i].Equals(item);
                    if (isEqual)
                    {
                        return i;
                    }
                }
            }

            return -1;
        }

        public bool Remove(TEntity entity)
        {
            int indexOf = this.IndexOf(entity);

            if (indexOf != -1)
            {
                for (int i = indexOf; i < this.Count; i++)
                {
                    this.date[i] = this.date[i + 1];
                }

                this.date[this.Count--] = default;

                return true;
            }

            return false;
        }

        private void GrowIfNecessary()
        {
            if (this.date.Length == this.Count)
            {
                this.Grow();
            }
        }

        private void ValidateIndex(int index)
        {
            if (index >= this.Count || index < 0)
            {
                throw new IndexOutOfRangeException();
            }
        } 

        private void Grow()
        {
            TEntity[] newArr = new TEntity[this.date.Length * 2];
            for (int i = 0; i < this.date.Length; i++)
            {
                newArr[i] = this.date[i];
            }

            this.date = newArr;
        }
    }
}
