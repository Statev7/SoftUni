namespace P07_Tuple
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            string[] input = ReadInput();
            string fullName = input[0] + " " + input[1];
            string address = input[2];

            input = ReadInput();
            string name = input[0];
            int litersOfBeer = int.Parse(input[1]);

            input = ReadInput();
            int firstArg = int.Parse(input[0]);
            double secArg = double.Parse(input[1]);

            MyTuple<string, string> personTuple = new MyTuple<string, string>(fullName, address);
            MyTuple<string, int> BeerTuple = new MyTuple<string, int>(name, litersOfBeer);
            MyTuple<int, double> myTuple = new MyTuple<int, double>(firstArg, secArg);

            Console.WriteLine(personTuple);
            Console.WriteLine(BeerTuple);
            Console.WriteLine(myTuple);
        }

        private static string[] ReadInput()
        {
            return Console.ReadLine()
                            .Split(" ", StringSplitOptions.RemoveEmptyEntries);
        }
    }
}
