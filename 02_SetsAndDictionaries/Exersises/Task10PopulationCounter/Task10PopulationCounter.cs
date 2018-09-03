using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    class Task10PopulationCounter
    {
        static void Main(string[] args)
        {

        string[] input = Console.ReadLine()
            .Split('|')
            .ToArray();

        Dictionary<string, Dictionary<string, long>> dataBase = new Dictionary<string, Dictionary<string, long>>();
        while (input[0]!="report")
        {
            string town = input[0];

            string country = input[1];

            long population = long.Parse(input[2]);

            InputTheInformacionlongheDatabase(dataBase,town,country,population); 

            input = Console.ReadLine()
            .Split('|')
            .ToArray();
        }

        PrlongTheResult(dataBase);
        }

    private static void PrlongTheResult(Dictionary<string, Dictionary<string, long>> dataBase)
    {
        foreach (var country in dataBase.OrderByDescending(n=>n.Value.Values.Sum()))
        {
            Console.WriteLine($"{country.Key} (total population: {country.Value.Values.Sum()})");

            foreach (var town in country.Value.OrderByDescending(n=>n.Value))
            {
                Console.WriteLine($"=>{town.Key}: {town.Value}");
            }
        }    }

    private static void InputTheInformacionlongheDatabase(Dictionary<string, Dictionary<string, long>> dataBase, 
        string town, string country, long population)
    {
        if (!dataBase.ContainsKey(country))
        {
            dataBase[country] = new Dictionary<string, long>();
        }
        dataBase[country][town] = population;
    }
}

