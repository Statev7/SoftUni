namespace P03_Elevator
{
    using System;

    public class StartUp
    {
        static void Main()
        {
            int persons = int.Parse(Console.ReadLine());
            int capacity = int.Parse(Console.ReadLine());

            int courses = (int)Math.Ceiling((double)persons / capacity);

            Console.WriteLine(courses);
        }
    }
}
