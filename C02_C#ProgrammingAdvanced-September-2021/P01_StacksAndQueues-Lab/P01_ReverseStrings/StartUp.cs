namespace P01_ReverseStrings
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        public static void Main()
        {
            string inputString = Console.ReadLine();

            Stack<char> stack = new Stack<char>();

            for (int index = 0; index < inputString.Length; index++)
            {
                stack.Push(inputString[index]);
            }

            while (stack.Count > 0)
            {
                Console.Write(stack.Pop());
            }
        }
    }
}
