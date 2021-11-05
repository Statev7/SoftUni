namespace P02_EnterNumbers
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            var start = int.Parse(Console.ReadLine());
            var end = int.Parse(Console.ReadLine());
            ReadNumber(start, end);
        }

        private static void ReadNumber(int start, int end)
        {
            for (int i = start; i < end; i++)
            {
                try
                {
                    var number = int.Parse(Console.ReadLine());
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("Re-enter the numbers");
                    ReadNumber(start, end);
                    break;
                }
            }
        }
    }
}
