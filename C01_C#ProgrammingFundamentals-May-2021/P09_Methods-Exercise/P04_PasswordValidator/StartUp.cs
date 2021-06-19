namespace P04_PasswordValidator
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        const byte PASSWORD_MIN_LENGHT_VALUE = 6;
        const byte PASSWORD_MAX_LENGHT_VALUE = 10;
        const byte PASSWORD_MIN_DIGIT_REQUIREMENT = 2;

        const string PASSWORD_LENGHT_ERROR_MESSAGE = "Password must be between 6 and 10 characters";
        const string PASSWORD_CANNOT_HAVE_INVALID_CHARACTERS = "Password must consist only of letters and digits";
        const string PASSWORD_MIN_DIGIT_REQUIREMENT_ERROR_MESSAGE = "Password must have at least 2 digits";
        const string PASSWORD_VALID_MESSAGE = "Password is valid";

        public static void Main()
        {
            char[] password = Console.ReadLine().ToCharArray();

            List<string> errors = new List<string>();

            string passwordLenght = IsPasswordBetweenSixAndThenCharacters(password);
            string passwordLettersAndDigits = IsPasswordHaveInvalidCharacters(password);
            string passwordDigits = CheckThePasswordForAtLeastTwoDigits(password);

            errors.Add(passwordLenght);
            errors.Add(passwordLettersAndDigits);
            errors.Add(passwordDigits);

            PrintResult(errors);
        }

        private static string IsPasswordBetweenSixAndThenCharacters(char[] password)
        {
            string result = string.Empty;

            bool isInvalid = password.Length >= PASSWORD_MIN_LENGHT_VALUE && password.Length <= PASSWORD_MAX_LENGHT_VALUE;

            if (!isInvalid)
            {
                result = PASSWORD_LENGHT_ERROR_MESSAGE;
            }

            return result;
        }

        private static string IsPasswordHaveInvalidCharacters(char[] password)
        {
            string result = string.Empty;

            for (int index = 0; index < password.Length; index++)
            {
                bool isInvalid = char.IsLetterOrDigit(password[index]);

                if (!isInvalid)
                {
                    result = PASSWORD_CANNOT_HAVE_INVALID_CHARACTERS;
                }
            }

            return result;
        }

        private static string CheckThePasswordForAtLeastTwoDigits(char[] password)
        {
            string result = string.Empty;
            bool isValid = false;
            int count = 0;

            for (int index = 0; index < password.Length; index++)
            {
                isValid = char.IsDigit(password[index]);

                if (isValid)
                {
                    count++;
                }
            }

            if (count < PASSWORD_MIN_DIGIT_REQUIREMENT)
            {
                result = PASSWORD_MIN_DIGIT_REQUIREMENT_ERROR_MESSAGE;
            }

            return result;
        }

        private static void PrintResult(List<string> errors)
        {
            bool areThereAnyMistakes = false;

            for (int index = 0; index < errors.Count; index++)
            {
                if (errors[index].Length != 0)
                {
                    areThereAnyMistakes = true;
                    Console.WriteLine(errors[index]);
                }
            }

            if (!areThereAnyMistakes)
            {
                Console.WriteLine(PASSWORD_VALID_MESSAGE);
            }
        }

    }
}
