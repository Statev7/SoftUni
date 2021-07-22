namespace P01_Furniture
{
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    public class StartUp
    {
        const string COMMAND_TO_STOP = "Purchase";
        const string PATTERN = @">>(?<name>[A-Za-z]+)<<(?<price>\d+(.\d+)?)!(?<quantity>\d+)";

        static void Main()
        {
            List<string> result = new List<string>();
            double finalSum = 0;

            while (true)
            {
                string input = Console.ReadLine();

                bool isStopCommand = input == COMMAND_TO_STOP;
                if (isStopCommand)
                {
                    break;
                }

                Regex regex = new Regex(PATTERN);
                var matches = regex.Matches(input);

                foreach (Match item in matches)
                {
                    string name = item.Groups["name"].Value;
                    double price = double.Parse(item.Groups["price"].Value);
                    int quantity = int.Parse(item.Groups["quantity"].Value);

                    finalSum += price * quantity;
                    result.Add(name);
                }
            }

            Console.WriteLine("Bought furniture:");
            if (result.Count > 0)
            {
                Console.WriteLine(string.Join(Environment.NewLine, result));
            }
            Console.WriteLine($"Total money spend: {finalSum:F2}");
        }
    }
}
