namespace P03_ImplemantationLinkedList
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            MyLinkedList<int> linkedList = new MyLinkedList<int>();


            for (int i = 1; i <= 3; i++)
            {
                linkedList.AddFirst(i);
            }


            foreach (var item in linkedList)
            {
                Console.WriteLine(item);
            }
        }
    }
}
