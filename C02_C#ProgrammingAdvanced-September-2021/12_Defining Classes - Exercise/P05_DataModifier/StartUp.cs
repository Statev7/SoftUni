namespace P05_DataModifier
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            DateModifier dateModifier = new DateModifier();

            string startDate = Console.ReadLine();
            string endDate = Console.ReadLine();

            int difference = dateModifier.DifferenceBetweenTwoDates(startDate, endDate);
            Console.WriteLine(Math.Abs(difference));
        }
    }
}
