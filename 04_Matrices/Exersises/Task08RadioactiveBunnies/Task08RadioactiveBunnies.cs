using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Task08RadioactiveBunnies
{
    static void Main(string[] args)
    {
        int[] matrixParams = Console.ReadLine()
              .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
              .Select(int.Parse)
              .ToArray();

        int rows = matrixParams[0];

        int columns = matrixParams[1];

        var matrix = new char[rows][];

        ArrangeTheMatrix(matrix);

        string commands = Console.ReadLine();

        int[] playerIndexers = WhereIsThePlayer(matrix);  //  index 0 - row   index 1  - cow index 2 = 0 (continue) || 1 (win) || -1 (lose)

        //..
        foreach (var command in commands)
        {
            playerIndexers = ReadTheCommand(matrix, playerIndexers, command);
            bool firstDeathCheck = MultiplyTheNastyBunnies(matrix);
            var escapeCheck = playerIndexers[2] == 1;
            var secondDeathCheck = playerIndexers[2] == -1;

            if (firstDeathCheck)
            {
                PrintTheMatrix(matrix);
                var deathRow = playerIndexers[0];
                var deathCol = playerIndexers[1];
                Console.WriteLine($"dead: {deathRow} {deathCol}");
                break;
            }

            if (secondDeathCheck)
            {
                PrintTheMatrix(matrix);
                var deathRow = playerIndexers[0];
                var deathCol = playerIndexers[1];
                Console.WriteLine($"dead: {deathRow} {deathCol}");
                break;
            }
            if (escapeCheck)
            {
                PrintTheMatrix(matrix);
                var winRow = playerIndexers[0];
                var winCol = playerIndexers[1];
                Console.WriteLine($"won: {winRow} {winCol}");
                break;
            }

            //Console.WriteLine();
            //  PrintTheMatrix(matrix);
            //Console.WriteLine();
        }

    }

    private static int[] ReadTheCommand(char[][] matrix, int[] playerIndexers, char command)
    {
        switch (command)
        {
            case 'L':
                {
                    playerIndexers = PlayerMove(playerIndexers, matrix, command);
                    break;
                }
            case 'R':
                {
                    playerIndexers = PlayerMove(playerIndexers, matrix, command);
                    break;
                }
            case 'U':
                {
                    playerIndexers = PlayerMove(playerIndexers, matrix, command);
                    break;
                }
            case 'D':
                {
                    playerIndexers = PlayerMove(playerIndexers, matrix, command);
                    break;
                }
            default:
                break;
        }

        return playerIndexers;
    }

    private static int[] PlayerMove(int[] playerIndexers, char[][] matrix, char command)
    {
        var currentRow = playerIndexers[0];
        var currentCol = playerIndexers[1];

        int newRow = -5000;
        int newCol = -5000;

        if (command == 'D' || command == 'U')
        {
            newRow = command == 'D' ? currentRow + 1 : currentRow - 1;
            newCol = currentCol;
        }
        if (command == 'L' || command == 'R')
        {
            newCol = command == 'L' ? currentCol - 1 : currentCol + 1;
            newRow = currentRow;
        }
        if (!IsItInTheMatrix(newRow, newCol, matrix))
        {
            playerIndexers[0] = currentRow;
            playerIndexers[1] = currentCol;
            matrix[currentRow][currentCol] = '.';
            playerIndexers[2] = 1;
        }
        else if (matrix[newRow][newCol] == 'B')
        {
            playerIndexers[0] = newRow;
            playerIndexers[1] = newCol;
            matrix[currentRow][currentCol] = '.';
            playerIndexers[2] = -1;
        }
        else
        {
            matrix[currentRow][currentCol] = '.';
            matrix[newRow][newCol] = 'P';
            playerIndexers[0] = newRow;
            playerIndexers[1] = newCol;
        }

        return playerIndexers;
    }

    private static void PrintTheMatrix(char[][] matrix)
    {
        for (int i = 0; i < matrix.Length; i++)
        {
            Console.WriteLine(string.Join("", matrix[i]));
        }
    }

    private static bool MultiplyTheNastyBunnies(char[][] matrix)
    {
        Queue<int> temp = new Queue<int>();

        var bigCheck = false;

        for (int row = 0; row < matrix.Length; row++)
        {
            for (int col = 0; col < matrix[0].Length; col++)
            {
                if (matrix[row][col] == 'B')
                {
                    temp.Enqueue(row);
                    temp.Enqueue(col);
                }
            }
        }

        while (temp.Count > 0)
        {
            var row = temp.Dequeue();
            var col = temp.Dequeue();
            var check = MultiplyTheCurrentBunnie(row, col, matrix);
            if (check)
            {
                bigCheck = true;
            }
        }
        return bigCheck;
    }

    private static bool MultiplyTheCurrentBunnie(int row, int col, char[][] matrix)
    {
        bool check = false;

        if (row + 1 < matrix.Length)
        {
            if (matrix[row + 1][col] == 'P') check = true;
            matrix[row + 1][col] = 'B';
        }
        if (row - 1 >= 0)
        {
            if (matrix[row - 1][col] == 'P') check = true;
            matrix[row - 1][col] = 'B';
        }
        if (col + 1 < matrix[0].Length)
        {
            if (matrix[row][col + 1] == 'P') check = true;
            matrix[row][col + 1] = 'B';
        }
        if (col - 1 >= 0)
        {
            if (matrix[row][col - 1] == 'P') check = true;
            matrix[row][col - 1] = 'B';
        }

        return check;
    }

    private static bool IsItInTheMatrix(int row, int col, char[][] matrix)
    {
        if (row < 0 || col < 0 || row >= matrix.Length || col >= matrix[0].Length)
        {
            return false;
        }
        return true;
    }

    private static int[] WhereIsThePlayer(char[][] matrix)
    {
        int[] indexers = new int[3];
        bool flag = false;

        for (int row = 0; row < matrix.Length; row++)
        {
            for (int col = 0; col < matrix[row].Length; col++)
            {
                if (matrix[row][col] == 'P')
                {
                    indexers[0] = row;
                    indexers[1] = col;
                    flag = true;
                    break;
                }
            }
            if (flag) break;
           
        }

        return indexers;
    }
    private static void ArrangeTheMatrix(char[][] matrix)
    {
        for (int row = 0; row < matrix.Length; row++)
        {
            matrix[row] = Console.ReadLine()
              .ToCharArray();

        }
    }
}

