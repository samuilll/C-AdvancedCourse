using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Task03CustomMinFunction
{
    static void Main(string[] args)
    {

        var numbers = Console.ReadLine()
            .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(double.Parse)
            .ToArray();

        Func<double[], double> min = n => FindMin(n);

        Console.WriteLine(min(numbers));
    }

    private static double FindMin(double[] numbers)
    {
        var min = double.MaxValue;

        foreach (var n in numbers)
        {
            if (n < min)
            {
                min = n;
            }
        }

        return min;

    }
}

