namespace P01_Train
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            int wagonsCount = int.Parse(Console.ReadLine());
            var peoplesInWagons = InputPeoplesInWagons(wagonsCount);
            int allPeoplesSum = SumOfPeoples(peoplesInWagons);
            PrintResult(peoplesInWagons, allPeoplesSum);
        }

        private static int[] InputPeoplesInWagons(int wagonsCount)
        {
            int[] peoplesInWagons = new int[wagonsCount];

            for (int index = 0; index < wagonsCount; index++)
            {
                peoplesInWagons[index] = int.Parse(Console.ReadLine());
            }

            return peoplesInWagons;
        }

        private static int SumOfPeoples(int[] peoplesInWagons)
        {
            int sum = 0;

            for (int index = 0; index < peoplesInWagons.Length; index++)
            {
                sum += peoplesInWagons[index];
            }

            return sum;
        }

        private static void PrintResult(int[] peoplesInWagons, int sum)
        {
            Console.WriteLine(string.Join(' ', peoplesInWagons));
            Console.WriteLine(sum);
        }
    }
}
