namespace P07_SecretChat
{
    using System;
    using System.Linq;

    public class StartUp
    {
        const string COMMAND_TO_STOP = "Reveal";
        const string RESULT_MESSAGE = "You have a new text message: {0}";

        public static void Main()
        {
            string input = Console.ReadLine();

            while (true)
            {
                string[] arg = Console.ReadLine()
                    .Split(":|:", StringSplitOptions.RemoveEmptyEntries);

                bool isStopCommand = arg[0] == COMMAND_TO_STOP;
                if (isStopCommand)
                {
                    PrintResult(input);
                    break;
                }

                string command = arg[0];
                string substring = string.Empty;

                switch (command)
                {
                    case "InsertSpace":
                        int index = int.Parse(arg[1]);
                        input = InsertSpace(input, index);
                        break;
                    case "Reverse":
                        substring = arg[1];
                        input = Reverse(input, substring);
                        break;
                    case "ChangeAll":
                        substring = arg[1];
                        string replacement = arg[2];
                        input = ChangeAll(input, substring, replacement);
                        break;
                }
            }
        }

        private static string InsertSpace(string input, int index)
        {
            input = input.Insert(index, " ");
            PrintStringAfterOperation(input);

            return input;
        }

        private static string Reverse(string input, string substring)
        {
            string reversedSubstringAsString = string.Empty;

            bool isSubstringExist = input.Contains(substring);
            if (isSubstringExist)
            {
                int index = input.IndexOf(substring);
                input = input.Remove(index, substring.Length);

                char[] reversedSubstring = substring.Reverse().ToArray();
                for (int i = 0; i < reversedSubstring.Length; i++)
                {
                    reversedSubstringAsString += reversedSubstring[i];
                }

                input += reversedSubstringAsString;
                PrintStringAfterOperation(input);
            }
            else
            {
                Console.WriteLine("error");
            }

            return input;
        }

        private static string ChangeAll(string input, string substring, string replacement)
        {
            int index = input.IndexOf(substring);
            while (index != -1)
            {
                input = input.Replace(substring, replacement);

                index = input.IndexOf(substring);
            }
            PrintStringAfterOperation(input);

            return input;
        }

        private static void PrintStringAfterOperation(string str)
        {
            Console.WriteLine(str);
        }

        private static void PrintResult(string str)
        {
            Console.WriteLine(string.Format(RESULT_MESSAGE, str));
        }
    }
}
