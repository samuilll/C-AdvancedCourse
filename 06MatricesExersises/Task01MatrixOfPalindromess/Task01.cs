using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
    {
        static void Main(string[] args)
        {

        int[] matrixParams = Console.ReadLine()
             .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
             .Select(int.Parse)
             .ToArray();

        int rows = matrixParams[0];

        int columns = matrixParams[1];

        char[] alphabet = "abcdefghijklmnopqrstuvwxyz".ToCharArray();

        string[][] matrix = new string[rows][];

        for (int row = 0; row < matrix.Length; row++)
        {
            matrix[row] = new string[columns];
        }

        for (int row = 0;  row< matrix.Length; row++)
        {

            for (int col = 0; col < matrix[row].Length; col++)
            {
                CreateTheStringAndAddToTheMatrix(alphabet, matrix, row, col);
            }

            Console.WriteLine(string.Join(" ",matrix[row]));
        }
        }

    private static void CreateTheStringAndAddToTheMatrix(char[] alphabet, string[][] matrix, int rows, int cols)
    {
        var builder = new StringBuilder();

        var boundaryLetter = alphabet[rows];

        var middleLetter = alphabet[rows + cols];

        builder.Append(boundaryLetter);
        builder.Append(middleLetter);
        builder.Append(boundaryLetter);

        matrix[rows][cols] = builder.ToString();
    }
}

