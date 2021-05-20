namespace P04_BackIn30Minutes
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            const int BACK_TIME_VALUE = 30;
            const int MAX_MINUTES_VALUE = 59;
            const int MAX_HOURS_VALUE = 23;
            const int MINUTES_FOR_FORMATING = 10;

            int hours = int.Parse(Console.ReadLine());
            int minutes = int.Parse(Console.ReadLine());

            int minutesAfterBackTime = minutes + BACK_TIME_VALUE;

            bool areTheMinutesBigger = minutesAfterBackTime > MAX_MINUTES_VALUE;
            if (areTheMinutesBigger)
            {
                hours++;
                minutes = minutesAfterBackTime - 60;

                if (hours > MAX_HOURS_VALUE)
                {
                    hours = 0;
                }
            }
            else
            {
                minutes += BACK_TIME_VALUE;
            }

            string result = $"{hours}:0{minutes}";

            if (minutes >= MINUTES_FOR_FORMATING)
            {
                result = $"{hours}:{minutes}";
            }
            
            Console.WriteLine(result);
        }
    }
}
