namespace P02_AverageStudentGrades
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class StartUp
    {
        public static void Main()
        {
            var allStudents = new Dictionary<string, List<decimal>>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] arg = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string studentName = arg[0];
                decimal grade = decimal.Parse(arg[1]);

                bool isStudentExist = allStudents.ContainsKey(studentName);
                if (isStudentExist == false)
                {
                    allStudents.Add(studentName, new List<decimal>());
                }
                allStudents[studentName].Add(grade);
            }

            PrintResult(allStudents);
        }

        private static void PrintResult(Dictionary<string, List<decimal>> allStudents)
        {
            foreach (var student in allStudents)
            {
                StringBuilder str = new StringBuilder();
                foreach (var grade in student.Value)
                {
                    str.Append($"{grade:F2} ");
                }

                Console.WriteLine($"{student.Key} -> {str}(avg: {student.Value.Average():F2})");
            }
        }
    }
}
