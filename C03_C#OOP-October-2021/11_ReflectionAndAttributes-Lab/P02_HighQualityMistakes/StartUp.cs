namespace Stealer
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            var spy = new Spy();
            var result = spy.AnalyzeAccessModifiers("Stealer.Hacker");
            Console.WriteLine(result);
        }
    }
}
