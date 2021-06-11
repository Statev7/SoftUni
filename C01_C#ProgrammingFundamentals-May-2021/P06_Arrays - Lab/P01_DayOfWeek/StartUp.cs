namespace P01_DayOfWeek
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            int input = int.Parse(Console.ReadLine());

            string[] array = new string[] { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };

            string result = "Invalid day!";

            if (input >= 1 && input <= 7)
            {
                result = array[input - 1];
            }

            Console.WriteLine(result);
        }
    }
}
