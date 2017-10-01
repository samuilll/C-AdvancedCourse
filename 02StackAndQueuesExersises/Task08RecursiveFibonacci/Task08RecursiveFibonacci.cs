using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Task08RecursiveFibonacci
{

    private static long[] numbers;
    static void Main(string[] args)
    {

        long number = long.Parse(Console.ReadLine());

        numbers = new long[number];

        long serachedNumber = GetFibonacci(number);

        Console.WriteLine(serachedNumber);
    }

    private static long GetFibonacci(long number)
    {

        if (number <= 2)
        {
            return 1;
        }
        if (numbers[number - 1] != 0)
        {
            return numbers[number - 1];
        }

        return numbers[number - 1] = GetFibonacci(number - 1) + GetFibonacci(number - 2);
    }
}


