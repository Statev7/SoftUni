namespace P01_GenericBoxOfString
{
    using System;

    class StartUp
    {
        public static void Main()
        {
            var box = new Box<string>();

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine();
                box.Add(input);
            }

            Console.WriteLine(box);
        }
    }
}
