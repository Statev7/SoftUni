namespace P05_AdAstra
{
    using System;
    using System.Text.RegularExpressions;

    public class StartUp
    {
        const int NEED_KCAL_PER_DAY = 2000;

        const string PATTERN = @"([#]|[|])(?<item>[A-z\s]+)\1(?<expirationdate>\d{2}\/\d{2}\/\d{2})\1(?<calories>\d+)\1";

        public static void Main()
        {
            string input = Console.ReadLine();
            int calories = 0;
            int days = 0;

            Regex regex = new Regex(PATTERN);
            var matches = regex.Matches(input);
            calories = CaloriesSum(calories, matches);
            days = NeedDays(calories, days);
            PrintResult(days, matches);
        }

        private static int CaloriesSum(int calories, MatchCollection matches)
        {
            for (int index = 0; index < matches.Count; index++)
            {
                calories += int.Parse(matches[index].Groups["calories"].Value);
            }

            return calories;
        }

        private static int NeedDays(int calories, int days)
        {
            while (calories >= NEED_KCAL_PER_DAY)
            {
                days++;
                calories -= NEED_KCAL_PER_DAY;
            }

            return days;
        }

        private static void PrintResult(int days, MatchCollection matches)
        {
            Console.WriteLine($"You have food to last you for: {days} days!");
            foreach (Match food in matches)
            {
                string foodName = food.Groups["item"].Value;
                string date = food.Groups["expirationdate"].Value;
                string calorie = food.Groups["calories"].Value;

                Console.WriteLine($"Item: {foodName}, Best before: {date}, Nutrition: {calorie}");
            }
        }
    }
}
