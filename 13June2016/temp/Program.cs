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

        Stack<string[]> stack = new Stack<string[]>();

        var starsList = new List<int>();

        while (ivoParams[0] != "Let")
        {

            int ivoRow = int.Parse(ivoParams[0]) - 1;
            int ivoCol = int.Parse(ivoParams[1]) - 1;

            ivoRow = (ivoRow >= matrix.Length) ? (matrix.Length - 1) : (ivoRow < 0) ? 0 : ivoRow;
            ivoCol = (ivoCol >= matrix[0].Length) ? (matrix[0].Length - 1) : (ivoCol < 0) ? 0 : ivoCol;


            for (int row = ivoRow, col = ivoCol; row < matrix.Length && row >= 0 && col >= 0 && col < matrix[0].Length; row--, col++)
            {
                
                    starsList.Add(matrix[row][col]);
                
            }

            stack.Push(ivoParams);

            ivoParams = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

        }

        stack.Pop();

       var evilParams = stack.Pop();

        int evilRow = int.Parse(evilParams[0]) - 1;
        int evilCol = int.Parse(evilParams[1]) - 1;

        evilRow = (evilRow >= matrix.Length) ? (matrix.Length - 1) : (evilRow < 0) ? 0 : evilRow;
        evilCol = (evilCol >= matrix[0].Length) ? (matrix[0].Length - 1) : (evilCol < 0) ? 0 : evilCol;

        var evilNumbers = new List<int>();

        for (int row = evilRow, col = evilCol; row < matrix.Length && row >= 0 && col >= 0 && col < matrix[0].Length; row--, col--)
        {
            evilNumbers.Add(matrix[row][col]);
        }

        foreach (var number in evilNumbers)
        {
            if (starsList.Contains(number))
            {
                starsList.Remove(number);
            }
        }

        Console.WriteLine(starsList.Sum());
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
        var counter = 0;

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

