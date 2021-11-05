namespace P04_Fixing_Vol2
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            int firstNumber = 30;
            int secondNumber = 60;

            byte result;

            try
            {
                result = Convert.ToByte(firstNumber * secondNumber);
                Console.WriteLine($"{firstNumber} x {secondNumber} = {result}");
            }
            catch (OverflowException oe)
            {
                Console.WriteLine(oe.Message);
            }
        }
    }
}
