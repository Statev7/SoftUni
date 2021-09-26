namespace Operations
{
    public class MathOperations
    {
        public int Add(int firstNum, int secondNum)
        {
            int result = firstNum + secondNum;

            return result;
        }

        public double Add(double firstNum, double secondNum, double thirdNum)
        {
            double result = firstNum + secondNum + thirdNum;

            return result;
        }

        public decimal Add(decimal firstNum, decimal secondNum, decimal thirdNum)
        {
            decimal result = firstNum + secondNum + thirdNum;

            return result;
        }
    }
}
