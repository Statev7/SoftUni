namespace _01_DoublyLinkedList
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            MyDoubleLinkedList<int> collection = new MyDoubleLinkedList<int>();

            collection.AddFirst(5);
            collection.AddLast(10);
            collection.AddFirst(7);

            Console.WriteLine(collection.RemoveLast());
            Console.WriteLine(collection.GetLast());
        }
    }
}
