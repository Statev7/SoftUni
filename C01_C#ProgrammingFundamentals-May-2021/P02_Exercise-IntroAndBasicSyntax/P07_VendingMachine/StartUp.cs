namespace P07_VendingMachine
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            string commnad = Console.ReadLine().ToLower();
            double sum = 0;

            while (commnad != "start")
            {
                double coint = double.Parse(commnad);

                bool isCointValid = coint == 0.1 || coint == 0.2 || coint == 0.5 || coint == 1 || coint == 2;

                if (isCointValid)
                {
                    sum += coint;
                }
                else
                {
                    Console.WriteLine($"Cannot accept {coint}");
                }

                commnad = Console.ReadLine().ToLower();
            }

            while (true)
            {
                commnad = Console.ReadLine().ToLower();
                if (commnad == "end")
                {
                    break;
                }

                bool isProductExist = CheckIfTheProductExists(commnad);
                if (isProductExist)
                {
                    double productPrice = ProductPrice(commnad);

                    bool isThereEnoughMoney = CheckIfThereIsMoneyToBuyProduct(sum, productPrice);
                    if (isThereEnoughMoney)
                    {
                        sum -= productPrice;

                        Console.WriteLine($"Purchased {commnad}");
                    }
                    else
                    {
                        Console.WriteLine("Sorry, not enough money");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid product");
                }
            }

            Console.WriteLine($"Change: {sum:F2}");
        }

        private static bool CheckIfTheProductExists(string product)
        {
            bool isProductExist = product == "nuts" || 
                product == "water" || 
                product == "crisps" || 
                product == "soda" || 
                product == "coke";

            return isProductExist;
        }

        private static bool CheckIfThereIsMoneyToBuyProduct(double sum, double productsSum)
        {
            bool isValid = sum >= productsSum;

            return isValid;
        }

        private static double ProductPrice(string product)
        {
            const double NUTS_PRICE = 2.0;
            const double WATER_PRICE = 0.7;
            const double CRISPS_PRICE = 1.5;
            const double SODA_PRICE = 0.8;
            const double COKE_PRICE = 1.0;
            
            double productPrice = 0;

            switch (product)
            {
                case "nuts": productPrice = NUTS_PRICE; break;
                case "water": productPrice = WATER_PRICE; break;
                case "crisps": productPrice = CRISPS_PRICE; break;
                case "soda": productPrice = SODA_PRICE; break;
                case "coke": productPrice = COKE_PRICE; break;
            }

            return productPrice;
        }
    }
}
