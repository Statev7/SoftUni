namespace P06_Courses
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        const string COMMAND_TO_STOP = "end";

        public static void Main()
        {
            var courses = new Dictionary<string, List<string>>();

            while (true)
            {
                string input = Console.ReadLine();

                bool isStopCommand = input == COMMAND_TO_STOP;
                if (isStopCommand)
                {
                    Print(courses);
                    break;
                }

                string[] arguments =
                    input.Split(":", StringSplitOptions.RemoveEmptyEntries);

                string courseName = arguments[0].Trim();
                string studentName = arguments[1].Trim();
                AddToCourse(courses, courseName, studentName);
            }

        }

        private static void AddToCourse(Dictionary<string, List<string>> courses, string courseName, string studentName)
        {
            bool isCourseExist = courses.ContainsKey(courseName);

            if (isCourseExist)
            {
                courses[courseName].Add(studentName);
            }
            else
            {
                courses.Add(courseName, new List<string>() { studentName });
            }
        }

        private static void Print(Dictionary<string, List<string>> courses)
        {
            var orderedCourses = courses
                .OrderByDescending(c => c.Value.Count)
                .ToList();

            foreach (var course in orderedCourses)
            {
                Console.WriteLine($"{course.Key}: {course.Value.Count}");

                foreach (var studen in course.Value.OrderBy(s => s))
                {
                    Console.WriteLine($"-- {studen}");
                }
            }
        }
    }
}
