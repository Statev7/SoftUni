namespace P09_HashSet
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;

    public class StartUp
    {
        public static void Main()
        {
            MyHashSet<int> myHashSet = new MyHashSet<int>();
            MyHashSet<string> myStringHashSet = new MyHashSet<string>();

            myHashSet.Add(1);
            myHashSet.Add(33);
            myHashSet.Add(5);
            myHashSet.Add(3);
            myHashSet.Add(5);

            myStringHashSet.Add("Ivan");
            myStringHashSet.Add("Goho");
            myStringHashSet.Add("Pepi");


            Console.WriteLine(myHashSet.Contains(5));
            Console.WriteLine(myHashSet.Contains(333));
            Console.WriteLine("--------");
            Console.WriteLine(myStringHashSet.Contains("Ivan"));
            Console.WriteLine(myStringHashSet.Contains("Ivan1"));

            //for (int i = 0; i < count; i++)
            //{
            //    myHashSet.Add(i.ToString());
            //}

            //var timer = new Stopwatch();

            //timer.Start();
            //for (int i = 0; i < count; i++)
            //{
            //    myHashSet.Contains(i.ToString());
            //}
            //timer.Stop();
            //Console.WriteLine(timer.ElapsedMilliseconds);
            //timer.Reset();
        }
    }
}
