using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    class Task04CountSymbols
    {
        static void Main(string[] args)
        {


        string text = Console.ReadLine();

        SortedDictionary<char, int> symbolsList = new SortedDictionary<char, int>();

        for (int i = 0; i < text.Length; i++)
        {
            if (!symbolsList.ContainsKey(text[i]))
            {
                symbolsList[text[i]] = 0;
            }

            symbolsList[text[i]]++;
        }

        foreach (var symbolCount in symbolsList)
        {
            Console.WriteLine($"{symbolCount.Key}: {symbolCount.Value} time/s");
        }
    }
    }

