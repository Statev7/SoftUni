namespace P04_Queue
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            MyQueue<int> queue = new MyQueue<int>();

            queue.Enqueue(5);
            queue.Enqueue(15);
            queue.Enqueue(35);

            Console.WriteLine(queue.Dequeue());
            Console.WriteLine(string.Join(" ", queue));
        }
    }
}
