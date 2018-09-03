using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Task01SumOfAllElementsofMatrix
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

        int sum = 0;

        for (int row = 0; row < matrix.Length; row++)
        {
            matrix[row] = new int[columns];
           
                matrix[row] = Console.ReadLine()
                    .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                sum += matrix[row].Sum();
            

        //    Console.WriteLine(string.Join(" ",matrix[row]));
        }
        Console.WriteLine(matrix.Length);
        Console.WriteLine(matrix[0].Length);
        Console.WriteLine(sum);
    }
}

