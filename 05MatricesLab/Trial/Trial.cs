using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;


    class Trial
    {
        static void Main(string[] args)
        {

        int[,] matrix = new int[5, 5];

        int[][] secondMatrix = new int[5][];

        int counter = 0;

        for (int row = 0; row < secondMatrix.Length; row++)
        {
            secondMatrix[row] = new int[5];
        }

        secondMatrix[3][3] = 123;

        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                matrix[row, col] = counter;

                counter++;
            }
        }

        int debugger = 0;

        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                Console.Write($"{matrix[row,col]:D2} ");
            }

            Console.WriteLine();
        }
    }
    }





