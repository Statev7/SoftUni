namespace P01_ImplementationList
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        public static void Main()
        {
            var myList = new MyList<int>();

            myList.Add(5);
            myList.Add(2);
            myList.Add(1);

            foreach (var item in myList)
            {
                Console.WriteLine(item);
            }
        }
    }
}
