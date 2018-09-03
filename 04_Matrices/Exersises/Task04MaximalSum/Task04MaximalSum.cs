using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Task04MaximalSum
{
    static void Main(string[] args)
    {
        int[] matrixParams = Console.ReadLine()
                    .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

        int rows = matrixParams[0];

        int columns = matrixParams[1];

        int[][] matrix = new int[rows][];

        for (int row = 0; row < rows; row++)
        {
            matrix[row] = Console.ReadLine()
                          .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                          .Select(int.Parse)
                          .ToArray();
        }

        int[][] subMatrix = new int[3][];

        for (int row = 0; row < subMatrix.Length; row++)
        {
            subMatrix[row] = new int[3];
        }

        var maxSum = 0;

      maxSum =  CheckAll3X3SubmatricesInTheMatrice(matrix, subMatrix, maxSum);

        Console.WriteLine($"Sum = {maxSum}");

        PrinTheMaxSubmatrix(subMatrix);

    }

    private static void PrinTheMaxSubmatrix(int[][] subMatrix)
    {
        for (int row = 0; row < subMatrix.Length; row++)
        {
            Console.WriteLine(string.Join(" ", subMatrix[row]));
        }
    }

    private static int CheckAll3X3SubmatricesInTheMatrice(int[][] matrix, int[][] subMatrix, int maxSum)
    {
        for (int row = 0; row < matrix.Length - 2; row++)
        {
            for (int col = 0; col < matrix[row].Length - 2; col++)
            {
                int currentSum = CalculateTheCurrentSubmatrixSum(matrix, row, col);

                if (currentSum > maxSum)
                {
                    ChangeTheMaxSubmatrix(matrix, subMatrix, row, col);

                    maxSum = currentSum;
                }

            }
        }

        return maxSum;
    }

    private static void ChangeTheMaxSubmatrix(int[][] matrix, int[][] subMatrix, int row, int col)
    {
        subMatrix[0][0] = matrix[row][col];
        subMatrix[0][1] = matrix[row][col + 1];
        subMatrix[0][2] = matrix[row][col + 2];
        subMatrix[1][0] = matrix[row + 1][col];
        subMatrix[1][1] = matrix[row + 1][col + 1];
        subMatrix[1][2] = matrix[row + 1][col + 2];
        subMatrix[2][0] = matrix[row + 2][col];
        subMatrix[2][1] = matrix[row + 2][col + 1];
        subMatrix[2][2] = matrix[row + 2][col + 2];
    }

    private static int CalculateTheCurrentSubmatrixSum(int[][] matrix, int row, int col)
    {
        return matrix[row][col] + matrix[row][col + 1] + matrix[row][col + 2] + matrix[row + 1][col] + matrix[row + 1][col + 1]
            + matrix[row + 1][col + 2] + matrix[row + 2][col] + matrix[row + 2][col + 1] + matrix[row + 2][col + 2];
    }
}

