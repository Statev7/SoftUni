namespace P08_Ranking
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        const string COMMAND_TO_STOP_ADDING_CONTESTS = "end of contests";
        const string COMMAND_TO_STOP_SUBMISSIONS = "end of submissions";

        public static void Main()
        {
            var contestsWithPassword = new Dictionary<string, string>();
            var students = new Dictionary<string, Dictionary<string, int>>();

            string input = Console.ReadLine();
            while (input != COMMAND_TO_STOP_ADDING_CONTESTS)
            {
                var arg = input
                    .Split(":", StringSplitOptions.RemoveEmptyEntries);

                string courseName = arg[0];
                string password = arg[1];

                if (contestsWithPassword.ContainsKey(courseName) == false)
                {
                    contestsWithPassword.Add(courseName, password);
                }

                input = Console.ReadLine();
            }

            string submission = Console.ReadLine();
            while (submission != COMMAND_TO_STOP_SUBMISSIONS)
            {
                var arg = submission
                    .Split("=>", StringSplitOptions.RemoveEmptyEntries);

                string contestName = arg[0];
                string password = arg[1];
                string studentName = arg[2];
                int points = int.Parse(arg[3]);

                bool isContestValid = contestsWithPassword.ContainsKey(contestName) && contestsWithPassword[contestName] == password;
                if (isContestValid)
                {
                    bool isStudentExist = students.ContainsKey(studentName);
                    if (isStudentExist == false)
                    {
                        students.Add(studentName, new Dictionary<string, int>());
                    }

                    if (students[studentName].ContainsKey(contestName) && students[studentName][contestName] < points)
                    {
                        students[studentName][contestName] = points;
                    }
                    else if (students[studentName].ContainsKey(contestName) == false)
                    {
                        students[studentName].Add(contestName, points);
                    }
                }

                submission = Console.ReadLine();
            }

            PrintResult(students);
        }

        private static void PrintResult(Dictionary<string, Dictionary<string, int>> students)
        {
            var bestStudent = new Dictionary<string, int>();
            foreach (var student in students)
            {
                foreach (var points in student.Value)
                {
                    if (bestStudent.ContainsKey(student.Key) == false)
                    {
                        bestStudent.Add(student.Key, 0);
                    }
                    bestStudent[student.Key] += points.Value;
                }
            }

            foreach (var student in bestStudent
                .OrderByDescending(x => x.Value)
                .Take(1))
            {
                Console.WriteLine($"Best candidate is {student.Key} with total {student.Value} points.");
            }
            Console.WriteLine("Ranking:");
            foreach (var student in students
                .OrderBy(x => x.Key))
            {
                Console.WriteLine($"{student.Key}");
                foreach (var contenst in student.Value
                    .OrderByDescending(x => x.Value))
                {
                    Console.WriteLine($"#  {contenst.Key} -> {contenst.Value}");
                }
            }
        }
    }

}
