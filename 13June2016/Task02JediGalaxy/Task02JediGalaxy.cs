using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Task02JediGalaxy
{
    static void Main(string[] args)
    {

        int[][] matrix = GetParamsAndFillTheMatrix();

        //    PrintTheMatrix(matrix);

        var ivoParams = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();


        long stars = 0;

        while (ivoParams[0] != "Let")
        {
            var evilParams = Console.ReadLine()
               .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
               .Select(int.Parse)
               .ToArray();
                        int ivoRow = int.Parse(ivoParams[0]);
            int ivoCol = int.Parse(ivoParams[1]);

            int evilRow = evilParams[0];
            int evilCol = evilParams[1];

            DestroyStars(matrix, evilRow, evilCol);

            stars = GetStars(matrix, stars, ivoRow, ivoCol);

            ivoParams = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

        }

        Console.WriteLine(stars);
    }

    private static long GetStars(int[][] matrix, long stars, int ivoRow, int ivoCol)
    {
        for (int row = ivoRow, col = ivoCol; row >= 0 && col <= matrix[0].Length; row--, col++)
        {
            if (IsInTheMatrix(matrix, row, col))
            {
                stars += matrix[row][col];
            }
        }

        return stars;
    }

    private static void DestroyStars(int[][] matrix, int evilRow, int evilCol)
    {
        for (int row = evilRow, col = evilCol; row >= 0 && col >= 0; row--, col--)
        {
            if (IsInTheMatrix(matrix, row, col))
            {
                matrix[row][col] = 0;
            }
        }
    }

    private static bool IsInTheMatrix(int[][] matrix, int row, int col)
    {
        return row >= 0 && col >= 0 && row < matrix.Length && col < matrix[0].Length;
    }

    private static void PrintTheMatrix(int[][] matrix)
    {
        foreach (var row in matrix)
        {
            Console.WriteLine(string.Join(", ", row));
        }
    }

    private static int[][] GetParamsAndFillTheMatrix()
    {
        var parameters = Console.ReadLine()
                 .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                 .Select(int.Parse)
                 .ToArray();

        var rows = parameters[0];
        var cols = parameters[1];
        var matrix = new int[parameters[0]][];
        int counter = 0;

        for (int row = 0; row < rows; row++)
        {
            matrix[row] = new int[cols];

            for (int col = 0; col < cols; col++)
            {
                matrix[row][col] = counter;
                counter++;
            }
        }

        return matrix;
    }
}

