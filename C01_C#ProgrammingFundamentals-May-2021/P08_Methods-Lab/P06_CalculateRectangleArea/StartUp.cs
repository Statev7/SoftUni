namespace P06_CalculateRectangleArea
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            double width = double.Parse(Console.ReadLine());
            double height = double.Parse(Console.ReadLine());

            double area = GetRectangleArea(width, height);
            PrintArea(area);
        }

        private static double GetRectangleArea(double width, double height)
        {
            double area = width * height;
            return area;
        }

        private static void PrintArea(double area)
        {
            Console.WriteLine(area);
        }
    }
}
