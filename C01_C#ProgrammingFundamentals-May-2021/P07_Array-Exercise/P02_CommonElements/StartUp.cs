namespace P02_CommonElements
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            string[] firstArray = Console.ReadLine().Split(' ').ToArray();
            string[] secondArray = Console.ReadLine().Split(' ').ToArray();
            List<string> result = new List<string>();

            for (int secArrIndex = 0; secArrIndex < secondArray.Length; secArrIndex++)
            {
                for (int firstArrIndex = 0; firstArrIndex < firstArray.Length; firstArrIndex++)
                {
                    if (secondArray[secArrIndex] == firstArray[firstArrIndex])
                    {
                        result.Add(firstArray[firstArrIndex]);
                        break;
                    }
                }
            }

            Console.WriteLine(string.Join(' ', result));
        }
    }
}
