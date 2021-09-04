namespace P04_Froggy
{
    using System.Collections;
    using System.Collections.Generic;

    public class Lake : IEnumerable<int>
    {
        private int[] date;

        public Lake(int[] array)
        {
            this.date = array;
        }

        public IEnumerator<int> GetEnumerator()
        {
            for (int i = 0; i < this.date.Length; i++)
            {
                if (i % 2 == 0)
                {
                    yield return this.date[i];
                }
            }

            for (int i = this.date.Length - 1; i >= 0; i--)
            {
                if (i % 2 != 0)
                {
                    yield return this.date[i];
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
