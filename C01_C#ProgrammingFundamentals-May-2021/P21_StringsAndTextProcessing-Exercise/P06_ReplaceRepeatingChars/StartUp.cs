namespace P06_ReplaceRepeatingChars
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            string input = Console.ReadLine();

            for (int firstLoopIndex = 0; firstLoopIndex < input.Length; firstLoopIndex++)
            {
                char lastLetter = '\0';
                int startIndex = 0;
                int count = 0;

                for (int secLoopIndex = firstLoopIndex + 1; secLoopIndex < input.Length; secLoopIndex++)
                {
                    bool isEqual = input[firstLoopIndex] == input[secLoopIndex];
                    if (isEqual)
                    {
                        if (lastLetter != input[firstLoopIndex])
                        {
                            startIndex = firstLoopIndex;
                            lastLetter = input[firstLoopIndex];
                        }
                        count++;
                    }
                    else
                    {
                        break;
                    }
                }

                input = input.Remove(startIndex, count);
            }

            Console.WriteLine(input);
        }
    }
}
