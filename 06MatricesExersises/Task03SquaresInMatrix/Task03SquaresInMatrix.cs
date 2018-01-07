using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    class Task03SquaresInMatrix
    {
        static void Main(string[] args)
        {

        int[] matrixParams = Console.ReadLine()
                    .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

        int rows = matrixParams[0];

        int columns = matrixParams[1];

        char[][] matrix = new char[rows][];

        for (int row = 0; row < rows; row++)
        {
            matrix[row] = Console.ReadLine()
                          .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                          .Select(char.Parse)
                          .ToArray();
        }
        var count = 0;

        for (int row = 0; row < matrix.Length-1; row++)
        {
            for (int col = 0; col < matrix[row].Length-1; col++)
            {
                char symbol = matrix[row][col];
                if (matrix[row][col+1]== symbol && matrix[row+1][col]==  symbol && matrix[row+1][col+1]==symbol)
                {
                    count++;
                }
            }
        }

        Console.WriteLine(count);
    }
    }

