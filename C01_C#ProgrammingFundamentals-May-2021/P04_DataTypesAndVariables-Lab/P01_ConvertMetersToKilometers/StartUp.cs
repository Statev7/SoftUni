namespace P01_ConvertMetersToKilometers
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            double meters = double.Parse(Console.ReadLine());
            double result = ConverToKilometers(meters);

            Console.WriteLine($"{result:F2}");
        }

        private static double ConverToKilometers(double meters)
        {
            meters *= 0.001;

            return meters;
        } 
    }
}
