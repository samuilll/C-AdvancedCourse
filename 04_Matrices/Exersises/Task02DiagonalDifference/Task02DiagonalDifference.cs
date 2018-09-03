using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task02DiagonalDifference
{
    class Task02DiagonalDifference
    {
        static void Main(string[] args)
        {

            int matrixSize = int.Parse(Console.ReadLine());

            int[][] matrix = new int[matrixSize][];

            for (int row = 0; row < matrixSize; row++)
            {
                matrix[row] = Console.ReadLine()
                              .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                              .Select(int.Parse)
                              .ToArray();
            }

            var firstDiagonalSum = 0;

            var secondDiagonalSum = 0;

            for (int row = 0,col = 0; row < matrixSize; row++,col++)
            {
                firstDiagonalSum += matrix[row][col];
            }
            for (int row = 0,col=matrixSize-1; row < matrixSize; row++,col--)
            {
                secondDiagonalSum += matrix[row][col];
            }

            Console.WriteLine(Math.Abs(firstDiagonalSum-secondDiagonalSum));

        }
    }
}
