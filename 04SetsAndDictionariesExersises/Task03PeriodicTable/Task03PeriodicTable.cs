using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Task03PeriodicTable
{
    static void Main(string[] args)
    {

        int compoundsNumber = int.Parse(Console.ReadLine());


        HashSet<string> elementsSet = new HashSet<string>();

        for (int i = 0; i < compoundsNumber; i++)
        {
            var compounds = Console.ReadLine()
          .Split(' ');

            foreach (var element in compounds)
            {
                
                    elementsSet.Add(element);
                
            }

        }

        Console.WriteLine(string.Join(" ", elementsSet.OrderBy(n => n)));

    }
}

