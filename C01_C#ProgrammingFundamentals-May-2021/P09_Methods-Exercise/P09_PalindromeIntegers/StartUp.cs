namespace P09_PalindromeIntegers
{
    using System;

    public class StartUp
    {
        const string STOP_COMMAND = "END";

        public static void Main()
        {
            string command = Console.ReadLine();

            while (command != STOP_COMMAND)
            {
                CheckIfTheFirstAndLastIndexAreEqual(command);

                command = Console.ReadLine();
            }
        }

        private static void CheckIfTheFirstAndLastIndexAreEqual(string input)
        {
            string result = "false";

            input.ToCharArray();
            int firstDigit = int.Parse(input[0].ToString());
            int lastDigit = int.Parse(input[input.Length - 1].ToString());

            bool isValid = firstDigit == lastDigit;
            if (isValid)
            {
                result = "true";
            }

            Console.WriteLine(result);
        }
    }
}
