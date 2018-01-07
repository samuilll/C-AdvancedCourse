using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Task06TargetPractice
{
    static void Main(string[] args)
    {
        int[] matrixParams = Console.ReadLine()
               .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
               .Select(int.Parse)
               .ToArray();

        int rows = matrixParams[0];

        int columns = matrixParams[1];

        string snake = Console.ReadLine();

        var matrix = new char[rows][];

        int[] shotParams = Console.ReadLine()
                   .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                   .Select(int.Parse)
                   .ToArray();

        for (int i = 0; i < matrix.Length; i++)
        {
            matrix[i] = new char[columns];
        }

        FillTheMatrixWithSnakes(snake, matrix);
        PrintTheMatrix(matrix);
        Console.WriteLine();

        ShotTheMatrix(matrix, shotParams);


        PrintTheMatrix(matrix);
        Console.WriteLine();

        RearrangeTheMatrixBecauseOfGravity(matrix);

        PrintTheMatrix(matrix);
    }

    private static void RearrangeTheMatrixBecauseOfGravity(char[][] matrix)
    {
        for (int col = 0; col < matrix[0].Length; col++)
        {
            for (int row = matrix.Length - 1; row >= 0; row--)
            {
                if (matrix[row][col] != ' ')
                {
                    continue;
                }
                else
                {
                    for (int i = row - 1; i >= 0; i--)
                    {
                        if (matrix[i][col] != ' ')
                        {
                            matrix[row][col] = matrix[i][col];
                            matrix[i][col] = ' ';
                            break;
                        }
                    }
                }
            }
        }
    }

    private static void ShotTheMatrix(char[][] matrix, int[] shotParams)
    {
        var shotRow = shotParams[0];

        var shotCol = shotParams[1];

        var shotRaduis = shotParams[2];

        var squareRow = shotRow - shotRaduis + 1;

        var squareCol = shotCol - shotRaduis + 1;

        var squareSize = (shotRaduis - 1) * 2 + 1;

        for (int row = squareRow, counter1 = 0; counter1 < squareSize && row < matrix.Length ; row++, counter1++)
        {            
            for (int col = squareCol, counter2 = 0; counter2 < squareSize && col < matrix[0].Length; col++, counter2++)
            {
                if (row < 0)
                {
                  //  counter1--;
                    break; 
                }
                if (col<0)
                {
                  //  counter2--;
                    continue;
                }
                matrix[row][col] = ' ';
            }
        }

        ShotTheBoundaryCells(matrix, shotRow, shotCol, shotRaduis);
    }

    private static void ShotTheBoundaryCells(char[][] matrix, int shotRow, int shotCol, int shotRaduis)
    {
        if (shotRow - shotRaduis >= 0)
        {
            matrix[shotRow - shotRaduis][shotCol] = ' ';
        }
        if (shotRow + shotRaduis < matrix.Length)
        {
            matrix[shotRow + shotRaduis][shotCol] = ' ';
        }
        if (shotCol + shotRaduis < matrix[0].Length)
        {
            matrix[shotRow][shotCol + shotRaduis] = ' ';
        }
        if (shotCol - shotRaduis >= 0)
        {
            matrix[shotRow][shotCol - shotRaduis] = ' ';
        }
    }

    private static void PrintTheMatrix(char[][] matrix)
    {
        for (int i = 0; i < matrix.Length; i++)
        {
            Console.WriteLine(string.Join("", matrix[i]));
        }
    }

    private static void FillTheMatrixWithSnakes(string snake, char[][] matrix)
    {
        int col = matrix[0].Length;

        var charCounter = 0;

        for (int row = matrix.Length - 1; row >= 0; row--)
        {

            if (col == matrix[0].Length)
            {
                col = matrix[0].Length - 1;

                while (col >= 0)
                {
                    matrix[row][col] = snake[charCounter];

                    col--;
                    
                    charCounter = CheckTheCharCounter(charCounter, snake);
                }
            }
            else if (col == -1)
            {
                col = 0;

                while (col < matrix[0].Length)
                {
                    matrix[row][col] = snake[charCounter];
          
                    charCounter = CheckTheCharCounter(charCounter, snake);
      
                    col++;
                }
            }
        }
    }

    private static int CheckTheCharCounter(int charCounter, string snake)
    {
        charCounter++;

        if (charCounter==snake.Length)
        {
            charCounter = 0;
        }

        return charCounter;
    }
}

