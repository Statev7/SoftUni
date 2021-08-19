namespace P09_SimpleTextEditor
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            string str = string.Empty;

            Stack<string> stringLog = new Stack<string>();
            stringLog.Push(str);

            for (int i = 0; i < n; i++)
            {
                string arg = Console.ReadLine();
                string[] splitedArg = arg.
                    Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string operation = splitedArg[0];

                switch (operation)
                {
                    case "1":
                        string stingToAdd = splitedArg[1];
                        str = ApeendString(str, stringLog, stingToAdd);
                        break;
                    case "2":
                        int count = int.Parse(splitedArg[1]);
                        str = RemoveElements(str, stringLog, count);
                        break;
                    case "3":
                        int index = int.Parse(splitedArg[1]);
                        Console.WriteLine(str[index - 1]);
                        break;
                    case "4":
                        stringLog.Pop();
                        str = stringLog.Peek();
                        break;
                }
            }
        }

        private static string RemoveElements(string str, Stack<string> stringLog, int count)
        {
            str = str.Remove(str.Length - count, count);
            stringLog.Push(str);
            return str;
        }

        private static string ApeendString(string str, Stack<string> stringLog, string stingToAdd)
        {
            str += stingToAdd;
            stringLog.Push(str);
            return str;
        }
    }
}
