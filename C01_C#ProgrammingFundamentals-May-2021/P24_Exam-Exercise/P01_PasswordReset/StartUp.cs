namespace P01_PasswordReset
{
    using System;
    using System.Linq;

    public class StartUp
    {
        const string COMMAND_TO_STOP = "Done";
        const string SUBSTRING_NOT_EXIST_MESSAGE = "Nothing to replace!";
        const string RESULT_MESSAGE = "Your password is: {0}";

        public static void Main()
        {
            string input = Console.ReadLine();

            while (true)
            {
                string[] arguments = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                bool isStopCommnad = arguments[0] == COMMAND_TO_STOP;
                if (isStopCommnad)
                {
                    PrintResult(input);
                    break;
                }

                string command = arguments[0];

                switch (command)
                {
                    case "TakeOdd": input = TakeOdd(input); break;
                    case "Cut":
                        int startIndex = int.Parse(arguments[1]);
                        int lenght = int.Parse(arguments[2]);
                        input = Cut(input, startIndex, lenght);
                        break;
                    case "Substitute":
                        input = Substitute(input, arguments[1], arguments[2]);
                        break;
                }
            }
        }

        private static string TakeOdd(string str)
        {
            string result = string.Empty;

            for (int index = 0; index < str.Length; index++)
            {
                if (index % 2 != 0)
                {
                    result += str[index];
                }
            }

            PrintPasswordAfterOperation(result);
            return result;
        }

        private static string Cut(string str, int startIndex, int lenght)
        {
            str = str.Remove(startIndex, lenght);
            PrintPasswordAfterOperation(str);

            return str;
        }

        private static string Substitute(string str, string substring, string substitute)
        {
            bool isSubstringExist = str.Contains(substring);

            if (isSubstringExist == false)
            {
                PrintPasswordAfterOperation(SUBSTRING_NOT_EXIST_MESSAGE);
            }
            else
            {
                str = str.Replace(substring, substitute);
                PrintPasswordAfterOperation(str);
            }

            return str;
        }

        private static void PrintPasswordAfterOperation(string str)
        {
            Console.WriteLine(str);
        }

        private static void PrintResult(string str)
        {
            Console.WriteLine(string.Format(RESULT_MESSAGE, str));
        }
    }
}
