using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Task08CustomComparator
{
    static void Main(string[] args)
    {

        var numbers = Console.ReadLine()
            .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

        Func<int, int, int> func = (n1, n2) =>
          (n1 % 2 == 0 && n2 % 2 != 0) ? -1 :
          (n1 % 2 != 0 && n2 % 2 == 0) ? 1 :
          n1.CompareTo(n2);

        Comparison<int> comparator = new Comparison<int>(func);

        Array.Sort<int>(numbers, comparator);

        Console.WriteLine(string.Join(" ",numbers));


    }
}

