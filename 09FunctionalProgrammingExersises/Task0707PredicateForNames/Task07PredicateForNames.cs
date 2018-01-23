using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    class Task07PredicateForNames
    {
        static void Main(string[] args)
        {

        var limitLength = int.Parse(Console.ReadLine());

        var names = Console.ReadLine()
            .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .ToArray();

        Func<string, bool> f = n => n.Length <= limitLength;

      //  Predicate<string> checker = n => n.Length <= limitLength;

        Console.WriteLine(string.Join(Environment.NewLine,names.Where(f)));
        }
    }
    
