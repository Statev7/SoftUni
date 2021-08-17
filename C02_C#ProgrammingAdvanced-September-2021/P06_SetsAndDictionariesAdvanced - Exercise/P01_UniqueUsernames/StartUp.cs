namespace P01_UniqueUsernames
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        public static void Main()
        {
            var allNames = new HashSet<string>();

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string name = Console.ReadLine();
                allNames.Add(name);
            }

            foreach (var name in allNames)
            {
                Console.WriteLine(name);
            }
        }
    }
}
