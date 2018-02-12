using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Task01DangerousFloor
{
    class Task01DangerousFloor
    {
        static void Main(string[] args)
        {
            string[][] matrix = new string[8][];

            for (int i = 0; i < 8; i++)
            {
                matrix[i] = Console.ReadLine().Split(',').ToArray();
            }

            var input = Console.ReadLine();

            Regex regex = new Regex(@"(?<figure>[KRBQP])(?<startRow>\d)(?<startCol>\d)-(?<endRow>\d)(?<endCol>\d)");

            while (input != "END")
            {
                var match = regex.Match(input);

                var figure = match.Groups["figure"].Value;
                var startRow = int.Parse(match.Groups["startRow"].Value);
                var startCol = int.Parse(match.Groups["startCol"].Value);
                var endRow = int.Parse(match.Groups["endRow"].Value);
                var endCol = int.Parse(match.Groups["endCol"].Value);

                switch (figure)
                {
                    case "K":
                        {
                            if (!ThereIsSuchAFigure(matrix, figure, startRow, startCol))
                            {
                                Console.WriteLine("There is no such a piece!");
                            }
                            else if (!MoveIsValid(matrix,figure,startRow,startCol,endRow,endCol))
                            {
                                Console.WriteLine("Invalid move!");
                            }
                            else if (!IsInTheMatrix(matrix,endRow,endCol))
                            {
                                Console.WriteLine("Move go out of board!");
                            }
                            else
                            {
                                matrix[endRow][endCol] = figure;
                                matrix[startRow][startCol] = "x";
                            }
                           
                            break;
                        }
                    case "R":
                        {
                            if (!ThereIsSuchAFigure(matrix, figure, startRow, startCol))
                            {
                                Console.WriteLine("There is no such a piece!");
                            }
                            else if (!MoveIsValid(matrix, figure, startRow, startCol, endRow, endCol))
                            {
                                Console.WriteLine("Invalid move!");
                            }
                            else if (!IsInTheMatrix(matrix, endRow, endCol))
                            {
                                Console.WriteLine("Move go out of board!");
                            }
                            else
                            {
                                matrix[endRow][endCol] = figure;
                                matrix[startRow][startCol] = "x";
                            }
                            break;
                        }
                    case "B":
                        {
                            if (!ThereIsSuchAFigure(matrix, figure, startRow, startCol))
                            {
                                Console.WriteLine("There is no such a piece!");
                            }
                            else if (!MoveIsValid(matrix, figure, startRow, startCol, endRow, endCol))
                            {
                                Console.WriteLine("Invalid move!");
                            }
                            else if (!IsInTheMatrix(matrix, endRow, endCol))
                            {
                                Console.WriteLine("Move go out of board!");
                            }
                            else
                            {
                                matrix[endRow][endCol] = figure;
                                matrix[startRow][startCol] = "x";
                            }

                            break;

                        }
                    case "Q":
                        {
                            if (!ThereIsSuchAFigure(matrix, figure, startRow, startCol))
                            {
                                Console.WriteLine("There is no such a piece!");
                            }
                            else if (!MoveIsValid(matrix, figure, startRow, startCol, endRow, endCol))
                            {
                                Console.WriteLine("Invalid move!");
                            }
                            else if (!IsInTheMatrix(matrix, endRow, endCol))
                            {
                                Console.WriteLine("Move go out of board!");
                            }
                            else
                            {
                                matrix[endRow][endCol] = figure;
                                matrix[startRow][startCol] = "x";
                            }
                            break;
                        }
                    case "P":
                        {
                            if (!ThereIsSuchAFigure(matrix, figure, startRow, startCol))
                            {
                                Console.WriteLine("There is no such a piece!");
                            }
                            else if (!MoveIsValid(matrix, figure, startRow, startCol, endRow, endCol))
                            {
                                Console.WriteLine("Invalid move!");
                            }
                            else if (!IsInTheMatrix(matrix, endRow, endCol))
                            {
                                Console.WriteLine("Move go out of board!");
                            }
                            else
                            {
                                matrix[endRow][endCol] = figure;
                                matrix[startRow][startCol] = "x";
                            }
                            break;
                        }
                    default:
                        break;
                }
                input = Console.ReadLine();

            }
        }

        private static bool MoveIsValid(string[][] matrix, string figure, int startRow, int startCol, int endRow, int endCol)
        {
            switch (figure)
            {
                case "K":
                    {
                        bool first = endRow == startRow && endCol == startCol - 1;
                        bool second = endRow == startRow && endCol == startCol + 1;
                        bool thirth = endRow == startRow+1 && endCol == startCol;
                        bool fourth = endRow == startRow-1 && endCol == startCol;
                        bool sixth = endRow == startRow+1 && endCol == startCol + 1;
                        bool seventh = endRow == startRow+1 && endCol == startCol - 1;
                        bool eight = endRow == startRow-1 && endCol == startCol + 1;
                        bool fifth = endRow == startRow - 1 && endCol == startCol - 1;

                        if (first||second||thirth||fourth||fifth||sixth||seventh||eight)
                        {
                            return true;
                        }
                        break;
                    }

                case "R":
                    {
                        if ((endRow==startRow || endCol==startCol) )
                        {
                            return true;
                        }
                        break;
                    }
                case "B":
                    {
                        if (Math.Abs(endRow - startRow) == Math.Abs(endCol - startCol))
                        {
                            return true;
                        }
                        break;
                    }
                case "Q":
                    {
                        if ((endRow == startRow) ||( endCol == startCol) || Math.Abs(endRow - startRow) == Math.Abs(endCol - startCol))
                        {
                            return true;
                        }
                        break;
                    }
                case "P":
                    {
                        if (endRow==startRow-1 && endCol==startCol)
                        {
                            return true;
                        }
                        break;
                    }
                default:
                    break;
            }

            return false;
        }

        private static bool ThereIsSuchAFigure(string[][] matrix, string figure, int startRow, int startCol)
        {
            if (IsInTheMatrix(matrix, startRow, startCol))
            {
                if (matrix[startRow][startCol] == figure)
                {
                    return true;
                }
            }

            return false;
        }

        private static bool IsInTheMatrix(string[][] matrix, int startRow, int startCol)
        {

            if (startRow>=0 && startCol >= 0 && startRow < 8 && startCol < 8)
            {
                return true;
            }
            return false;
        }
    }
}
