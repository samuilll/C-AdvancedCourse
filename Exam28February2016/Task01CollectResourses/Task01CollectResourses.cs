using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Task01CollectResourses
{
    static void Main(string[] args)
    {

        var resourses = Console.ReadLine()
            .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .ToArray();

        Func<string, bool> isValid = n => n.IndexOf("wood") != -1
         || n.IndexOf("stone") != -1 || n.IndexOf("gold") != -1
         || n.IndexOf("food") != -1;

        var pathsNumber = int.Parse(Console.ReadLine());

        var MaxGatheredResourses = 0;

        for (int i = 0; i < pathsNumber; i++)
        {
            var startAndStep = Console.ReadLine()
            .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

            var gatheredIndexers = new List<int>();

            var currentGatheredResourses = 0;

            var start = startAndStep[0];

            var step = startAndStep[1];

            while (true)
            {
                if (gatheredIndexers.Contains(start))
                {
                    break;
                }

                var currentResourseNameAndValue = resourses[start].Split('_');

                currentGatheredResourses += GetTheResourses(resourses, isValid, gatheredIndexers, start, currentResourseNameAndValue);

                start = (step % resourses.Length + start) % resourses.Length;
            }

            MaxGatheredResourses = CheckTheMaxResourses(MaxGatheredResourses, currentGatheredResourses);

        }

        Console.WriteLine(MaxGatheredResourses);

    }

    private static int CheckTheMaxResourses(int MaxGatheredResourses, int currentGatheredResourses)
    {
        if (currentGatheredResourses > MaxGatheredResourses)
        {
            MaxGatheredResourses = currentGatheredResourses;
        }

        return MaxGatheredResourses;
    }

    private static int GetTheResourses(string[] resourses, Func<string, bool> isValid, List<int> gatheredIndexres, int start, string[] firstResourseNameAndValue)
    {

        var currentGatheredResourses = 0;

        if (isValid(resourses[start]))
        {
            if (firstResourseNameAndValue.Length == 1)
            {
                currentGatheredResourses += 1;

                gatheredIndexres.Add(start);
            }
            else
            {
                currentGatheredResourses += int.Parse(firstResourseNameAndValue[1]);
                gatheredIndexres.Add(start);
            }
        }

        return currentGatheredResourses;
    }
}
    

