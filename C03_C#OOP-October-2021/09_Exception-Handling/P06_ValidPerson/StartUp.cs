namespace P06_ValidPerson
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            for (int i = 0; i < 5; i++)
            {
                var personFirstName = Console.ReadLine();
                var personLastName = Console.ReadLine();
                var personAge = int.Parse(Console.ReadLine());

                CreatePerson(personFirstName, personLastName, personAge);
            }
        }

        private static void CreatePerson(string firstName, string lastName, int age)
        {
            Person person = null;
            try
            {
                person = new Person(firstName, lastName, age);
                Console.WriteLine(person);
            }
            catch (ArgumentNullException ae)
            {
                Console.WriteLine(ae.Message);
            }
            catch (ArgumentOutOfRangeException aofre)
            {
                Console.WriteLine(aofre.Message);
            }
        }
    }
}
