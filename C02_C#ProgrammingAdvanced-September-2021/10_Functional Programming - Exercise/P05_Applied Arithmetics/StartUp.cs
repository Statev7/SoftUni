namespace P05_Applied_Arithmetics
{
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            var input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            string command = Console.ReadLine();

            while (command != "end")
            {
                Func<int[], int[]> func = Operation(input, command);

                if (command == "print")
                {
                    Console.WriteLine(string.Join(" ", input));
                }
                else
                {
                    input = func(input);
                }

                command = Console.ReadLine();
            }
        }

        static Func<int[], int[]> Operation(int[] array, string command)
        {

            switch (command)
            {
                case "add":
                    for (int i = 0; i < array.Length; i++)
                    {
                        array[i] += 1;
                    }
                    return x => array;
                case "multiply":
                    for (int i = 0; i < array.Length; i++)
                    {
                        array[i] *= 2;
                    }
                    return x => array;
                case "subtract":
                    for (int i = 0; i < array.Length; i++)
                    {
                        array[i] -= 1;
                    }
                    return x => array;
                default: return null;
            }
        }
    }
}
