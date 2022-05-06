namespace Tree
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Program
    {
        public static void Main()
        {
            var tree = new Tree<int>(10, 
                new Tree<int>(5, 
                    new Tree<int>(6),
                    new Tree<int>(12)), 
                new Tree<int>(7));


            tree.Swap(6, 12);
            string result = string.Join(" ", tree.OrderBfs());
            Console.WriteLine(result);
            
            // 10 5 7 6
        }
    }
}
