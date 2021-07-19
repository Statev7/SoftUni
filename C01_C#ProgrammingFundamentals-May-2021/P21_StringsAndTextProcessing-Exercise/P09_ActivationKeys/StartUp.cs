namespace P09_ActivationKeys
{
    using System;

    public class StartUp
    {
        const string COMMAND_TO_STOP = "Generate";

        public static void Main()
        {
            string input = Console.ReadLine();

            while (true)
            {
                string arguments = Console.ReadLine();

                bool isStopCommnad = arguments == COMMAND_TO_STOP;
                if (isStopCommnad)
                {
                    break;
                }

                string[] splitedArguments = arguments
                    .Split(">>>", StringSplitOptions.RemoveEmptyEntries);

                string command = splitedArguments[0];
                int startIndex = 0;
                int endIndex = 0;

                switch (command)
                {
                    case "Contains":
                        string substring = splitedArguments[1];
                        Contains(input, substring);
                        break;
                    case "Flip":
                        string caseToConver = splitedArguments[1];
                        startIndex = int.Parse(splitedArguments[2]);
                        endIndex = int.Parse(splitedArguments[3]);
                        input = Flip(input, caseToConver, startIndex, endIndex);
                        break;
                    case "Slice":
                        startIndex = int.Parse(splitedArguments[1]);
                        endIndex = int.Parse(splitedArguments[2]);
                        input = Slice(input, startIndex, endIndex);
                        break;
                }
            }

            Console.WriteLine($"Your activation key is: {input}");
        }

        private static void Contains(string str, string substring)
        {
            string result = "Substring not found!";

            bool isExist = str.Contains(substring);
            if (isExist)
            {
                result = $"{str} contains {substring}";
            }

            Console.WriteLine(result);
        }

        private static string Flip(string str, string caseToConvert, int startIndex, int endIndex)
        {
            string substringToReplays = string.Empty;
            string newString = string.Empty;
            int subtringToReplaceLength = endIndex - startIndex;

            if (caseToConvert == "Upper")
            {
                substringToReplays = str.Substring(startIndex, subtringToReplaceLength);
                newString = substringToReplays.ToUpper();
                str = str.Replace(substringToReplays, newString);
            }
            else
            {
                substringToReplays = str.Substring(startIndex, subtringToReplaceLength);
                newString = substringToReplays.ToLower();
                str = str.Replace(substringToReplays, newString);
            }

            Console.WriteLine(str);
            return str;
        }

        private static string Slice(string str, int startIndex, int endIndex)
        {
            int count = endIndex - startIndex;
            str = str.Remove(startIndex, count);
            Console.WriteLine(str);
            return str;
        }
    }
}
