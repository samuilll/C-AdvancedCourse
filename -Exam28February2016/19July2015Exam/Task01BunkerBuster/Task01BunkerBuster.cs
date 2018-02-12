using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task01BunkerBuster
{
    class Task01BunkerBuster
    {

        public static int destroyedCells = 0;

        static void Main(string[] args)
        {
        int destroyedCells = 0;

        var parameters = Console.ReadLine()
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

            var N = parameters[0];
            var M = parameters[1];

            var matrix = new int[N][];

            for (int i = 0; i < N; i++)
            {
                matrix[i] = Console.ReadLine()
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
            }

            var input = Console.ReadLine()
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();


            while (input[0] != "cease")
            {
                int row = int.Parse(input[0]);
                int col = int.Parse(input[1]);
                int bombPower = (input[2].ToCharArray()[0]);
                var halfBombPower = (int)Math.Ceiling((decimal)bombPower / 2);

                HitTheMatrix(matrix, row, col, N, M, bombPower, halfBombPower);

                input = Console.ReadLine()
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

            }

            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < M; j++)
                {
                    if (matrix[i][j]<=0)
                    {
                        destroyedCells++;
                    }
                }
            }
            var percentage = (destroyedCells * 100.0) / (N * M);
            Console.WriteLine($"Destroyed bunkers: {destroyedCells}");
            Console.WriteLine($"Damage done: {percentage:F1} %");

        }

        private static void HitTheMatrix(int[][] matrix, int row, int col, int N, int M, int bombPower, int halfBombPower)
        {
            matrix[row][col] -= bombPower;
          
            if (IsInTheMatrix(N, M, row - 1, col - 1))
            {
                matrix[row - 1][col - 1] -= halfBombPower;

            
            }
            if (IsInTheMatrix(N, M, row - 1, col))
            {
                matrix[row - 1][col] -= halfBombPower;

              
            }
            if (IsInTheMatrix(N, M, row - 1, col + 1))
            {
                matrix[row - 1][col + 1] -= halfBombPower;

            }        
            if (IsInTheMatrix(N, M, row, col - 1))
            {
                matrix[row][col - 1] -= halfBombPower;

            }           
            if (IsInTheMatrix(N, M, row, col + 1))
            {
                matrix[row][col + 1] -= halfBombPower;

            }
            if (IsInTheMatrix(N, M, row+1, col - 1))
            {
                matrix[row+1][col - 1] -= halfBombPower;

            }
            if (IsInTheMatrix(N, M, row+1, col))
            {
                matrix[row+1][col] -= halfBombPower;

            }
            if (IsInTheMatrix(N, M, row+1, col + 1))
            {
                matrix[row+1][col + 1] -= halfBombPower;

            }
        }

        private static bool IsInTheMatrix(int N, int M, int row, int col)
        {
            return row >= 0 && col >= 0 && row < N && col < M;
        }
    }
}
