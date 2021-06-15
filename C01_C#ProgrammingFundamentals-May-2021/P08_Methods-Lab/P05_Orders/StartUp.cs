namespace P05_Orders
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            string products = Console.ReadLine();
            int count = int.Parse(Console.ReadLine());

            double price = ProductPrice(products);
            double sum = SumOfProducts(count, price);
            PrintResult(sum);
        }

        private static double ProductPrice(string product)
        {
            const double COFFEE_PRICE = 1.50;
            const double WATER_PRICE = 1.00;
            const double COKE_PRICE = 1.40;
            const double SNACKS_PRICE = 2.00;

            double productPrice = 0;

            switch (product)
            {
                case "coffee": productPrice = COFFEE_PRICE; break;
                case "water": productPrice = WATER_PRICE; break;
                case "coke": productPrice = COKE_PRICE; break;
                case "snacks": productPrice = SNACKS_PRICE; break;
            }

            return productPrice;
        }

        private static double SumOfProducts(int count, double price)
        {
            double sum = count * price;
            return sum;
        }

        private static void PrintResult(double sum)
        {
            string result = $"{sum:F2}";
            Console.WriteLine(result);
        }
    }
}
