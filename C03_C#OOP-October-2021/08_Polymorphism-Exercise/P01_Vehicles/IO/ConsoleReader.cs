namespace Vehicles.IO
{
    using System;

    using Vehicles.IO.Contracts;

    public class ConsoleReader : IReader
    {
        public string Read()
        {
            return Console.ReadLine();
        }
    }
}
