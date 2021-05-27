namespace P05_Login
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            const int NUMBER_OF_ATTEMPTS_BEFORE_BLOCKING = 3;

            string userName = Console.ReadLine();
            string password = Console.ReadLine();

            var reversetPassoword = PasswordReverse(userName);
            int count = 0;

            string result = $"User {string.Join("", userName)} logged in.";

            while (password != reversetPassoword)
            {
                if (count == NUMBER_OF_ATTEMPTS_BEFORE_BLOCKING)
                {
                    result = $"User {string.Join("", userName)} blocked!";
                    break;
                }
                count++;

                Console.WriteLine("Incorrect password. Try again.");
                password = Console.ReadLine();
            }

            Console.WriteLine(result);
        }

        private static string PasswordReverse(string stringToReverse)
        {
            var temp = stringToReverse.ToCharArray();
            string password = string.Empty;

            for (int index = temp.Length - 1; index >= 0 ; index--)
            {
                password += temp[index];
            }

            return password;
        }
    }
}
