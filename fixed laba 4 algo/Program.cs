using System.Security.Cryptography;

namespace fixed_laba_4_algo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[,] matrix = GenerateMatrix(150, 1, 30);
            Graph graph = new(matrix, 22, 3, 150);
            graph.ABC();
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            graph.printColors();
            int x = graph.CalculateVertexColorValue();
            Console.WriteLine($"Кількість кольорів: {x}");
        }
        static int[,] GenerateMatrix(int sizeMatrix, int minNeighbours, int maxNeighbours)
        {
            int[,] matrix = new int[sizeMatrix, sizeMatrix];
            Random rand = new Random();
            for (int i = 0; i < sizeMatrix; i++)
            {
                int neighboursCount = rand.Next(minNeighbours, maxNeighbours);
                int neighboursInRow = CountNeighboursInRow(matrix, i);
                if (neighboursCount > neighboursInRow)
                {
                    for (int j = 0; j < neighboursCount - neighboursInRow + 1; j++)
                    {
                        if (i + 1 < sizeMatrix - 1)
                        {
                            int column = rand.Next(i + 1, sizeMatrix);
                            matrix[i, column] = 1;
                            matrix[column, i] = 1;
                        }
                    }
                }
                else
                {
                    continue;
                }
            }
            return matrix;
        }
        static int CountNeighboursInRow(int[,] matrix, int row) 
        {
            int count = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (matrix[row, i] == 1)
                {
                    count++;
                }
            }
            return count;
        }
        static void PrintMatrix(int[,] matrix)
        {
            for (int i = 0;i < matrix.GetLength(0);i++)
            {
                for(int j = 0;j < matrix.GetLength(1);j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
        static int[,] CopyMatrix(int[,] matrix)
        {
            int[,] copiedMatrix = new int[matrix.GetLength(0), matrix.GetLength(0)];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for(int j = 0; j < matrix.GetLength(0); j++)
                {
                    copiedMatrix[i,j] = matrix[i,j];
                }
            }
            return copiedMatrix;
        }
    }
}
