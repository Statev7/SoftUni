namespace P04_Collector
{
    using System;

    using Stealer;

    public class StartUp
    {
        public static void Main()
        {
            var spy = new Spy();
            var result = spy.Collector("Stealer.Hacker");
            Console.WriteLine(result);
        }
    }
}
