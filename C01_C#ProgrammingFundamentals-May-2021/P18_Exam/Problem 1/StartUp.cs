namespace Problem_1
{
    using System;
    using System.Linq;

    public class StartUp
    {
        const string COFFEE_PRICE_MESSAGE = "The price for the coffee is: ${0:F2}";
        const string TOTAL_PRICE_MESSAGE = "Total: ${0:F2}";

        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            double[] totalAmount = new double[n]; 

            for (int index = 0; index < n; index++)
            {
                double price = double.Parse(Console.ReadLine());
                int days = int.Parse(Console.ReadLine());
                int capsulesCount = int.Parse(Console.ReadLine());

                bool isValid = days > 0 && days <= 31;
                if (isValid)
                {
                    double sum = Sum(price, days, capsulesCount);
                    string message = string.Format(COFFEE_PRICE_MESSAGE, sum);
                    Console.WriteLine(message);

                    totalAmount[index] += sum;
                }
            }

            PrintTotalAmount(totalAmount);
        }

        private static double Sum(double price, int days, int capsulesCount)
        {
            double sum = (days * capsulesCount) * price;

            return sum;
        }

        private static void PrintTotalAmount(double[] totalAmount)
        {
            double sum = totalAmount.Sum();
            string message = string.Format(TOTAL_PRICE_MESSAGE, sum);
            Console.WriteLine(message);
        }
    }
}
