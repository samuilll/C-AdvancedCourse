using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


    class Task04Events
    {
        static void Main(string[] args)
    {

        var inputNumber = int.Parse(Console.ReadLine());

        var pattern = @"^#(?<person>[a-zA-z]+):\s*@(?<location>[A-Za-z]+)\s*(?<hour>([0-1][0-9]:[0-5][0-9])|([02][0-3]:[0-5][0-9]))$";

        Regex regex = new Regex(pattern);

        var events = new Dictionary<string, Dictionary<string, List<string>>>();

        SetTheInformationAndPutItInTheDictionary(inputNumber, regex, events);

        var searchedLocations = Console.ReadLine()
            .Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
            .ToArray();

        SearchingTrouhgTheDictionaryAndPrintTheResult(events, searchedLocations);

    }

    private static void SearchingTrouhgTheDictionaryAndPrintTheResult(Dictionary<string, Dictionary<string, List<string>>> events, string[] searchedLocations)
    {
        foreach (var location in searchedLocations.OrderBy(n => n))
        {
            if (events.ContainsKey(location))
            {
                Console.WriteLine($"{location}:");

                var counter = 1;
                foreach (var person in events[location].OrderBy(n => n.Key))
                {
                    Console.WriteLine($"{counter}. {person.Key} -> {string.Join(", ", person.Value.OrderBy(n => n))}");
                    counter++;
                }
            }
        }
    }

    private static void SetTheInformationAndPutItInTheDictionary(int inputNumber, Regex regex, Dictionary<string, Dictionary<string, List<string>>> events)
    {
        for (int i = 0; i < inputNumber; i++)
        {
            var inputLine = Console.ReadLine();

            if (regex.IsMatch(inputLine))
            {
                var location = regex.Match(inputLine).Groups["location"].Value;

                var person = regex.Match(inputLine).Groups["person"].Value;

                var hour = regex.Match(inputLine).Groups["hour"].Value;

                if (!events.ContainsKey(location))
                {
                    events[location] = new Dictionary<string, List<string>>();
                }
                if (!events[location].ContainsKey(person))
                {
                    events[location][person] = new List<string>();
                }

                events[location][person].Add(hour);

            }

        }
    }
}

