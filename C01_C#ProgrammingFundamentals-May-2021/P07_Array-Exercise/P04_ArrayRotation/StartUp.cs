namespace P04_ArrayRotation
{
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            int[] array = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int rotation = int.Parse(Console.ReadLine());
            int temp = 0;

            for (int index = 0; index < rotation; index++)
            {
                for (int secondIndex = 0; secondIndex < array.Length; secondIndex++)
                {
                    if (secondIndex == 0)
                    {
                        temp = array[0];
                    }

                    if (secondIndex + 1 < array.Length)
                    {
                        array[secondIndex] = array[secondIndex + 1];
                    }
                    else
                    {
                        array[array.Length - 1] = temp;
                    }
                }
            }

            Console.WriteLine(string.Join(' ', array));
        }
    }
}
