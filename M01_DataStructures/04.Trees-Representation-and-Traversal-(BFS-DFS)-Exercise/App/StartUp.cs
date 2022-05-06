namespace App
{
    using System;

    using Tree;

    public class StartUp
    {
        public static void Main()
        {
            var treeFactory = new TreeFactory();

            string[] input = new string[]
            {
                "7 19",
                "7 21",
                "7 14",
                "19 1",
                "19 12",
                "19 31",
                "14 23",
                "14 6"
            };

            var tree = treeFactory.CreateTreeFromStrings(input);
            var result = tree.SubTreesWithGivenSum(43);

            foreach (var tree1 in result)
            {
                Console.WriteLine(tree1.GetAsString());
            }
        }
    }
}
