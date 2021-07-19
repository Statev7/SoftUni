namespace P01_ValidUsernames
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        public static void Main()
        {
            string[] passwords = Console.ReadLine()
                .Split(", ");

            List<string> result = new List<string>();;

            foreach (var password in passwords)
            {
                bool isBreak = false;

                bool isLenghtValid = password.Length >= 3 && password.Length <= 16;
                if (isLenghtValid)
                {
                    for (int index = 0; index < password.Length; index++)
                    {
                        bool isValid = Check(password[index]);
                        if (isValid == false)
                        {
                            isBreak = true;
                            break;
                        }
                    }

                    if (isBreak == false)
                    {
                        result.Add(password);
                    }
                }
            }

            Console.WriteLine(String.Join(Environment.NewLine, result));
        }

        private static bool Check(char charText)
        {
            bool isValid = char.IsLetterOrDigit(charText) || charText == '-' || charText == '_';

            return isValid;
        }
    }
}
