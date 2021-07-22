namespace P01_MatchFullName
{
    using System;
    using System.Text.RegularExpressions;

    public class StartUp
    {
        public static void Main()
        {
            string text = Console.ReadLine();
            string pattern = @"\b[A-Z][a-z]+ [A-Z][a-z]+";

            Regex regex = new Regex(pattern);

            var match = regex.Matches(text);

            Console.WriteLine(string.Join(" ", match));
        }
    }
}
