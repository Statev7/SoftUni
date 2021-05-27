namespace P03_Vacation
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            int groupCount = int.Parse(Console.ReadLine());
            string groupType = Console.ReadLine().ToLower();
            string day = Console.ReadLine().ToLower();

            double price;
            double sum = 0;

            if (groupType == "students")
            {
                price = PriceAboutDay(day, Constants.STUDENT_FRIDAY_PRICE, Constants.STUDENT_SATURDAY_PRICE, Constants.STUDENT_SUNDAY_PRICE);

                sum = price * groupCount;

                bool isGroupCountMoreOrEqualsThatThirty = groupCount >= Constants.STUDENTS_DISCOUNT_FOR_A_GROUP;
                if (isGroupCountMoreOrEqualsThatThirty)
                {
                    sum = sum - (sum * Constants.STUDENTS_DISCOUNT_PERCENTAGE);
                }
            }
            else if (groupType == "business")
            {
                price = PriceAboutDay(day, Constants.BUSINESS_FRIDAY_PRICE, Constants.BUSINESS_SATURDAY_PRICE, Constants.BUSINESS_SUNDAY_PRICE);

                sum = price * groupCount;

                bool isGroupCountMoreOrEquelsThatHundred = groupCount >= Constants.BUSINESS_COUNT_FOR_A_FREE;
                if (isGroupCountMoreOrEquelsThatHundred)
                {
                    sum = sum - (price * Constants.BUSINESS_FREE_PLACES);
                }
            }
            else
            {
                price = PriceAboutDay(day, Constants.REGULAR_FRIDAY_PRICE, Constants.REGULAR_SATURDAY_PRICE, Constants.REGULAR_SUNDAY_PRICE);

                sum = price * groupCount;

                bool isGroupContMoreThatThenAndLessOrEqualThatTwenty =
                    groupCount >= Constants.REGULAR_DISCOUNT_FOR_A_MIN_GROUP &&
                    groupCount <= Constants.REGULAR_DISCOUNT_FOR_A_MAX_GROUP;

                if (isGroupContMoreThatThenAndLessOrEqualThatTwenty)
                {
                    sum = sum - (sum * Constants.REGULAR_DISCOUNT_PERCENTAGE);
                }
            }

            string result = $"Total price: {sum:F2}";
            Console.WriteLine(result);

        }

        private static double PriceAboutDay(string day, double fridayPrice, double saturdayPrice, double sundayPrice)
        {
            double price = 0;

            switch (day)
            {
                case "friday": price = fridayPrice; break;
                case "saturday": price = saturdayPrice; break;
                case "sunday": price = sundayPrice; break;
            }

            return price;
        }
    }

    public static class Constants
    {
        public const double STUDENT_FRIDAY_PRICE = 8.45;
        public const double STUDENT_SATURDAY_PRICE = 9.80;
        public const double STUDENT_SUNDAY_PRICE = 10.46;
        public const int STUDENTS_DISCOUNT_FOR_A_GROUP = 30;
        public const double STUDENTS_DISCOUNT_PERCENTAGE = 0.15;

        public const double BUSINESS_FRIDAY_PRICE = 10.90;
        public const double BUSINESS_SATURDAY_PRICE = 15.60;
        public const double BUSINESS_SUNDAY_PRICE = 16;
        public const int BUSINESS_COUNT_FOR_A_FREE = 100;
        public const int BUSINESS_FREE_PLACES = 10;

        public const double REGULAR_FRIDAY_PRICE = 15;
        public const double REGULAR_SATURDAY_PRICE = 20;
        public const double REGULAR_SUNDAY_PRICE = 22.50;
        public const int REGULAR_DISCOUNT_FOR_A_MIN_GROUP = 10;
        public const int REGULAR_DISCOUNT_FOR_A_MAX_GROUP = 20;
        public const double REGULAR_DISCOUNT_PERCENTAGE = 0.05;
    }
}
