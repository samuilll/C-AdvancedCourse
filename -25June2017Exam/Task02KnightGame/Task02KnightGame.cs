using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task02KnightGame
{
    class Task02KnightGame
    {
        static void Main(string[] args)
        {

            var N = int.Parse(Console.ReadLine());

            var matrix = new char[N][];

            for (int i = 0; i < N; i++)
            {
                matrix[i] = Console.ReadLine().ToCharArray();
            }



            var bestRow = 0;

            var bestCol = 0;

            var removedCounter = 0;

            var mostDangerousKnight = -1;

            while (true)
            {
                for (int row = 0; row < N; row++)
                {

                    for (int col = 0; col < N; col++)
                    {
                        var currentDangerousKnight = 0;

                        if (matrix[row][col] == 'K')
                        {
                            currentDangerousKnight = CheckThePossibleOponents(matrix, row, col, N);
                        }
                        if (mostDangerousKnight < currentDangerousKnight)
                        {
                            mostDangerousKnight = currentDangerousKnight;
                            bestRow = row;
                            bestCol = col;
                        }
                    }
                }

           //     PrintTheMatrix(matrix);

                if (mostDangerousKnight!=0)
                {
                    matrix[bestRow][bestCol] = '0';
                    removedCounter += 1;
                    mostDangerousKnight = 0;
                }
                else
                {
                    break;
                }
            }

            Console.WriteLine(removedCounter);
        }

        private static void PrintTheMatrix(char[][] matrix)
        {
            foreach (var line in matrix)
            {
                Console.WriteLine(string.Join(", ",line));
            }
            Console.WriteLine();
        }

        private static int CheckThePossibleOponents(char[][] matrix, int row, int col, int N)
        {
            var fightCounter = 0;

            bool first = row + 2 < N && col + 1 < N;
            bool second = row + 2 < N && col - 1 >= 0;
            bool third = row - 2 >= 0 && col + 1 < N;
            bool fourth = row - 2 >= 0 && col - 1 >= 0;
            bool fifth = row - 1 >= 0 && col + 2 < N;
            bool sixth = row + 1 < N && col + 2 < N;
            bool seventh = row - 1 >= 0 && col - 2 >= 0;
            bool eight = row + 1 < N && col - 2 >= 0;

            if (first)
            {
                if (HasHorse(matrix, row + 2, col + 1))
                {
                    fightCounter += 1;
                }
            }
            if (second)
            {
                if (HasHorse(matrix, row + 2, col - 1))
                {
                    fightCounter += 1;
                }
            }
            if (third)
            {
                if (HasHorse(matrix, row - 2, col + 1))
                {
                    fightCounter += 1;
                }
            }
            if (fourth)
            {
                if (HasHorse(matrix, row - 2, col - 1))
                {
                    fightCounter += 1;
                }
            }
            if (fifth)
            {
                if (HasHorse(matrix, row -1, col + 2))
                {
                    fightCounter += 1;
                }
            }
            if (sixth)
            {
                if (HasHorse(matrix, row + 1, col + 2))
                {
                    fightCounter += 1;
                }
            }
            if (seventh)
            {
                if (HasHorse(matrix, row - 1, col - 2))
                {
                    fightCounter += 1;
                }
            }
            if (eight)
            {
                if (HasHorse(matrix, row + 1, col - 2))
                {
                    fightCounter += 1;
                }
            }


            return fightCounter;
        }

        private static bool HasHorse(char[][] matrix, int row, int col)
        {
            if (matrix[row][col] == 'K')
            {
                return true;
            }
            return false;
        }
    }
}
