namespace P03_CharactersInRange
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            char start = char.Parse(Console.ReadLine());
            char end = char.Parse(Console.ReadLine());

            PrintCharactersInRange(start, end);
        }

        private static void PrintCharactersInRange(char start, char end)
        {
            if (start > end)
            {
                for (char postion = end; postion < start; postion++)
                {
                    if (postion != end)
                    {
                        Console.Write(postion.ToString() + ' ');
                    }
                }
            }
            else
            {
                for (char postion = start; postion < end; postion++)
                {
                    if (postion != start)
                    {
                        Console.Write(postion.ToString() + ' ');
                    }
                }
            }
        }
    }
}
