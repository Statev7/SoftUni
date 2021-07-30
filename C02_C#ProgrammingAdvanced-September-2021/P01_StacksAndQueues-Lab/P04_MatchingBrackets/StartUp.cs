namespace P04_MatchingBrackets
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        public static void Main()
        {
            string input = Console.ReadLine();
            Stack<int> stack = new Stack<int>();


            for (int index = 0; index < input.Length; index++)
            {
                if (input[index] == '(')
                {
                    stack.Push(index);
                }
                else if (input[index] == ')')
                {
                    int startIndex = stack.Pop();
                    string result = input.Substring(startIndex, index - startIndex + 1);
                    Console.WriteLine(result);
                }
            }
        }
    }
}
