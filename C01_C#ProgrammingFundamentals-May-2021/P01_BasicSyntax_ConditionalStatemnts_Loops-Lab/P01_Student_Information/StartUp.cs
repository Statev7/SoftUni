namespace P01_Student_Information
{
    using System;

    public class Program
    {
        public static void Main()
        {
            string studentName = Console.ReadLine();
            byte age = byte.Parse(Console.ReadLine());
            double grade = double.Parse(Console.ReadLine());

            string result = $"Name: {studentName}, Age: {age}, Grade: {grade:F2}";

            Console.WriteLine(result);
        }
    }
}
