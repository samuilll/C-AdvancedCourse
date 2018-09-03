using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


class Task12StringMatrixRotation
{
    static void Main(string[] args)
    {

        string degreesInput = Console.ReadLine();

        int degrees = int.Parse(Regex.Match(degreesInput, @"\d+").Value);

        Queue<string> linesStore = InputLinesAndStoreThem();

        if (degrees % 360 == 0 || degrees==0)
        {
            while (linesStore.Count!=0)
            {
                Console.WriteLine(linesStore.Dequeue());
            }
        }
        else if (degrees % 360 == 90)
        {
            Rotate90DegreesAndPrint(linesStore);

        }
        else if (degrees % 360 == 180)
        {
            Rotate180DegreesAndPrint(linesStore);

        }
        else if (degrees % 360 == 270)
        {
            Rotate270DegreesAndPrint(linesStore);

        }
        else
        {
            Console.WriteLine("The matrix cannot be rotated.");
        }

    }

    private static void Rotate270DegreesAndPrint(Queue<string> linesStore)
    {
        int rows = linesStore.OrderByDescending(n => n.Length).First().Length;

        int colsLength = linesStore.Count;

        char[][] matrix = new char[rows][];

       var currentCols = 0;

        while (linesStore.Count != 0)
        {
            string currentLine = linesStore.Dequeue();

            int row = rows - 1;

            for (int charCounter = 0; charCounter < currentLine.Length; row--,charCounter++)
            {
                if (matrix[row] == null)
                {
                    matrix[row] = new char[colsLength];
                }
                matrix[row][currentCols] = currentLine[charCounter];
            }

            for (; row >= 0; row--)
            {
                if (matrix[row] == null)
                {
                    matrix[row] = new char[colsLength];
                }
                matrix[row][currentCols] = ' ';
            }

            currentCols++;
        }
        PrintTheMatrix(matrix);
    }

    private static void Rotate180DegreesAndPrint(Queue<string> linesStore)
    {
        int rows = linesStore.Count;

        int cols = linesStore.OrderByDescending(n => n.Length).First().Length;

        char[][] matrix = new char[rows][];

        while (linesStore.Count != 0)
        {
            var temp = linesStore.Dequeue().ToCharArray().Reverse();

            var currentLine = string.Join("", temp);

            matrix[rows - 1] = new char[cols];

            for (int col = 0; col < cols-currentLine.Length; col++)
            {                            
                matrix[rows-1][col] = ' ';
            }
            for (int col = cols-currentLine.Length,charCounter = 0; col < cols; col++,charCounter++)
            {
            
                matrix[rows-1][col] = currentLine[charCounter];
            }
            rows = linesStore.Count;
        }

        PrintTheMatrix(matrix);
    }

    private static void Rotate90DegreesAndPrint(Queue<string> linesStore)
    {
        int rows = linesStore.OrderByDescending(n => n.Length).First().Length;

        int cols = linesStore.Count;

        char[][] matrix = new char[rows][];

        while (linesStore.Count!=0)
        {
            string currentLine = linesStore.Dequeue();

            for (int row = 0; row < currentLine.Length; row++)
            {
                if (matrix[row]==null)
                {
                    matrix[row] = new char[cols];
                }
                matrix[row][cols - 1] = currentLine[row];
            }

            for (int row = currentLine.Length; row < rows; row++)
            {
                if (matrix[row] == null)
                {
                    matrix[row] = new char[cols];
                }
                matrix[row][cols - 1] = ' ';
            }

            cols = linesStore.Count;
        }
        PrintTheMatrix(matrix);
    }

    private static Queue<string> InputLinesAndStoreThem()
    {
        Queue<string> linesStore = new Queue<string>();

        while (true)
        {
            var currentLine = Console.ReadLine();

            if (currentLine == "END")
            {
                break;
            }

            linesStore.Enqueue(currentLine);
        }

        return linesStore;
    }

    private static void PrintTheMatrix(char[][] matrix)
    {
        for (int i = 0; i < matrix.Length; i++)
        {
            if (matrix[i].Length != 0)
            {
                Console.WriteLine(string.Join("", matrix[i]));

            }
        }
    }
}

