namespace P07_StudentAcademy
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            int studentsCount = int.Parse(Console.ReadLine());
            var students = new Dictionary<string, List<double>>();

            for (int i = 0; i < studentsCount; i++)
            {
                string studentName = Console.ReadLine();
                double grade = double.Parse(Console.ReadLine());

                bool isStudentExist = students.ContainsKey(studentName);
                if (isStudentExist)
                {
                    students[studentName].Add(grade);
                }
                else
                {
                    students.Add(studentName, new List<double>() { grade });
                }
            }

            OrderStudents(students);
        }

        private static void OrderStudents(Dictionary<string, List<double>> students)
        {
            var orderedStundens = new Dictionary<string, double>();

            foreach (var student in students)
            {
                double currontStundeAvg = student.Value
                    .Average();

                if (currontStundeAvg >= 4.50)
                {
                    orderedStundens.Add(student.Key, currontStundeAvg);
                }
            }

            Print(orderedStundens);
        }

        private static void Print(Dictionary<string, double> orderedStundens)
        {
            orderedStundens
                .OrderByDescending(x => x.Value)
                .ToList()
                .ForEach(x => Console.WriteLine($"{x.Key} -> {x.Value:F2}"));
        }
    }
}
