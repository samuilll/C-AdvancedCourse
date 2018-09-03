using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;


class Task02CubicRube
{
    static void Main(string[] args)
    {

        var N = int.Parse(Console.ReadLine());

        var currentSequence = Console.ReadLine()
            .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .ToArray();

        BigInteger cellsSum = new BigInteger();

        long changedCells = 0;

        changedCells = 0;

        var hittedCells = new List<string>(); 

        while (currentSequence[0] != "Analyze")
        {
            var x = int.Parse(currentSequence[0]);
            var y = int.Parse(currentSequence[1]);
            var z = int.Parse(currentSequence[2]);

            long value = int.Parse(currentSequence[3]);


            if (isThePointIneTheCube(x, y, z, N) && !hittedCells.Contains(x.ToString()+y.ToString()+z.ToString())&& value>0)
            {
                cellsSum += value;
                changedCells += 1;
            }

            hittedCells.Add(x.ToString() + y.ToString() + z.ToString());


            currentSequence = Console.ReadLine()
            .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .ToArray();
        }

        Console.WriteLine(cellsSum);
        Console.WriteLine(N*N*N - changedCells);

    }

    private static bool isThePointIneTheCube(int x, int y, int z, int N)
    {
        bool isInTheCube = (x >= 0 && x < N) && (y >= 0 && y < N) && (z >= 0 && z < N);

        return isInTheCube;
    }
}

