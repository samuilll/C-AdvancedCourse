using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Task02ParkingSystem
{
    static void Main(string[] args)
    {

        bool[][] parkingLot = InitializeTheMatrix();

        ReadTheCommands(parkingLot);
    }

    private static bool[][] InitializeTheMatrix()
    {
        var matrixParams = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

        var rows = matrixParams[0];

        var cols = matrixParams[1];

        bool[][] matrix = new bool[rows][];

        matrix[0] = new bool[cols];

        return matrix;
    }

    private static void ReadTheCommands(bool[][] parkingLot)
    {
        while (true)
        {
            var command = Console.ReadLine()
               .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
               .ToArray();

            if (command[0] == "stop")
            {
                break;
            }

            int entryRow = int.Parse(command[0]);

            int searchedParkRow = int.Parse(command[1]);

            int searchedParkCol = int.Parse(command[2]);

            TryToParkTheCarAndPrintTheResult(parkingLot, entryRow, searchedParkRow, searchedParkCol);

        }
    }

    private static void TryToParkTheCarAndPrintTheResult(bool[][] parkingLot, int entryRow, int searchedParkRow, int searchedParkCol)
    {
        int moves = 1;

        if (parkingLot[searchedParkRow] == null)
        {
            parkingLot[searchedParkRow] = new bool[parkingLot[0].Length];
        }

        moves += Math.Abs(entryRow - searchedParkRow);

        if (TheSearchedParkPlaceIsFree(parkingLot, searchedParkRow, searchedParkCol))
        {
            moves += searchedParkCol;
            parkingLot[searchedParkRow][searchedParkCol] = true;
            Console.WriteLine($"{moves}");
        }
        else
        {
            SearchForAFreePlace(parkingLot, searchedParkRow, searchedParkCol, moves);
        }


    }

    private static void SearchForAFreePlace(bool[][] parkingLot, int searchedParkRow, int searchedParkCol, int moves)
    {
        var parkPlacesBothSidesCols = new List<int>();

        for (int leftCol = searchedParkCol - 1; leftCol > 0; leftCol--)
        {
            if (parkingLot[searchedParkRow][leftCol] == false)
            {
                parkPlacesBothSidesCols.Add(leftCol);
                break;
            }
        }
        for (int rightCol = searchedParkCol + 1; rightCol < parkingLot[0].Length; rightCol++)
        {
            if (parkingLot[searchedParkRow][rightCol] == false)
            {
                parkPlacesBothSidesCols.Add(rightCol);
                break;
            }
        }

        if (parkPlacesBothSidesCols.Count == 2)
        {
            var searchedCol = parkPlacesBothSidesCols.OrderBy(n => n = Math.Abs(searchedParkCol - n)).First();

            moves += searchedCol;

            Console.WriteLine($"{moves}");

            parkingLot[searchedParkRow][searchedCol] = true;

        }
        else if (parkPlacesBothSidesCols.Count == 1)
        {
            moves += parkPlacesBothSidesCols[0];

            Console.WriteLine($"{moves}");

            parkingLot[searchedParkRow][parkPlacesBothSidesCols[0]] = true;

        }
        else
        {
            Console.WriteLine($"Row {searchedParkRow} full");
        }

    }

    private static bool TheSearchedParkPlaceIsFree(bool[][] parkingLot, int searchedParkRow, int searchedParkCol)
    {
        if (parkingLot[searchedParkRow][searchedParkCol] == false)
        {
            return true;
        }

        return false;
    }

    private static void PrintTheMatrix(int[][] matrix)
    {
        for (int i = 0; i < matrix.Length; i++)
        {
            if (matrix[i].Length != 0)
            {
                Console.WriteLine(string.Join(" ", matrix[i]));

            }
        }
    }
}

