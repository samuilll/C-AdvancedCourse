using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task04AddVAT
{
    class Task04AddVAT
    {
        static void Main(string[] args)
        {
            
            Console.WriteLine(string.Join("\n", Console.ReadLine()
                .Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(DoubleParser)
                .Select(AddVat)
                .Select(n=>$"{n:f2}")
                .ToList()));
        }

        public static double DoubleParser(string n)
        {
            return double.Parse(n);
        }

        public static double AddVat(double n)
        {
            return Math.Round(n + n / 5, 2);
        }
    }
}
