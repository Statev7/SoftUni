namespace P03_RecursiveDrawing
{
    using System;

    public class StartUp
    {
        private const char UPPER_HALF_SYMBOL = '*';
        private const char BOTTOM_HALF_SYMBOL = '#';

        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            DrawFigure(n);
        }

        private static void DrawFigure(int n)
        {
            if (n == 0)
            {
                return;
            }

            Console.WriteLine(new string(UPPER_HALF_SYMBOL, n));
            DrawFigure(n - 1);

            Console.WriteLine(new string(BOTTOM_HALF_SYMBOL, n));
        }
    }
}
