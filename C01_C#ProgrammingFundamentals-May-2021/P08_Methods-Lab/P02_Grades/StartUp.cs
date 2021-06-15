namespace P02_Grades
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            double digit = double.Parse(Console.ReadLine());
            string digitWithWords = GradeInWords(digit);
            PrintResult(digitWithWords);
        }

        private static string GradeInWords(double digit)
        {
            string result = "Excellent";

            if (digit >= GradeConstants.FAIL_MIN_VALUE && digit <= GradeConstants.FAIL_MAX_VALUE)
            {
                result = "Fail";
            }
            else if (digit >= GradeConstants.POOR_MIN_VALUE && digit <= GradeConstants.POOR_MAX_VALUE)
            {
                result = "Poor";
            }
            else if (digit >= GradeConstants.GOOD_MIN_VALUE && digit <= GradeConstants.GOOD_MAX_VALUE)
            {
                result = "Good";
            }
            else if (digit >= GradeConstants.VERY_GOOD_MIN_VALUE && digit <= GradeConstants.VERY_GOOD_MAX_VALUE)
            {
                result = "Very good";
            }

            return result;
        }
        
        private static void PrintResult(string gradeWithWords)
        {
            Console.WriteLine(gradeWithWords);
        }
    }

    public static class GradeConstants
    {
        public const double FAIL_MIN_VALUE = 2.00;
        public const double FAIL_MAX_VALUE = 2.99;
        public const double POOR_MIN_VALUE = 3.00;
        public const double POOR_MAX_VALUE = 3.49;
        public const double GOOD_MIN_VALUE = 3.50;
        public const double GOOD_MAX_VALUE = 4.49;
        public const double VERY_GOOD_MIN_VALUE = 4.50;
        public const double VERY_GOOD_MAX_VALUE = 5.49;
    }
}
