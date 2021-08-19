namespace P03_ProductShop
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        const string COMMAND_TO_STOP = "Revision";

        public static void Main()
        {
            
            var allShops = new Dictionary<string, Dictionary<string, double>>();

            string input = Console.ReadLine();
            while (input != COMMAND_TO_STOP)
            {
                var arg = input
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries);

                string shop = arg[0];
                string product = arg[1];
                double price = double.Parse(arg[2]);

                bool isShopExist = allShops.ContainsKey(shop);
                if (isShopExist == false)
                {
                    allShops.Add(shop, new Dictionary<string, double>());
                }
                allShops[shop].Add(product, price);

                input = Console.ReadLine();
            }

            foreach (var shop in allShops
                .OrderBy(x => x.Key))
            {
                Console.WriteLine($"{shop.Key}->");
                foreach (var product in shop.Value)
                {
                    Console.WriteLine($"Product: {product.Key}, Price: {product.Value}");
                }
            }
        }
    }
}
