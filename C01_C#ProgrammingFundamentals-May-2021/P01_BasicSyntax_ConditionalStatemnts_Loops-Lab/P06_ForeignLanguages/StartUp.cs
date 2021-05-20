namespace P06_ForeignLanguages
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            string countyName = Console.ReadLine();

            string result = "unknown";

            switch (countyName)
            {
                case "USA":
                case "England":
                    result = "English";
                    break;
                case "Spain":
                case "Argentina":
                case "Mexico":
                    result = "Spanish";
                    break;
            }

            Console.WriteLine(result);
        }
    }
}
