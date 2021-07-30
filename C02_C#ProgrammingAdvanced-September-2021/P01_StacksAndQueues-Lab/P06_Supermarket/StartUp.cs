namespace P06_Supermarket
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        const string COMMAND_TO_STOP = "End";
        const string PAID_COMMAND = "Paid";
        const string RESULT_MESSAGE = "{0} people remaining.";

        public static void Main()
        {
            string command = Console.ReadLine();
            Queue<string> queue = new Queue<string>();

            while (command != COMMAND_TO_STOP)
            {
                if (command == PAID_COMMAND)
                {
                    while (queue.Count != 0)
                    {
                        Console.WriteLine(queue.Dequeue());
                    }
                }
                else
                {
                    queue.Enqueue(command);
                }

                command = Console.ReadLine();
            }

            Console.WriteLine(string.Format(RESULT_MESSAGE, queue.Count));
        }
    }
}
