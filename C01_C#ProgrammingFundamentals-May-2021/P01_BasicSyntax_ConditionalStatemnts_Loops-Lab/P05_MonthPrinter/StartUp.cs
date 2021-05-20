namespace P05_MonthPrinter
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            const int MIN_MOUNTS_VALUE = 1;
            const int MAX_MOUNTS_VALUE = 12;

            int input = int.Parse(Console.ReadLine());

            string[] mounts = new string[] 
            { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };

            string result = "Error!";

            bool isValid = input <= MAX_MOUNTS_VALUE && input >= MIN_MOUNTS_VALUE;

            if (isValid)
            {
                result = mounts[input - 1];
            }

            Console.WriteLine(result);
        }
    }
}
