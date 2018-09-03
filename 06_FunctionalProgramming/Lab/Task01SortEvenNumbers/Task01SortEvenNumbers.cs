using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Task01SortEvenNumbers
{
    class Task01SortEvenNumbers
    {
        static void Main(string[] args)
        {
            //    // First Solution
            //    var numbers = Console.ReadLine()
            //        .Split(new char[]{',',' '},StringSplitOptions.RemoveEmptyEntries)
            //        .Select(int.Parse)
            //        .ToList();

            //    Console.WriteLine(string.Join(", ",numbers.Where(n=>n%2==0).OrderBy(n=>n).ToList()));
            //

            // Second Solution

            Console.WriteLine(string.Join(", ",Console.ReadLine()
            .Split(new char[]{',',' '},StringSplitOptions.RemoveEmptyEntries)
            .Select(NumberParser)
            .Where(n=>n%2==0)
            .OrderBy(n=>n)
            .ToList()));            
        }
        public static int NumberParser(string n)
        {
            return int.Parse(n);
        }
    }
}

