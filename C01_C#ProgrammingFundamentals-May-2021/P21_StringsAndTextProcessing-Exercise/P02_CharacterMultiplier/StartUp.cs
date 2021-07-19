namespace P02_CharacterMultiplier
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            string[] arguments = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            int sum = 0;

            char[] firstArg = arguments[0].ToCharArray();
            char[] secondArg = arguments[1].ToCharArray();

            bool isArgLenghtEquals = firstArg.Length == secondArg.Length;
            if (isArgLenghtEquals)
            {
                sum = SumOfEqualsLenght(firstArg, secondArg);
            }
            else
            {
                sum = SumOfDifferentLenght(firstArg, secondArg);
            }

            Console.WriteLine(sum);
        }

        private static int SumOfEqualsLenght(char[] firstArg, char[] secArg)
        {
            int lenght = firstArg.Length;
            int sum = 0;

            for (int index = 0; index < lenght; index++)
            {
                sum += (int)firstArg[index] * (int)secArg[index];
            }

            return sum;
        }

        private static int SumOfDifferentLenght(char[] firstArg, char[] secArg)
        {
            int sum = 0;

            char[] longerInput = firstArg.Length > secArg.Length ? longerInput = firstArg : longerInput = secArg;
            int minLenght = Math.Min(firstArg.Length, secArg.Length);

            for (int index = 0; index < minLenght; index++)
            {
                sum += (int)firstArg[index] * (int)secArg[index];
            }

            for (int index = minLenght; index < longerInput.Length; index++)
            {
                sum += longerInput[index];
            }

            return sum;
        }
    }
}
