namespace P01_ListyIterator
{
    using System;
    using System.Linq;

    public class StartUp
    {
        private const string COMMAND_TO_STOP_READ_ARG = "END";

        public static void Main()
        {
            string input = Console.ReadLine();
            var inputToList = input
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Skip(1)
                .ToList();

            var list = new ListyIterator<string>(inputToList);

            while (input != COMMAND_TO_STOP_READ_ARG)
            {
                input = Console.ReadLine();

                var splited = input
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string command = splited[0];
                switch (command)
                {
                    case "Move": Console.WriteLine(list.Move()); break;
                    case "HasNext": Console.WriteLine(list.HasNext()); break;
                    case "Print": list.Print(); break;
                }
            }
        }
    }
}
