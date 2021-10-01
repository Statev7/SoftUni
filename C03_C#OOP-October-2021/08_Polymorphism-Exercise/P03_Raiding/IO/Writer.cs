namespace Rading.IO
{
    using System;

    using Rading.IO.Contracts;

    class Writer : IWriter
    {
        public void Write(string text)
        {
            Console.Write(text);
        }

        public void WriteLine(string text)
        {
            Console.WriteLine(text);
        }
    }
}
