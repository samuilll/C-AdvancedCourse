using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Task05RubixMatrix
{
    static void Main(string[] args)
    {
        int[] matrixParams = Console.ReadLine()
                    .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

        int commandsNumber = int.Parse(Console.ReadLine());

        int rows = matrixParams[0];

        int columns = matrixParams[1];

        int[][] matrix = new int[rows][];

        FillTheMatrixWithNumbers(columns, matrix);

        ImplementTheCommands(matrix, commandsNumber);

        RearrangeTheMatrix(matrix);

    }

    private static void RearrangeTheMatrix(int[][] matrix)
    {
        var counter = 1;

        for (int row = 0; row < matrix.Length; row++)
        {
            for (int col = 0; col < matrix[row].Length; col++)
            {
                if (matrix[row][col] != counter)
                {
                    int[] searchedValueIndexes = SearchTroughTheMatrix(matrix, counter);

                    var searchedRow = searchedValueIndexes[0];

                    var searchedCol = searchedValueIndexes[1];

                    SwapTheElements(matrix, row, col, searchedRow, searchedCol);

                    Console.WriteLine($"Swap ({row}, {col}) with ({searchedRow}, {searchedCol})");
                }
                else
                {
                    Console.WriteLine("No swap required");
                }
                counter++;
            }
        }
    }

    private static void SwapTheElements(int[][] matrix, int row, int col, int searchedRow, int searchedCol)
    {
        var oldValue = matrix[row][col];

        matrix[row][col] = matrix[searchedRow][searchedCol];

        matrix[searchedRow][searchedCol] = oldValue;
    }

    private static int[] SearchTroughTheMatrix(int[][] matrix, int counter)
    {
        int[] indexers = new int[2];

        for (int row = 0; row < matrix.Length; row++)
        {
            for (int col = 0; col < matrix[row].Length; col++)
            {
                if (matrix[row][col] == counter)
                {
                    indexers[0] = row;

                    indexers[1] = col;
                }
            }
        }

        return indexers;
    }

    private static void ImplementTheCommands(int[][] matrix, int commandsNumber)
    {
        for (int i = 0; i < commandsNumber; i++)
        {
            var commands = Console.ReadLine()
                           .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);

            var direction = commands[1];

            var moves = int.Parse(commands[2]);

            var sequenceNumber = int.Parse(commands[0]);

            switch (direction)
            {
                case "up":
                    {
                        UpFunction(direction, moves, sequenceNumber, matrix);
                        break;
                    }
                case "down":
                    {
                        DownFunction(direction, moves, sequenceNumber, matrix);
                        break;
                    }
                case "left":
                    {
                        LeftFunction(direction, moves, sequenceNumber, matrix);
                        break;
                    }
                case "right":
                    {
                        RightFunction(direction, moves, sequenceNumber, matrix);
                        break;
                    }
                default:
                    break;
            }
        }
    }

    private static void RightFunction(string direction, int moves, int sequenceNumber, int[][] matrix)
    {
        moves = moves % matrix[0].Length;

        List<int> temp = new List<int>();

        for (int i = 0; i < matrix[0].Length; i++)
        {
            temp.Add(matrix[sequenceNumber][i]);
        }

        for (int i = 0; i < moves; i++)
        {
            temp.Insert(0, temp[temp.Count - 1]);

            temp.RemoveAt(temp.Count - 1);
        }

        for (int i = 0; i < matrix[0].Length; i++)
        {
            matrix[sequenceNumber][i] = temp[i];
        }
    }

    private static void LeftFunction(string direction, int moves, int sequenceNumber, int[][] matrix)
    {
        moves = moves % matrix[0].Length;

        List<int> temp = new List<int>();

        for (int i = 0; i < matrix[0].Length; i++)
        {
            temp.Add(matrix[sequenceNumber][i]);
        }

        for (int i = 0; i < moves; i++)
        {
            temp.Add(temp[0]);

            temp.RemoveAt(0);
        }

        for (int i = 0; i < matrix[0].Length; i++)
        {
            matrix[sequenceNumber][i] = temp[i];
        }

    }

    private static void DownFunction(string direction, int moves, int sequenceNumber, int[][] matrix)
    {
        moves = moves % matrix.Length;

        List<int> temp = new List<int>();

        for (int i = 0; i < matrix.Length; i++)
        {
            temp.Add(matrix[i][sequenceNumber]);
        }

        for (int i = 0; i < moves; i++)
        {
            temp.Insert(0, temp[temp.Count - 1]);

            temp.RemoveAt(temp.Count - 1);
        }

        for (int i = 0; i < matrix.Length; i++)
        {
            matrix[i][sequenceNumber] = temp[i];
        }
    }

    private static void UpFunction(string direction, int moves, int sequenceNumber, int[][] matrix)
    {
        moves = moves % matrix.Length;

        List<int> temp = new List<int>();

        for (int i = 0; i < matrix.Length; i++)
        {
            temp.Add(matrix[i][sequenceNumber]);
        }

        for (int i = 0; i < moves; i++)
        {
            temp.Add(temp[0]);

            temp.RemoveAt(0);
        }

        for (int i = 0; i < matrix.Length; i++)
        {
            matrix[i][sequenceNumber] = temp[i];
        }
    }

    private static void FillTheMatrixWithNumbers(int columns, int[][] matrix)
    {
        for (int row = 0; row < matrix.Length; row++)
        {
            matrix[row] = new int[columns];
        }

        var counter = 0;

        for (int row = 0; row < matrix.Length; row++)
        {
            for (int col = 0; col < matrix[row].Length; col++)
            {
                matrix[row][col] = ++counter;
            }
        }
    }
}

