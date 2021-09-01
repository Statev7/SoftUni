namespace BoxOfT
{
    using System.Collections.Generic;

    public class Box<T>
    {
        private Stack<T> date;

        public Box()
        {
            this.date = new Stack<T>();
        }

        public int Count 
        { 
            get
            {
                return this.date.Count;
            }
        }

        public void Add(T element)
        {
            this.date.Push(element);
        }

        public T Remove()
        {
            return this.date.Pop();
        }
    }
}
