namespace P02_MatchPhoneNumber
{
    using System;
    using System.Text.RegularExpressions;

    public class StartUp
    {
        public static void Main()
        {
            string text = Console.ReadLine();
            string pattern = @"[+][359]+([-]|[ ])[2]\1\d{3}\1\d{4}\b";

            Regex regex = new Regex(pattern);
            var match = regex.Matches(text);

            Console.WriteLine(string.Join(", ", match));
        }
    }
}
