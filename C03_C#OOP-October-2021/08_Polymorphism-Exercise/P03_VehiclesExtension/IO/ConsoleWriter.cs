namespace VehiclesExtension.IO
{
    using System;

    using VehiclesExtension.IO.Contracts;

    public class ConsoleWriter : IWriter
    {
        public void WriteLine(string text)
        {
            Console.WriteLine(text);
        }
    }
}
