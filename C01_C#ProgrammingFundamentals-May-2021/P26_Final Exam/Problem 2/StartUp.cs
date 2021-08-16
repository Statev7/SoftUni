namespace Problem_2
{
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    public class StartUp
    {
        const string PATTERN = @"^([$]|[%])(?<tag>[A-Z][a-z]{2,})\1[:] \[(?<firstNum>\d+)\]\|\[(?<secondNum>\d+)\]\|\[(?<thirdNum>\d+)\]\|$";
        const string VALID_MESSAGE_NOT_FOUND_ERROR_MESSAGE = "Valid message not found!";

        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            Regex regex = new Regex(PATTERN);

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                var match = regex.Match(input);
                if (match.Success)
                {
                    int firstNum = int.Parse(match.Groups["firstNum"].Value);
                    int secondNum = int.Parse(match.Groups["secondNum"].Value);
                    int thirdNum = int.Parse(match.Groups["thirdNum"].Value);

                    List<int> allNumbers = new List<int>()
                    {
                        firstNum, 
                        secondNum, 
                        thirdNum
                    };

                    string tag = match.Groups["tag"].Value;
                    string decryptedMessage = Decrypt(allNumbers);
                    Console.WriteLine($"{tag}: {decryptedMessage}");
                }
                else
                {
                    Console.WriteLine(VALID_MESSAGE_NOT_FOUND_ERROR_MESSAGE);
                }
            }
        }

        private static string Decrypt(List<int> str)
        {
            string result = string.Empty;
            for (int index = 0; index < str.Count; index++)
            {
                result += (char)str[index];
            }

            return result;
        }
    }
}
