using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Task04FindEvensorOdds
{
    static void Main(string[] args)
    {
        var numbers = Console.ReadLine()
            .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

        var evenOrOdd = Console.ReadLine();

        Predicate<int> isIsearched = EvenOrOdd(evenOrOdd);

        var min = numbers[0];

        var max = numbers[1];

        for (int i = min; i <= max; i++)
        {
            if (isIsearched(i))
            {
                Console.Write(i+" ");
            }
        }
        Console.WriteLine();

    }

    private static Predicate<int> EvenOrOdd(string evenOrOdd)
    {
        switch (evenOrOdd)
        {
            case "even": return n => n % 2 == 0;
            case "odd": return n => n % 2 != 0;
            default: return null;
        }
    }
}

