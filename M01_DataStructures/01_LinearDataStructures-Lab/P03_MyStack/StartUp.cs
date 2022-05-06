namespace P03_Stack
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            var myStack = new MyStack<int>();

            for (int i = 0; i < 5; i++)
            {
                myStack.Push(i);
            }

            Console.WriteLine(myStack.Contains(0));

            foreach (var item in myStack)
            {
                Console.WriteLine(item);
            }
        }
    }
}
