namespace _03_BalancedParenthesesSolve
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            BalancedParenthesesSolve balancedParenthesesSolve = new BalancedParenthesesSolve();
            var result = balancedParenthesesSolve.AreBalanced("{()[]{}{}}");
            Console.WriteLine(result);
        }
    }
}
