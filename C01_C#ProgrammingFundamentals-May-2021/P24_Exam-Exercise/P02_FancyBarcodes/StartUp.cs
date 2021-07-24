namespace P02_FancyBarcodes
{
    using System;
    using System.Text;
    using System.Text.RegularExpressions;

    public class StartUp
    {
        const string PATTERN = @"@#+(?<barcode>[A-Z][A-Za-z0-9]{4,}[A-Z])@#+";
        const string DIGIT_PATTERN = @"\d+";
        const string INVALID_BARCODE_ERROR_MESSAGE = "Invalid barcode";
        const string DEFAULT_GROUP_MESSAGE = "Product group: 00";
        const string GROUP_MESSAGE = "Product group: {0}";

        public static void Main()
        {
            StringBuilder str = new StringBuilder();
            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                string input = Console.ReadLine();

                var regex = new Regex(PATTERN);
                var match = regex.Match(input);

                if (match.Success)
                {
                    string barcode = match.Groups["barcode"].Value;

                    var digitRegex = new Regex(DIGIT_PATTERN);
                    var digitMatch = digitRegex.Matches(barcode);
                    if (digitMatch.Count > 0)
                    {
                        string result = FindProductGroup(digitMatch);
                        str.AppendLine(string.Format(GROUP_MESSAGE, result));
                    }
                    else
                    {
                        str.AppendLine(DEFAULT_GROUP_MESSAGE);
                    }
                }
                else
                {
                    str.AppendLine(INVALID_BARCODE_ERROR_MESSAGE);
                }
            }

            Console.WriteLine(str);
        }

        private static string FindProductGroup(MatchCollection digitMatch)
        {
            string result = string.Empty;

            for (int index = 0; index < digitMatch.Count; index++)
            {
                result += digitMatch[index];
            }

            return result;
        }

    }
}
