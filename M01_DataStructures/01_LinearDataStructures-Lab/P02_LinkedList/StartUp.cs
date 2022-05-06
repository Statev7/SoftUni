namespace P02_LinkedList
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            var myLinkedList = new MyLinkedList<int>();

            for (int i = 0; i < 10; i++)
            {
                myLinkedList.AddFirst(i);
            }

            foreach (var item in myLinkedList)
            {
                Console.WriteLine(item);
            }
        }
    }
}
