namespace P02_Passed
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            const int MIN_EVALUATION_TO_PASS = 3;

            double grade = double.Parse(Console.ReadLine());

            if (grade >= MIN_EVALUATION_TO_PASS)
            {
                Console.WriteLine("Passed!");
            }
        }
    }
}
