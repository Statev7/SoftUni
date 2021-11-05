using System;

namespace P01_SquareRoot
{
    public class StartUp
    {
        public static void Main()
        {
            double number = 0;

            try
            {
                number = double.Parse(Console.ReadLine());
                if (number <= 0)
                {
                    throw new ArgumentException("Invalid number");
                }

                Console.WriteLine(Math.Sqrt(number));
            }
            catch (Exception ae)
            {
                Console.WriteLine(ae.Message);
            }
            finally
            {
                Console.WriteLine("Goodbye");
            }
        }
    }
}
