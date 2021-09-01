namespace P08_Threeuple
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            string name = string.Empty;

            string[] input = ReadInput();
            name = input[0] + " " + input[1];
            string address = input[2];
            string town = string.Empty;
            for (int i = 3; i < input.Length; i++)
            {
                town += input[i] + " ";
            }

            var firstTuple = new MyTuple<string, string, string>(name, address, town.Trim());
            Console.WriteLine(firstTuple);

            input = ReadInput();
            name = input[0];
            int litersOfBear = int.Parse(input[1]);
            bool drunkOrNot = input[2] == "drunk" ? true : false;

            var secondTuple = new MyTuple<string, int, bool>(name, litersOfBear, drunkOrNot);
            Console.WriteLine(secondTuple);

            input = ReadInput();
            name = input[0];
            double accountBalance = double.Parse(input[1]);
            string bankName = input[2];

            var thirdTuple = new MyTuple<string, double, string>(name, accountBalance, bankName);
            Console.WriteLine(thirdTuple);
        }

        private static string[] ReadInput()
        {
            return Console.ReadLine()
                            .Split(" ", StringSplitOptions.RemoveEmptyEntries);
        }
    }
}
