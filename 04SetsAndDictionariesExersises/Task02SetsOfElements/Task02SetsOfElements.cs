using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    class Task02SetsOfElements
    {
        static void Main(string[] args)
        {

        int[] paramemetres = Console.ReadLine()
            .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

        HashSet<int> firstSet = new HashSet<int>();

        HashSet<int> secondSet = new HashSet<int>();

        for (int i = 0; i < paramemetres[0]; i++)
        {
            firstSet.Add(int.Parse(Console.ReadLine()));
        }

        for (int i = 0; i < paramemetres[1]; i++)
        {
            secondSet.Add(int.Parse(Console.ReadLine()));
        }

        foreach (var number in firstSet)
        {
            if (secondSet.Contains(number))
            {
                Console.Write($"{number} ");
            }
        }
    }
    }

