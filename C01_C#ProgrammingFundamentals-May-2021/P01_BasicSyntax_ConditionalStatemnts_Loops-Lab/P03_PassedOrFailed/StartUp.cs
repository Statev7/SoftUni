namespace P03_PassedOrFailed
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            const int MIN_EVALUATION_TO_PASS = 3;

            double grade = double.Parse(Console.ReadLine());
            string result = "Failed!";

            if (grade >= MIN_EVALUATION_TO_PASS)
            {
                result = "Passed!";
            }

            Console.WriteLine(result);
        }
    }
}
