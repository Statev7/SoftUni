namespace P05_MultiplyBigNumber
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        public static void Main()
        {
            string bigNumString = Console.ReadLine();
            bigNumString = bigNumString.TrimStart(new char[] { '0' });
            char[] bigNum = bigNumString.ToCharArray();
            int number = int.Parse(Console.ReadLine());
            if (number == 0)
            {
                Console.WriteLine("0");
                return;
            }

            List<string> newNum = new List<string>();

            int parse = 0;
            for (int i = bigNum.Length - 1; i >= 0; i--)
            {
                parse = (int.Parse(Convert.ToString(bigNum[i])) * number) + parse;
                newNum.Insert(0, (parse % 10).ToString());
                parse /= 10;
            }


            if (parse > 0)
            {
                Console.WriteLine($"{parse}{string.Join("", newNum)}");
            }
            else
            {
                Console.WriteLine($"{string.Join("", newNum)}");
            }
        }
    }
}
