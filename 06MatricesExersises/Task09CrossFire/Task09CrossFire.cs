using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Task09CrossFire
{
    static void Main(string[] args)
    {
        var matrix = InticializeTheMatrix();

        //Console.WriteLine();
        //PrintTheMatrix(matrix);
        //Console.WriteLine();

        while (true)
        {
            var input = Console.ReadLine()
               .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);

            if (input[0] == "Nuke")
            {
                break;
            }

            FirstStepInDestroying(matrix, input);

            //Console.WriteLine();
            //PrintTheMatrix(matrix);
            //Console.WriteLine();

        }

        PrintTheMatrix(matrix);
    }

    private static void LastStepInDestroying(int[][] matrix)
    {

        for (int row = 0; row < matrix.Length; row++)
        {
            var temp = new List<int>();

            for (int col = 0; col < matrix[row].Length; col++)
            {
                if (matrix[row][col] != 0)
                {
                    temp.Add(matrix[row][col]);
                }
            }         
            matrix[row] = temp.ToArray();
        }

    }

    private static void FirstStepInDestroying(int[][] matrix, string[] input)
    {
        int currentRow = int.Parse(input[0]);

        int currentCol = int.Parse(input[1]);

        int radius = int.Parse(input[2]);

        int verticalRow = currentRow - radius;

        int horizontalCol = currentCol - radius;

        int howManyCells = 2 * radius + 1;

        for (int row = verticalRow; howManyCells>0; row++)
        {
            if (AreTheyInTheMatrix(row, currentCol, matrix))
            {
                matrix[row][currentCol] = 0;
            }
            howManyCells--;
        }

        howManyCells = 2 * radius + 1;

        if (currentRow >= 0)
        {
            for (int col = horizontalCol; howManyCells>0; col++)
            {
                if (AreTheyInTheMatrix(currentRow, col, matrix))
                {
                    matrix[currentRow][col] = 0;
                }

                howManyCells--;
            }
        }
        //Console.WriteLine();
        //PrintTheMatrix(matrix);
        //Console.WriteLine();

        LastStepInDestroying(matrix);

      //  RemoveEmptyRows(matrix);

    }

    private static bool AreTheyInTheMatrix(int row, int col, int[][] matrix)
    {
        if (row >= 0 && row < matrix.Length && col >= 0 && col < matrix[row].Length)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private static void PrintTheMatrix(int[][] matrix)
    {
        for (int i = 0; i < matrix.Length; i++)
        {
            if (matrix[i].Length!=0)
            {
                Console.WriteLine(string.Join(" ", matrix[i]));

            }
        }
    }

    private static int[][] InticializeTheMatrix()
    {
        int[] matrixParams = Console.ReadLine()
            .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

        int rows = matrixParams[0];

        int columns = matrixParams[1];

        int[][] matrix = new int[rows][].Select(r => r = new int[columns]).ToArray();

        var counter = 1;

        for (int row = 0; row < matrix.Length; row++)
        {
            for (int col = 0; col < matrix[row].Length; col++)
            {
                matrix[row][col] = counter++;
            }

        }

        return matrix;

    }
}
