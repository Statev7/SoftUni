namespace P04_SymbolInMatrix
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            int matrixSize = int.Parse(Console.ReadLine());
            char[,] matrix = new char[matrixSize, matrixSize];
            ReadMatrix(matrix);
            string resultMessage = FindElement(matrix);

            Console.WriteLine(resultMessage);
        }

        private static string FindElement(char[,] matrix)
        {
            char elementToFind = char.Parse(Console.ReadLine());
            string resultMessage = $"{elementToFind} does not occur in the matrix";
            bool isBreak = false;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    bool isEqual = matrix[row, col] == elementToFind;
                    if (isEqual)
                    {
                        resultMessage = $"({row}, {col})";
                        isBreak = true;
                        break;
                    }
                }

                if (isBreak)
                {
                    break;
                }
            }

            return resultMessage;
        }

        private static void ReadMatrix(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                var rowDate = Console.ReadLine().ToCharArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = rowDate[col];
                }
            }
        }
    }
}
