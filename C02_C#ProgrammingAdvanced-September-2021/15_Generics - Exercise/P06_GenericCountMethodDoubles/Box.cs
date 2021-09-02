namespace P06_GenericCountMethodDoubles
{
    using System;
    using System.Collections.Generic;

    public class Box
    {
        public int GreaterElementsCount<T>(List<T> list, T elementToCompare) 
            where T : IComparable
        {
            int count = 0;

            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].CompareTo(elementToCompare) > 0)
                {
                    count++;
                }
            }

            return count;
        }
    }
}
