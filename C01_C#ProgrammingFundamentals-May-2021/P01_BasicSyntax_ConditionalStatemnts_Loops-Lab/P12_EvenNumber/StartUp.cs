namespace P12_EvenNumber
{
    using System;

    public class StartUp
    {
        public static void Main()
        {

            string result = "Please write an even number.";

            while (true)
            {
                int input = int.Parse(Console.ReadLine());
                input = Math.Abs(input);

                if (input % 2 == 0)
                {
                    result = $"The number is: {input}";
                    Console.WriteLine(result);

                    break;
                }

                Console.WriteLine(result);
            }
        }
    }
}
