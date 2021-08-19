namespace P08_TrafficJam
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        const string COMMAND_TO_STOP = "end";
        const string COMMAND_TO_PASS = "green";
        const string RESULT_MESSAGE = "{0} cars passed the crossroads.";

        public static void Main()
        {
            int carPassCount = int.Parse(Console.ReadLine());
            Queue<string> cars = new Queue<string>();
            int count = 0;

            string command = Console.ReadLine();
            while (command != COMMAND_TO_STOP)
            {
                if (command == COMMAND_TO_PASS)
                {
                    for (int i = 0; i < carPassCount; i++)
                    {
                        if (cars.Count > 0)
                        {
                            Console.WriteLine($"{cars.Dequeue()} passed!");
                            count++;
                        }
                    }
                }
                else
                {
                    cars.Enqueue(command);
                }

                command = Console.ReadLine();
            }

            Console.WriteLine(string.Format(RESULT_MESSAGE, count));
        }
    }
}
