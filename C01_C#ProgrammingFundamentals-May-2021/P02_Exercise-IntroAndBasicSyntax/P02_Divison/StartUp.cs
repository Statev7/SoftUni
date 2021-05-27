namespace P02_Divison
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            int input = int.Parse(Console.ReadLine());

            string result = "Not divisible";

            for (int i = input; i > 0; i--)
            {
                bool isValid = i == 10 || i == 7 || i == 6 || i == 3 || i == 2;

                if (input % i == 0 && isValid)
                {
                    result = $"The number is divisible by {i}";
                    break;
                }
            }

            Console.WriteLine(result);
        }
    }
}
