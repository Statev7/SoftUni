namespace P10_MultiplicationTable
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            const int START_DIGIT = 1;
            const int END_DIGIT = 10;

            int input = int.Parse(Console.ReadLine());

            for (int i = START_DIGIT; i <= END_DIGIT; i++)
            {
                int sum = input * i;
                string result = $"{input} X {i} = {sum}";

                Console.WriteLine(result);
            }
        }
    }
}
