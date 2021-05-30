namespace P08_BeerKegs
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            double[] barrelsSum = new double[n];
            string[] modelName = new string[n];

            for (int i = 0; i < n; i++)
            {
                string model = Console.ReadLine();
                double radius = double.Parse(Console.ReadLine());
                int height = int.Parse(Console.ReadLine());

                double sum = Formula(radius, height);
                barrelsSum[i] += sum;
                modelName[i] += model;
            }

            string result = TheBiggestBarrel(barrelsSum, modelName);
            Console.WriteLine(result);
        }

        private static double Formula(double radius, int height)
        {
            double result = Math.PI * Math.Pow(radius, 2) * height;

            return result;
        }

        private static string TheBiggestBarrel(double[] barrelsSum, string[] modelName)
        {
            double max = 0;
            string model = string.Empty;

            for (int firstArrayIndex = 0; firstArrayIndex < barrelsSum.Length; firstArrayIndex++)
            {
                max = barrelsSum[firstArrayIndex];
                model = modelName[firstArrayIndex];

                for (int secondArrayIndex = 1; secondArrayIndex < barrelsSum.Length; secondArrayIndex++)
                {
                    if (barrelsSum[secondArrayIndex] > max)
                    {
                        max = barrelsSum[secondArrayIndex];
                        model = modelName[secondArrayIndex];
                    }
                }
            }

            return model;
        }

    }
}
