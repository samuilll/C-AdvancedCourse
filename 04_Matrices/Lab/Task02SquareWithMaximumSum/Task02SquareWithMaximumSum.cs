﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    class Task02SquareWithMaximumSum
    {
        static void Main(string[] args)
        {
        int[] matrixParams = Console.ReadLine()
            .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

        int rows = matrixParams[0];

        int columns = matrixParams[1];

        int[][] matrix = new int[rows][];

        int maxSum = int.MinValue;

        int[][] submatrix = new int[2][];

        for (int i = 0; i < submatrix.Length; i++)
        {
            submatrix[i] = new int[2];
        }

        for (int row = 0; row < matrix.Length; row++)
        {
            matrix[row] = new int[columns];

            matrix[row] = Console.ReadLine()
                .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            //    Console.WriteLine(string.Join(" ",matrix[row]));
        }
        for (int row = 0; row < matrix.Length-1; row++)
        {
            for (int col = 0; col < matrix[row].Length-1; col++)
            {
                int sum = matrix[row][col] + matrix[row][col+1]+matrix[row+1][col]+matrix[row+1][col+1];

                if (maxSum<sum)
                {
                    submatrix[0][0] = matrix[row][col];
                    submatrix[0][1] = matrix[row][col+1];
                    submatrix[1][0] = matrix[row+1][col];   
                    submatrix[1][1] = matrix[row+1][col+1];
                    maxSum =sum;
                }
            }
        }

        Console.WriteLine(string.Join(" ",submatrix[0]));
        Console.WriteLine(string.Join(" ", submatrix[1]));
        Console.WriteLine(maxSum);
    }
    }

