namespace P02_Collection
{
    using System;
    using System.Linq;

    public class StartUp
    {
        private const string COMMAND_TO_STOP_READ_INPUT = "END";

        public static void Main()
        {
            ListyIterator<string> collection = null;

            string input = Console.ReadLine();
            while (input != COMMAND_TO_STOP_READ_INPUT)
            {
                var splited = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string command = splited[0];

                switch (command)
                {
                    case "Create": 
                        var date = splited.Skip(1).ToList();
                        collection = new ListyIterator<string>(date);
                        break;
                    case "Move": Console.WriteLine(collection.Move()); break;
                    case "HasNext": Console.WriteLine(collection.HasNext()); break;
                    case "Print": Console.WriteLine(collection.Print()); break;
                    case "PrintAll":
                        foreach (var item in collection)
                        {
                            Console.Write(item + " ");
                        }
                        Console.WriteLine();
                        break;
                }

                input = Console.ReadLine();
            }
        }
    }
}
