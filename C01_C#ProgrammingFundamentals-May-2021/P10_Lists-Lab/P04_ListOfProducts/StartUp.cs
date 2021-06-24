namespace P04_ListOfProducts
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        public static void Main()
        {
            int countOfProducts = int.Parse(Console.ReadLine());
            List<string> allProducts = new List<string>();

            for (int product = 0; product < countOfProducts; product++)
            {
                string productName = Console.ReadLine();
                allProducts.Add(productName);
            }

            allProducts.Sort();
            PrintResult(allProducts);
        }

        private static void PrintResult(List<string> allProducts)
        {
            for (int index = 0; index < allProducts.Count; index++)
            {
                string result = $"{index + 1}.{allProducts[index]}";
                Console.WriteLine(result);
            }
        }
    }
}
