namespace P07_CustomException
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            var name = Console.ReadLine();
            var mail = Console.ReadLine();

            Student student = null;
            try
            {
                student = new Student(name, mail);
                Console.WriteLine(student);
            }
            catch (InvalidPersonNameException ipe)
            {
                Console.WriteLine(ipe.Message);
            }
        }
    }
}
