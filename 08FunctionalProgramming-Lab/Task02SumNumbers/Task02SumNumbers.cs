using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task02SumNumbers
{
    class Task02SumNumbers
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine()
                    .Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToList();

            Console.WriteLine(numbers.Count);

            Console.WriteLine(numbers.Sum());
        }
    }
}
