namespace P04_Orders
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        const string COMMAND_TO_STOP = "buy";

        public static void Main()
        {
            var products = new Dictionary<string, Item>();

            while (true)
            {
                string arguments = Console.ReadLine();

                bool isStopCommand = arguments == COMMAND_TO_STOP;
                if (isStopCommand)
                {
                    Print(products);
                    break;
                }

                string[] argumentsAsArray = arguments
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string productName = argumentsAsArray[0];
                decimal price = decimal.Parse(argumentsAsArray[1]);
                int quantity = int.Parse(argumentsAsArray[2]);

                AddProduct(products, productName, price, quantity);
            }
        }

        private static void AddProduct(Dictionary<string, Item> products, string productName, decimal price, int quantity)
        {
            bool isProductExist = products.ContainsKey(productName);
            if (isProductExist)
            {
                products[productName].UpdateQuantityAndPrice(price, quantity);
            }
            else
            {
                Item item = new Item(price, quantity);
                products.Add(productName, item);
            }
        }

        private static void Print(Dictionary<string, Item> products)
        {
            foreach (var product in products)
            {
                decimal sum = product.Value.Price * product.Value.Quantity;
                Console.WriteLine($"{product.Key} -> {sum:F2}");
            }
        }
    }

    public class Item
    {
        public Item(decimal price, int quantity)
        {
            this.Price = price;
            this.Quantity = quantity;
        }

        public decimal Price { get; private set; }

        public int Quantity { get; private set; }

        public void SetQuantityAndPrice(decimal price, int quantity)
        {
            this.Price = price;
            this.Quantity = quantity;
        }

        public void UpdateQuantityAndPrice(decimal price, int newQuantity)
        {
            this.Quantity += newQuantity;
            this.Price = price;
        }
    }
}

