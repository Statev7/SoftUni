namespace P04_Froggy
{
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            var input = Console.ReadLine().Split(", ")
                .Select(int.Parse)
                .ToArray();

            var lake = new Lake(input);

            Console.WriteLine(string.Join(", ", lake));
        }
    }
}
