namespace P05_Digits
{
    using System;
    using System.Text;

    public class StartUp
    {
        public static void Main()
        {
            var input = Console.ReadLine().ToCharArray();

            StringBuilder numbers = new StringBuilder();
            StringBuilder letters = new StringBuilder();
            StringBuilder other = new StringBuilder();


            for (int index = 0; index < input.Length; index++)
            {
               char charText = input[index];

                if (char.IsDigit(charText))
                {
                    numbers.Append(charText);
                }
                else if (char.IsLetter(charText))
                {
                    letters.Append(charText);
                }
                else
                {
                    other.Append(charText);
                }
            }

            Console.WriteLine($"{numbers} {Environment.NewLine}{letters}{Environment.NewLine}{other}");
        }
    }
}
