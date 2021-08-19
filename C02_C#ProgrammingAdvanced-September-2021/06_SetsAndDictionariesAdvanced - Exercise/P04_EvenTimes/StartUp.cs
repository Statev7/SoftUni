namespace P04_EvenTimes
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            var dictionary = new Dictionary<int, int>();

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                int num = int.Parse(Console.ReadLine());

                bool isNumExist = dictionary.ContainsKey(num);
                if (isNumExist == false)
                {
                    dictionary.Add(num, 0);
                }
                dictionary[num]++;
            }

            foreach (var num in dictionary
                .Where(x => x.Value % 2 == 0))
            {
                Console.WriteLine(num.Key);
            }
        }
    }
}
