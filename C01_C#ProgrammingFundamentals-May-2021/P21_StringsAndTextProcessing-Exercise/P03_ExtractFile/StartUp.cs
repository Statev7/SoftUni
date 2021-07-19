namespace P03_ExtractFile
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            string[] text = Console.ReadLine()
                .Split('\\', StringSplitOptions.RemoveEmptyEntries);

            string[] arguments = text[text.Length - 1].Split(".");

            string fileName = arguments[0];
            string path = arguments[1];

            Console.WriteLine($"File name: {fileName}");
            Console.WriteLine($"File extension: {path}");
        }
    }
}
