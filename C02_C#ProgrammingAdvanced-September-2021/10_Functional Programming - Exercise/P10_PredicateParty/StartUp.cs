namespace P10_PredicateParty
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        const string COMMAND_TO_END_PARTY = "Party!";
        const string GUESTS_MESSAGE = "{0} are going to the party!";
        const string NO_GUESTS_MESSAGE = "Nobody is going to the party!";

        public static void Main()
        {
            List<string> peoples = Console.ReadLine()
                .Split(" ")
                .ToList();

            var arg = Console.ReadLine();
            while (arg != COMMAND_TO_END_PARTY)
            {
                var splited = arg.Split(" ");
                string command = splited[0];
                string criteria = splited[1];
                string argument = splited[2];

                Predicate<string> startWithPredicate = x => x.StartsWith(argument);
                Predicate<string> endWithPredicate  = x => x.EndsWith(argument);
                Predicate<string> lenghtPredicate = x => x.Length == int.Parse(argument);

                if (command == "Remove")
                {
                    switch (criteria)
                    {
                        case "StartsWith": Remove(peoples, startWithPredicate); break;
                        case "EndsWith": Remove(peoples, endWithPredicate); break;
                        case "Length": Remove(peoples, lenghtPredicate); break;
                    }
                }
                else if (command == "Double")
                {
                    switch (criteria)
                    {
                        case "StartsWith": peoples = Double(peoples, startWithPredicate); break;
                        case "EndsWith": peoples = Double(peoples, endWithPredicate); break;
                        case "Length": peoples = Double(peoples, lenghtPredicate); break;
                    }
                }

                arg = Console.ReadLine();
            }

            PrintResult(peoples);
        }

        private static void Remove(List<string> people, Predicate<string> filter)
        {
            for (int i = 0; i < people.Count; i++)
            {
                if (filter(people[i]))
                {
                    people.Remove(people[i]);
                    i--;
                }
            }
        }

        private static List<string> Double(List<string> people, Predicate<string> filter)
        {
            var doublePeople = new List<string>();

            for (int i = 0; i < people.Count; i++)
            {
                if (filter(people[i]))
                {
                    doublePeople.Add(people[i]);

                    int index = people.IndexOf(people[i]);
                    doublePeople.Insert(index + 1, people[i]);
                }
                else
                {
                    doublePeople.Add(people[i]);
                }
            }

            return doublePeople;
        }

        private static void PrintResult(List<string> peoples)
        {
            string result = NO_GUESTS_MESSAGE;
            if (peoples.Count > 0)
            {
                result = string.Format(GUESTS_MESSAGE, string.Join(", ", peoples));
            }
            Console.WriteLine(result);
        }
    }
}
