namespace _03_BalancedParenthesesSolve
{
    using System.Collections.Generic;

    public class BalancedParenthesesSolve
    {
        private Stack<char> stack;

        public BalancedParenthesesSolve()
        {
            this.stack = new Stack<char>();
        }

        public bool AreBalanced(string parentheses)
        {
            for (int index = 0; index < parentheses.Length; index++)
            {
                char currentSymbol = parentheses[index];

                if (currentSymbol == '{' || currentSymbol == '[' || currentSymbol == '(')
                {
                    stack.Push(currentSymbol);
                }
                else
                {
                    if (stack.Count == 0) return false;

                    char lastSymbol = stack.Pop();
                    bool isValid = ValidateSymbols(currentSymbol, lastSymbol);

                    if (!isValid) return false;
                }
            }

            return true;
        }

        private static bool ValidateSymbols(char currentSymbol, char lastSymbol)
        {
            return lastSymbol == '{' && currentSymbol == '}'
                                || lastSymbol == '(' && currentSymbol == ')'
                                || lastSymbol == '[' && currentSymbol == ']';
        }
    }
}
