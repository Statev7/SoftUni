namespace P04_Snowwhite
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        const string COMMAND_TO_STOP = "Once upon a time";

        public static void Main()
        {
            var dwarfs = new Dictionary<string, Dictionary<string, int>>();

            while (true)
            {
                string arguments = Console.ReadLine();

                bool isStopCommand = arguments == COMMAND_TO_STOP;
                if (isStopCommand)
                {
                    Print(dwarfs);
                    break;
                }

                string[] splitedArguments = arguments
                    .Split(new[] { " ", "<:>" }, StringSplitOptions.RemoveEmptyEntries);

                string dwarfName = splitedArguments[0];
                string hatColor = splitedArguments[1];
                int physics = int.Parse(splitedArguments[2]);

                AddDwarf(dwarfs, dwarfName, hatColor, physics);
            }
        }

        private static void AddDwarf(Dictionary<string, Dictionary<string, int>> dwarfs, string dwarfName, string hatColor, int physics)
        {
            bool isColorExist = dwarfs.ContainsKey(hatColor);

            if (isColorExist == false)
            {
                dwarfs.Add(hatColor, new Dictionary<string, int>());
                dwarfs[hatColor].Add(dwarfName, physics);
            }
            else
            {
                bool isDwarfsAlreadyIn = dwarfs[hatColor].ContainsKey(dwarfName);
                if (isDwarfsAlreadyIn)
                {
                    if (dwarfs[hatColor][dwarfName] < physics)
                    {
                        dwarfs[hatColor][dwarfName] = physics;
                    }
                }
                else
                {
                    dwarfs[hatColor].Add(dwarfName, physics);
                }
            }
        }

        private static void Print(Dictionary<string, Dictionary<string, int>> dwarfs)
        {
            Dictionary<string, int> sortedDwarfs = new Dictionary<string, int>();
            foreach (var hatColor in dwarfs.OrderByDescending(x => x.Value.Count()))
            {
                foreach (var dwarf in hatColor.Value)
                {
                    sortedDwarfs.Add($"({hatColor.Key}) {dwarf.Key} <-> ", dwarf.Value);
                }
            }
            foreach (var dwarf in sortedDwarfs.OrderByDescending(x => x.Value))
            {
                Console.WriteLine($"{dwarf.Key}{dwarf.Value}");
            }
        }
    }
}
