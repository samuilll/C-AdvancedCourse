using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

    class Task09ListOfPredicates
    {
        static void Main(string[] args)
        {

        const int first = 1;

        int last = int.Parse(Console.ReadLine());

        var dividers = Console.ReadLine()
            .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

        Func<int, int,bool> check = (n1, n2) => n1 % n2 == 0;

        bool flag = true;

        for (int i = first; i <= last; i++)
        {
            flag = true;

            foreach (var num in dividers)
            {
                if (!check(i,num))
                {
                    flag = false;
                    break;
                }
            }

            if (flag)
            {
                Console.Write($"{i} ");
            }
        }
    }

   
}

