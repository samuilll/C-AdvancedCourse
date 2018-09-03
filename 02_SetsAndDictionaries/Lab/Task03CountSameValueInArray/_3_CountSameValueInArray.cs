using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class _3_CountSameValueInArray
{
    static void Main(string[] args)
    {

        double[] numbers = Console.ReadLine()
            .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(double.Parse)
            .ToArray();

        SortedDictionary<double, int> occurencesOfNumers = new SortedDictionary<double, int>();

        foreach (var number in numbers)
        {
            if (!occurencesOfNumers.ContainsKey(number))
            {
                occurencesOfNumers[number] = 0;
            }
          
            occurencesOfNumers[number]++;
        }

        foreach (var pair in occurencesOfNumers)
        {
            Console.WriteLine($"{pair.Key} - {pair.Value} times");
        }
    }
}
