namespace CustomRandomList
{
    using System;
    using System.Collections.Generic;

    public class RandomList : List<string>
    {
        public string RandomString()
        {
            var random = new Random();
            var index = random.Next(0, this.Count);
            var element = this[index];
            this.RemoveAt(index);

            return element;
        }
    }
}
