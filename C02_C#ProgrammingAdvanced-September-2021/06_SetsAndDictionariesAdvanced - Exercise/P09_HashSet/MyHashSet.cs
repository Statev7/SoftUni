namespace P09_HashSet
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class MyHashSet<T>
    {
        private List<T>[] array;
        private int size = 0;

        public MyHashSet(int capacity=8)
        {
            size = capacity * 4;
            array = new List<T>[size];
        }

        public void Add(T element)
        {
            int index = HeshFunction(element.ToString());
            if (array[index] == null)
            {
                array[index] = new List<T>();
                array[index].Add(element);
            }
            else
            {
                bool isAlredyIn = this.Contains(element);
                if (isAlredyIn == false)
                {
                    array[index].Add(element);
                }
            }
        }

        public void Remove(T element)
        {
            int index = HeshFunction(element.ToString());
            if (array[index] != null)
            {
                for (int i = 0; i < array[index].Count(); i++)
                {
                    if (Equals(element, array[index][i]))
                    {
                        array[index].Remove(element);
                        break;
                    }
                }
            }
        }

        public bool Contains(T element)
        {
            int index = HeshFunction(element.ToString());
            if (array[index] != null)
            {
                for (int i = 0; i < array[index].Count(); i++)
                {
                    if (Equals(element, array[index][i]))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public int HeshFunction(string element)
        {
            int index = Math.Abs(element.GetHashCode() % array.Length);
            return index;
        }
    }
}
