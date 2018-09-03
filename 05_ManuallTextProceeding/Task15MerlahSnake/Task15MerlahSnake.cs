using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Task15MerlahSnake
{
    static void Main(string[] args)
    {


        string text = Console.ReadLine();

        string pattern = Console.ReadLine();

        ShakeUntilItIsPossible(ref text, ref pattern);

        Console.WriteLine("No shake.");

        Console.WriteLine(text);

    }

    private static void ShakeUntilItIsPossible(ref string text, ref string pattern)
    {
        while (true)
        {
            var first = text.IndexOf(pattern);

            var second = text.LastIndexOf(pattern);

            if (first == second)
            {
                break;
            }

            if (pattern.Length == 0)
            {
                break;
            }

            text = text.Remove(first, pattern.Length);          

            second = text.LastIndexOf(pattern);

            text = text.Remove(second, pattern.Length);

            pattern = pattern.Remove(pattern.Length / 2, 1);

            Console.WriteLine("Shaked it.");

        }
    }
}

