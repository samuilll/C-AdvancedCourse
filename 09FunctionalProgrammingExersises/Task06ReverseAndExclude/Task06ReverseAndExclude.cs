using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    class Task06ReverseAndExclude
    {
        static void Main(string[] args)
        {
        var numbers = Console.ReadLine()
            .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

        var divisor = int.Parse(Console.ReadLine());

        Func<int[], int[]> func = RearrangeTheArray(divisor);

        Console.WriteLine(string.Join(" ",func(numbers)));
    }

    private static Func<int[], int[]> RearrangeTheArray(int divisor)
    {
        return n => n.Where(k => k % divisor != 0).Reverse().ToArray();
    }
}

