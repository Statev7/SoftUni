namespace Problem_1
{
    using System;

    public class StartUp
    {
        const string COMMAND_TO_STOP = "Complete";
        const string INVALID_EMAIL_ERROR_MESSAGE = "The email {0} doesn't contain the @ symbol.";
        const char REPLACE_SYMBOL = '-';

        public static void Main()
        {
            string email = Console.ReadLine();

            while (true)
            {
                var arg = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                bool isStopCommand = COMMAND_TO_STOP == arg[0];
                if (isStopCommand)
                {
                    break;
                }

                string command = arg[0];
                if (command == "Make")
                {
                    command = arg[1];
                }

                switch (command)
                {
                    case "Upper": email = Upper(email); break;
                    case "Lower": email = Lower(email); break;
                    case "GetDomain": 
                        int count = int.Parse(arg[1]);
                        GetDomain(email, count);
                        break;
                    case "GetUsername": GetUsername(email); break;
                    case "Replace":
                        char symbol = char.Parse(arg[1]);
                        Replace(email, symbol);
                        break;
                    case "Encrypt": Encrypt(email); break;
                }
            }
        }

        private static string Upper(string email)
        {
            email = email.ToUpper();
            PrintStringAfterOperation(email);

            return email;
        }

        private static string Lower(string email)
        {
            email = email.ToLower();
            PrintStringAfterOperation(email);

            return email;
        }

        private static void GetDomain(string email, int count)
        {
            string domain = email.Substring(email.Length - count);
            PrintStringAfterOperation(domain);
        }

        private static void GetUsername(string email)
        {
            bool isValid = email.Contains("@");
            if (isValid)
            {
                int index = email.IndexOf("@");
                string substring = email.Substring(0, index);
                PrintStringAfterOperation(substring);
            }
            else
            {
                Console.WriteLine(string.Format(INVALID_EMAIL_ERROR_MESSAGE, email));
            }
        }

        private static string Replace(string email, char symbol)
        {
            int index = email.IndexOf(symbol);
            while (index != -1)
            {
                email = email.Replace(symbol, REPLACE_SYMBOL);
                index = email.IndexOf(symbol);
            }
            PrintStringAfterOperation(email);

            return email;
        }

        private static void Encrypt(string email)
        {
            for (int i = 0; i < email.Length; i++)
            {
                int asciiCode = (int)email[i];
                Console.Write(asciiCode + " ");
            }
            Console.WriteLine();
        }

        private static void PrintStringAfterOperation(string email)
        {
            Console.WriteLine(email);
        }
    }
}
