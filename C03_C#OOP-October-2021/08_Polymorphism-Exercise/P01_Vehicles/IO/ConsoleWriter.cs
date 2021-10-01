namespace Vehicles.IO
{
    using System;

    using Vehicles.IO.Contracts;

    public class ConsoleWriter : IWriter
    {
        public void WriteLine(string text)
        {
            Console.WriteLine(text);
        }
    }
}
