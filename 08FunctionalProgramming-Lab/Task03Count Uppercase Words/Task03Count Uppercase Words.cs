
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task03Count_Uppercase_Words
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(string.Join("\n", Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Where(n => Char.IsUpper(n[0]))
                .ToList()));
        }
    }
}
