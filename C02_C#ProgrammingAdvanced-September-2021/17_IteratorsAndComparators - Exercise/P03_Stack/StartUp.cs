namespace P03_Stack
{
    using System;
    using System.Linq;

    public class StartUp
    {
        private const string COMMAND_TO_STOP_READ_INPUT = "END";

        public static void Main()
        {
            var date = Console.ReadLine()
                .Split(new[] { ", ", " " }, StringSplitOptions.RemoveEmptyEntries);

            var mystack = new MyStack<string>();

            for (int i = 1; i < date.Length; i++)
            {
                mystack.Push(date[i]);
            }

            string input = Console.ReadLine();
            while (input != COMMAND_TO_STOP_READ_INPUT)
            {
                var splited = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string command = splited[0];
                switch (command)
                {
                    case "Push": mystack.Push(splited[1]); break;
                    case "Pop": mystack.Pop(); break;
                }

                input = Console.ReadLine();
            }

            foreach (var item in mystack)
            {
                Console.WriteLine(item);
            }
        }
    }
}
