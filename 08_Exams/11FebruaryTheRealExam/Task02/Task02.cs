using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task02
{
    class Task02
    {
        static void Main(string[] args)
        {

            var N = int.Parse(Console.ReadLine());

            var matrix = new char[N][];

            for (int i = 0; i < N; i++)
            {
                matrix[i] = Console.ReadLine().ToCharArray();
            }

            var commands = Console.ReadLine();

            bool samWins = false;

            foreach (var command in commands)
            {
                List<int> overParams = EnemyMoves(matrix);

                //Console.WriteLine();
                //PrintTheMatrix(matrix);
                //Console.WriteLine();

                if (overParams.Count > 0)
                {
                    Console.WriteLine($"Sam died at {overParams[0]}, {overParams[1]}");
                    PrintTheMatrix(matrix);
                    break;
                }

                samWins = SamMoves(matrix, command);

                if (samWins)
                {
                    Console.WriteLine("Nikoladze killed!");
                    PrintTheMatrix(matrix);
                    break;
                }


            }
        }

        private static void PrintTheMatrix(char[][] matrix)
        {
            foreach (var line in matrix)
            {
                Console.WriteLine(string.Join("", line));
            }
        }

        private static bool SamMoves(char[][] matrix, char command)
        {
            bool samWin = false;

            for (int row = 0; row < matrix.Length; row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    if (matrix[row][col] == 'S')
                    {
                        switch (command)
                        {
                            case 'U':
                                {
                                    if (row - 1 >= 0)
                                    {
                                        if (matrix[row - 1].Contains('N'))
                                        {
                                            samWin = true;

                                            var colIndex = string.Join("", matrix[row - 1]).IndexOf('N');
                                            matrix[row - 1][colIndex] = 'X';
                                        }
                                        matrix[row - 1][col] = 'S';
                                        matrix[row][col] = '.';
                                    }
                                    break;
                                }
                            case 'D':
                                {
                                    if (row + 1 < matrix.Length)
                                    {
                                        if (matrix[row + 1].Contains('N'))
                                        {
                                            samWin = true;

                                            var colIndex = string.Join("", matrix[row + 1]).IndexOf('N');
                                            matrix[row + 1][colIndex] = 'X';
                                        }
                                        matrix[row + 1][col] = 'S';
                                        matrix[row][col] = '.';
                                    }
                                    break;
                                }
                            case 'L':
                                {
                                    if (col - 1 >= 0)
                                    {

                                        matrix[row][col - 1] = 'S';
                                        matrix[row][col] = '.';
                                    }
                                    break;
                                }
                            case 'R':
                                {
                                    if (col + 1 < matrix[row].Length)
                                    {
                                        matrix[row][col + 1] = 'S';
                                        matrix[row][col] = '.';
                                    }
                                    break;
                                }
                            case 'W':
                                {

                                    break;
                                }
                            default:
                                break;
                        }
                        return samWin;
                    }
                }
            }

            return samWin;
        }

        private static List<int> EnemyMoves(char[][] matrix)
        {
            var overParams = new List<int>();

            for (int row = 0; row < matrix.Length; row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    if (matrix[row][col] == 'b')
                    {
                        if (RowContainPLayerRight(matrix,row,col,overParams))
                        {
                            overParams.Add(row);
                            overParams.Add(col + 1);

                        }
                        if (col + 1 < matrix[row].Length)
                        {                          
                            matrix[row][col + 1] = 'b';
                            matrix[row][col] = '.';
                            col += 1;
                        }
                        else
                        {
                            matrix[row][col] = 'd';
                            if (RowContainPLayerLeft(matrix, row, col, overParams))
                            {
                                overParams.Add(row);
                                overParams.Add(col + 1);
                            }
                            continue;
                        }
                    }

                    if (matrix[row][col] == 'd')
                    {
                        if (RowContainPLayerLeft(matrix,row,col,overParams))
                        {
                            overParams.Add(row);
                            overParams.Add(col + 1);
                        }
                        if (col - 1 >= 0)
                        {
                          
                            matrix[row][col - 1] = 'd';
                            matrix[row][col] = '.';
                        }
                        else
                        {
                            matrix[row][col] = 'b';
                            if (RowContainPLayerRight(matrix, row, col, overParams))
                            {
                                overParams.Add(row);
                                overParams.Add(col + 1);

                            }
                            continue;
                        }
                    }
                }
            }

            return overParams;
        }

        private static bool RowContainPLayerLeft(char[][] matrix, int row, int col,List<int>overParams)
        {
            bool playerLost = false;

            for (int i = col; i>=0; i--)
            {
                if (matrix[row][i] == 'S')
                {
                    matrix[row][i] = 'X';
                    overParams.Add(row);
                    overParams.Add(i);
                    playerLost = true;
                }
            }

            return playerLost;
        }

        private static bool RowContainPLayerRight(char[][] matrix, int row, int col,List<int>overParams)
        {
            bool playerLost = false;
            for (int i = col; i < matrix[row].Length; i++)
            {
                if (matrix[row][i]=='S')
                {
                    matrix[row][i] = 'X';
                    overParams.Add(row);
                    overParams.Add(i);
                    playerLost = true;
                }
            }

            return playerLost; 
        }
    }
}
