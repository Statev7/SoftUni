namespace P07_WaterOverflow
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            const int TANK_CAPACITY_VALUE = 255;

            int n = int.Parse(Console.ReadLine());

            int liters = 0;
            int litersInTank = 0;

            for (int i = 0; i < n; i++)
            {
                int litersOfWater = int.Parse(Console.ReadLine());

                liters += litersOfWater;

                bool isValid = liters > TANK_CAPACITY_VALUE;
                if (isValid)
                {
                    Console.WriteLine("Insufficient capacity!");
                    liters -= litersOfWater;
                }
                else
                {
                    litersInTank += litersOfWater;
                }

            }

            Console.WriteLine(litersInTank);
        }
    }
}
