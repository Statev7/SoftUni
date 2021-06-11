namespace P07_EqualArrays
{
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            int[] firstArray = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int[] secondArray = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            string result = "Arrays are not identical. Found difference at {0} index";
            int sum = 0;
            bool isBreak = false;

            for (int index = 0; index < firstArray.Length; index++)
            {
                if (firstArray[index] != secondArray[index])
                {
                    result = string.Format(result, index);
                    isBreak = true;
                    break;
                }
                else
                {
                    sum += firstArray[index];
                }

            }

            if (isBreak == false)
            {
                result = $"Arrays are identical. Sum: {sum}";
            }

            Console.WriteLine(result);
        }
    }
}
