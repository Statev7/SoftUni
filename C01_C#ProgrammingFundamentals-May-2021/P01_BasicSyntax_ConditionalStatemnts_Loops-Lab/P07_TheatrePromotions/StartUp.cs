namespace P07_TheatrePromotions
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            const int YOUNG_MIN_VALUE = 0;
            const int YOUNG_MAX_VALUE = 18;
            const int ADULT_MIN_MALUE = 19;
            const int ADULT_MAX_MALUE = 64;
            const int OLD_MIN_MALUE = 65;
            const int OLD_MAX_MALUE = 122;

            string day = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());

            string result = "Error!";

            if (day == "Weekday")
            {
                if (age >= YOUNG_MIN_VALUE && age <= YOUNG_MAX_VALUE || age >= OLD_MIN_MALUE && age <= OLD_MAX_MALUE)
                {
                    result = "12$";
                }
                else if (age >= ADULT_MIN_MALUE && age <= ADULT_MAX_MALUE)
                {
                    result = "18$";
                }
            }
            else if(day == "Weekend")
            {
                if (age >= YOUNG_MIN_VALUE && age <= YOUNG_MAX_VALUE || age >= OLD_MIN_MALUE && age <= OLD_MAX_MALUE)
                {
                    result = "15$";
                }
                else if (age >= ADULT_MIN_MALUE && age <= ADULT_MAX_MALUE)
                {
                    result = "20$";
                }
            }
            else if (day == "Holiday")
            {
                if (age >= YOUNG_MIN_VALUE && age <= YOUNG_MAX_VALUE)
                {
                    result = "5$";
                }
                else if (age >= ADULT_MIN_MALUE && age <= ADULT_MAX_MALUE)
                {
                    result = "12$";
                }
                else if (age >= OLD_MIN_MALUE && age <= OLD_MAX_MALUE)
                {
                    result = "10$";
                }
            }

            Console.WriteLine(result);
        }
    }
}
