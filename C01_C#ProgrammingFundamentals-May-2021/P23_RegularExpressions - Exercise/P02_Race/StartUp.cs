namespace P02_Race
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class StartUp
    {
        const string NAME_PATTERN = @"[A-Za-z]+";
        const string DISTANCE_PATTERN = @"\d";
        const string COMMAND_TO_STOP = "end of race";

        public static void Main()
        {
            var people = new Dictionary<string, int>();

            string[] input = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries);

            for (int index = 0; index < input.Length; index++)
            {
                string name = input[index];
                people.Add(name, 0);
            }

            while (true)
            {
                string arguments = Console.ReadLine();

                bool isStopCommand = arguments == COMMAND_TO_STOP;
                if (isStopCommand)
                {
                    PrintResult(people);
                    break;
                }

                Regex findName = new Regex(NAME_PATTERN);
                Regex findDistance = new Regex(DISTANCE_PATTERN);
                var name = findName.Matches(arguments);
                var distance = findDistance.Matches(arguments);

                string fullName = string.Empty;
                int distanceToInt = 0;
                fullName = FullName(name, fullName);
                distanceToInt = Distance(distance, distanceToInt);
                AddDistance(people, fullName, distanceToInt);
            }
        }

        private static void AddDistance(Dictionary<string, int> people, string fullName, int distanceToInt)
        {
            if (people.ContainsKey(fullName))
            {
                people[fullName] += distanceToInt;
            }
        }

        private static int Distance(MatchCollection distance, int distanceToInt)
        {
            for (int i = 0; i < distance.Count; i++)
            {
                distanceToInt += int.Parse(distance[i].ToString());
            }

            return distanceToInt;
        }

        private static string FullName(MatchCollection name, string fullName)
        {
            for (int i = 0; i < name.Count; i++)
            {
                fullName += name[i];
            }

            return fullName;
        }

        private static void PrintResult(Dictionary<string, int> people)
        {
            int index = 1;

            var orderedPeople = people
                .OrderByDescending(x => x.Value)
                .Take(3)
                .ToList();

            foreach (var person in orderedPeople)
            {
                string place = index == 1 ? "st" : index == 2 ? "nd" : "rd";
                Console.WriteLine($"{index++}{place} place: {person.Key}");
            }
        }
    }

}
