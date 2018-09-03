using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    class Task01ActionPrint
    {
        static void Main(string[] args)
        {

        Action<string[]> print = n => Console.WriteLine(string.Join(Environment.NewLine,n));

        var text = Console.ReadLine().Split().ToArray();

        print(text);

        }
    }

