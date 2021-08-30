namespace P03_ImplemantationLinkedList
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            MyLinkedList<int> linkedList = new MyLinkedList<int>();


            for (int i = 1; i <= 10; i++)
            {
                linkedList.AddFirst(i);
            }

            for (int i = 0; i < 5; i++)
            {
                linkedList.RemoveLast();
            }

            foreach (var item in linkedList)
            {
                Console.WriteLine(item);
            }
        }
    }
}
