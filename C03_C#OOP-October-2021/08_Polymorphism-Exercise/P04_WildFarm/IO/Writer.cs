﻿namespace WildFarm.IO
{
    using System;

    using WildFarm.IO.Contracts;

    public class Writer : IWriter
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
