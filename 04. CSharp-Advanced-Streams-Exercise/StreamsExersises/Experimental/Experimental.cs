using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Experimental
{
    class Experimental
    {
        static void Main(string[] args)
        {

            //var firstWords = Console.ReadLine().Split().ToList();

            //var secondWords = Console.ReadLine().Split().ToList();

            //var both = firstWords.Intersect(secondWords);

            //Console.WriteLine(string.Join(" ",both));

            var number = int.Parse(Console.ReadLine());

            var word = number.ToString();

            Console.WriteLine(word);

        }
    }
}
