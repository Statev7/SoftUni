namespace P02_ImplemantationStack
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            var stack = new MyStack<int>();

            stack.Push(1);
            stack.Push(2);
            stack.Push(3);

            foreach (var item in stack)
            {
                Console.WriteLine(item);
            }
        }
    }
}
