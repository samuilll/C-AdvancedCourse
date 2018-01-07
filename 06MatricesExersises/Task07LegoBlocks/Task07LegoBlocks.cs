using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Task07LegoBlocks
{
    static void Main(string[] args)
    {

        int N = int.Parse(Console.ReadLine());

        int[][] firstMat = new int[N][];

        int[][] secondMat = new int[N][];

        FillTheMatrix(N, firstMat);

        FillTheMatrix(N, secondMat);

        if (TheMatricesFitted(firstMat, secondMat))
        {
            int[][] resultMat = new int[N][];

            CreateTheNewMatrix(firstMat, secondMat, resultMat);

            PrintTheNewMatrix(resultMat);
        }
        else
        {
            PrintTheTotalNumberOfCells(firstMat, secondMat);
        }


    }

    private static void PrintTheTotalNumberOfCells(int[][] firstMat, int[][] secondMat)
    {
        var number = 0;

        for (int row = 0; row < firstMat.Length; row++)
        {
            number += firstMat[row].Length + secondMat[row].Length;
        }

        Console.WriteLine($"The total number of cells is: {number}");
    }

    private static void PrintTheNewMatrix(int[][] resultMat)
    {
        for (int row = 0; row < resultMat.Length; row++)
        {
            Console.WriteLine("[{0}]", string.Join(", ", resultMat[row]));
        }
    }

    private static void CreateTheNewMatrix(int[][] firstMat, int[][] secondMat, int[][] resultMat)
    {
        for (int row = 0; row < firstMat.Length; row++)
        {
            resultMat[row] = firstMat[row].Concat(secondMat[row].Reverse()).ToArray();
        }
    }

    private static bool TheMatricesFitted(int[][] firstMat, int[][] secondMat)
    {
        for (int row = 0; row < firstMat.Length - 1; row++)
        {
            if ((firstMat[row].Length + secondMat[row].Length) != (firstMat[row + 1].Length + secondMat[row + 1].Length))
            {
                return false;
            }
        }

        return true;
    }

    private static void FillTheMatrix(int N, int[][] firstMat)
    {
        for (int i = 0; i < N; i++)
        {
            firstMat[i] = Console.ReadLine()
                           .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                           .Select(int.Parse)
                           .ToArray();
        }
    }
}

