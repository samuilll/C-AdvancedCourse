using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

 class _0_TestingThePerformanceOfTheProgramme
    {
        static void Main(string[] args)
        {

        var watch = System.Diagnostics.Stopwatch.StartNew();

        var list = new List<string>();

        for (int i = 0; i < 10000000; i++)
        {
            list.Add(i.ToString());
        }

        watch.Stop();

        Console.WriteLine(watch.ElapsedTicks);

        watch = Stopwatch.StartNew();

        list.Contains("888888");

        watch.Stop();

        Console.WriteLine(watch.ElapsedTicks);

        watch = Stopwatch.StartNew();

        var set = new HashSet<string>();

        for (int i = 0; i < 10000000; i++)
        {
            set.Add(i.ToString());
        }

        watch.Stop();

        Console.WriteLine(watch.ElapsedTicks);

        watch = Stopwatch.StartNew();

        set.Contains("888888");

        watch.Stop();

        Console.WriteLine(watch.ElapsedTicks);
    }
    }

