namespace P07_TruckTour
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            Queue<string> queue = new Queue<string>();
            int totalFuel = 0;

            for (int i = 0; i < n; i++)
            {
                string pump = Console.ReadLine();
                pump += $" {i}";
                queue.Enqueue(pump);
            }

            for (int i = 0; i < queue.Count; i++)
            {
                string curruntPump = queue.Dequeue();
                int[] splitedPump = curruntPump
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                int fuel = splitedPump[0];
                int distance = splitedPump[1];
                totalFuel += fuel;

                if (totalFuel >= distance)
                {
                    totalFuel -= distance;
                }
                else
                {
                    i = -1;
                    totalFuel = 0;
                }

                queue.Enqueue(curruntPump);
            }

            string startPumpInfo = queue.Dequeue();
            string index = startPumpInfo
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)[2];

            Console.WriteLine(index);
        }
    }
}
