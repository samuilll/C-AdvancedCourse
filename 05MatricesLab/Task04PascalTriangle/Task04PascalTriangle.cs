using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    class Task04PascalTriangle
    {
        static void Main(string[] args)
        {
        long length = long.Parse(Console.ReadLine());

        long[][] triangle = new long[length][];

        triangle[0] = new long[1];

        triangle[0][0] = 1;

        for (long row = 1; row < triangle.Length; row++)
        {
            triangle[row] = new long[row + 1];

            for (long col = 0; col < triangle[row].Length; col++)           
            {
                long rightNumber;
                long leftNumber;
                if (col-1<0)
                {
                    leftNumber = 0;
                    rightNumber = triangle[row - 1][col];
                }
                else if (col>=triangle[row-1].Length)
                {
                    rightNumber = 0;
                    leftNumber = triangle[row - 1][col-1];
                }
                else
                {
                    leftNumber = triangle[row - 1][col - 1];
                    rightNumber = triangle[row - 1][col];
                }
                triangle[row][col] = leftNumber + rightNumber;
            }
        }

        foreach (var line in triangle)
        {
            Console.WriteLine(string.Join(" ",line));
        }
        }
}

