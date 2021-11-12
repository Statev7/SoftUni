namespace ValidationAttributes
{
    using System;

    using ValidationAttributes.Models;
    using ValidationAttributes.Utilities;

    public class StartUp
    {
        public static void Main()
        {
            var person = new Person
             (
                 null,
                 -1
             );

            bool isValidEntity = Validator.IsValid(person);

            Console.WriteLine(isValidEntity);
        }
    }
}
