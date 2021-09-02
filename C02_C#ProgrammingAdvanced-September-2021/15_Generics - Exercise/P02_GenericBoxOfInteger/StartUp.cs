namespace P02_GenericBoxOfInteger
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            var box = new Box<int>();

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                var input = int.Parse(Console.ReadLine());
                box.Add(input);
            }

            Console.WriteLine(box);
        }
    }
}
