namespace Problem_1
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            var vowelsInput = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(char.Parse)
                .ToArray();

            var consonantsInput = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(char.Parse)
                .ToArray();

            var vowels = new Queue<char>(vowelsInput);
            var consonants = new Stack<char>(consonantsInput);

            var list = new List<string>()
            {
                "pear",
                "flour",
                "pork",
                "olive"
            };

            var listToModife = new List<string>()
            {
                "pear",
                "flour",
                "pork",
                "olive"
            };

            while (consonants.Count > 0)
            {
                var curruntVowells = vowels.Dequeue();
                var curruntConsonats = consonants.Pop();

                for (int i = 0; i < listToModife.Count; i++)
                {
                    if (listToModife[i].Contains(curruntVowells))
                    {
                        int index = listToModife[i].IndexOf(curruntVowells);
                        listToModife[i] = listToModife[i].Remove(index, 1);
                    }

                    if (listToModife[i].Contains(curruntConsonats))
                    {
                        int index = listToModife[i].IndexOf(curruntConsonats);
                        listToModife[i] = listToModife[i].Remove(index, 1);
                    }
                }

                vowels.Enqueue(curruntVowells);
            }

            PrintResult(list, listToModife);
        }

        private static void PrintResult(List<string> list, List<string> listToModife)
        {
            Console.WriteLine($"Words found: {listToModife.Where(x => x == string.Empty).Count()}");
            for (int index = 0; index < list.Count; index++)
            {
                if (listToModife[index] == string.Empty)
                {
                    Console.WriteLine(list[index]);
                }
            }
        }
    }
}
