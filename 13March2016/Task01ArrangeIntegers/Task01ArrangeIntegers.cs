using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    class Task01ArrangeIntegers
    {
        static void Main(string[] args)
        {

        var integers = Console.ReadLine()
            .Split(new char[] {' ',','},StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

        var table = new Dictionary<long, string>()
        {
            [0]="zero",
            [1] = "one",
            [2]="two",
            [3] = "three",
            [4] = "four",
            [5] = "five",
            [6] = "six",
            [7] = "seven",
            [8] = "eight",
            [9] = "nine"
        };

        var integersAsStringDict = new List<KeyValuePair<string,int>>();

        foreach (var number in integers)
        {
            var stringNumber = new StringBuilder();

            foreach (var digit in number.ToString())
            {
                stringNumber.Append(table[int.Parse(digit.ToString())]);
            }

            
            integersAsStringDict.Add(new KeyValuePair<string, int>(stringNumber.ToString(), number));
        }

        Console.WriteLine(string.Join(", ",integersAsStringDict.OrderBy(n=>n.Key).Select(n=>n.Value)));


        }
    }

