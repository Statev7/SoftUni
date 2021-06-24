namespace P01_BonusScoringSystem
{
    using System;

    public class StartUp
    {
        const int NUMBER_REGARDING_THE_FORMULA = 5;

        public static void Main()
        {
            int studentsCount = int.Parse(Console.ReadLine());
            int lecturesCount = int.Parse(Console.ReadLine());
            int bonus = int.Parse(Console.ReadLine());

            double max = double.MinValue;
            double studentAttendedCount = 0;

            double[] students = new double[studentsCount];

            if (studentsCount == 0 || lecturesCount == 0)
            {
                Console.WriteLine($"Max Bonus: 0.");
                Console.WriteLine($"The student has attended 0 lectures.");
                return;
            }

            for (int index = 0; index < studentsCount; index++)
            {
                double attendances = double.Parse(Console.ReadLine());

                double totalBonus = (attendances / lecturesCount) * (NUMBER_REGARDING_THE_FORMULA + bonus);
                students[index] = totalBonus;

                if (totalBonus > max)
                {
                    max = totalBonus;
                    studentAttendedCount = attendances;
                }
            }

            Array.Sort(students);
            Array.Reverse(students);

            PrintResult(studentAttendedCount, students);
        }

        private static void PrintResult(double studentAttendedCount, double[] students)
        {
            double maxBonus = Math.Ceiling(students[0]);
            string bonusResultAsString = $"Max Bonus: {maxBonus}.";
            Console.WriteLine(bonusResultAsString);

            string attendedResultAsString = $"The student has attended {studentAttendedCount} lectures.";
            Console.WriteLine(attendedResultAsString);
        }
    }
}
