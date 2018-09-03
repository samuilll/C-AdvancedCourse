using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    class Task13TrFunction
    {
        static void Main(string[] args)
        {
        var limitNumber = int.Parse(Console.ReadLine());

        var names = Console.ReadLine()
           .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
           .ToArray();

        Func<string, int, bool> nameCheck = (name, num) => name.ToCharArray().Select(n => Convert.ToInt32(n)).Sum() >= num;

        Func<string[], Func<string, int, bool>, int, string> getFirstName = (arr, func, num) => arr.Where(n => func(n, num)).FirstOrDefault();

        Console.WriteLine(getFirstName(names,nameCheck,limitNumber));

 
    }
    }

