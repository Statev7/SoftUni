namespace VehiclesExtension.IO
{
    using System;

    using VehiclesExtension.IO.Contracts;

    public class ConsoleReader : IReader
    {
        public string Read()
        {
            return Console.ReadLine();
        }
    }
}
