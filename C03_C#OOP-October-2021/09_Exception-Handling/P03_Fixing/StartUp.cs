namespace P03_Fixing
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            var weekdays = new string[5];
            weekdays[0] = "Sunday";
            weekdays[1] = "Monday";
            weekdays[2] = "Tuesday";
            weekdays[3] = "Wednesday";
            weekdays[4] = "Thursday";

            for (int i = 0; i <= weekdays.Length; i++)
            {
                try
                {
                    Console.WriteLine(weekdays[i]);
                }
                catch (IndexOutOfRangeException iofe)
                {
                    Console.WriteLine(iofe.Message);
                }
            }
        }
    }
}
