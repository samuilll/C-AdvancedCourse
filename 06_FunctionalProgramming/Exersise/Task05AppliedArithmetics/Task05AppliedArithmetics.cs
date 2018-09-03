using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    class Task05AppliedArithmetics
    {
        static void Main(string[] args)
        {
        var numbers = Console.ReadLine()
            .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(double.Parse)
            .ToArray();
        var operation = Console.ReadLine();

        Action<double[]> printTheArray = n => Console.WriteLine(string.Join(" ", n));

        while (operation!="end")
        {
            if (operation=="print")
            {
                printTheArray(numbers);
            }
            else
            {
                Func<double[], double[]> manipilateTheArray = DependsOnCommand(operation);

                numbers = manipilateTheArray(numbers);
            }

            operation = Console.ReadLine();
        }
    }

    private static Func<double[], double[]> DependsOnCommand(string operation)
    {
        switch (operation)
        {
            case "add": return n => n.Select(k => k + 1).ToArray();
            case "multiply": return n => n.Select(k => 2*k).ToArray();
            case "subtract": return n => n.Select(k => k - 1).ToArray();
            default: return null;
        }
    }
}

