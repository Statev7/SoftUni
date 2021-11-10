namespace Stealer
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            var spy = new Spy();
            string result = spy.StealFieldInfo("Stealer.Hacker", "username", "password");
            Console.WriteLine(result);

        }
    }
}
