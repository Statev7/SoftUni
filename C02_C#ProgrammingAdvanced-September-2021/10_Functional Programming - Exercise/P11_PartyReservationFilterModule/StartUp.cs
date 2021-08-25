namespace P11_PartyReservationFilterModule
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        const string COMMAND_TO_END_PARTY = "Print";

        public static void Main()
        {
            var names = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            List<string> filters = new List<string>();

            string input = Console.ReadLine();
            while (input != COMMAND_TO_END_PARTY)
            {
                var splited = input
                    .Split(";", StringSplitOptions.RemoveEmptyEntries);

                string command = splited[0];
                string filter = splited[1];
                string argument = splited[2];

                string arg = filter + ";" + argument;

                if (command == "Add filter")
                {
                    filters.Add(arg);
                }
                else
                {
                    filters.Remove(arg);
                }

                input = Console.ReadLine();
            }

            Filter(names, filters);
            Console.WriteLine(string.Join(" ", names));
        }

        private static void Filter(List<string> names, List<string> filters)
        {
            foreach (var filter in filters)
            {
                string[] splitedFilter = filter.Split(";");

                string filterType = splitedFilter[0];
                string argument = splitedFilter[1];
                Predicate<string> predicate = null;

                switch (filterType)
                {
                    case "Starts with": AddFilter(names, predicate = x => x.StartsWith(argument)); break;
                    case "Ends with": AddFilter(names, predicate = x => x.EndsWith(argument)); break;
                    case "Lenght": AddFilter(names, predicate = x => x.Length == int.Parse(argument)); break;
                    case "Contains": AddFilter(names, predicate = x => x.Contains(argument)); break;
                }
            }
        }

        private static void AddFilter(List<string> names, Predicate<string> filter)
        {
            for (int i = 0; i < names.Count; i++)
            {
                if (filter(names[i]))
                {
                    names.Remove(names[i]);
                    i--;
                }
            }
        }
    }
}
