using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;


class Task12LegendaryFarming
{
    static void Main(string[] args)
    {

        var regex = new Regex(@"(?<quantity>\d+) (?<material>\w+)");

        var keyMaterials = new Dictionary<string, long>()
        {
            ["fragments"] = 0,
            ["motes"] = 0,
            ["shards"] = 0
        };

        var junkMaterials = new Dictionary<string, long>();
        
        var item = string.Empty;

        int counter = 10;

        while (counter>0)
        {
            var input = Console.ReadLine().ToLower();

            var matches = regex.Matches(input).Cast<Match>().ToList();

            foreach (Match match in matches)
            {
                var quantity = long.Parse(match.Groups["quantity"].Value);

                var material = match.Groups["material"].Value;

                FillTheMaterailsLists(keyMaterials, junkMaterials, quantity, material);

                item = ThisItemIsDone(keyMaterials);

                if (item != string.Empty)
                {
                    switch (item)
                    {
                        case "shards":
                            {
                                keyMaterials[item] -= 250;
                                item = "Shadowmourne";
                                break;
                            }
                        case "fragments":
                            {
                                keyMaterials[item] -= 250;
                                item = "Valanyr";
                                break;
                            }
                        case "motes":
                            {
                                keyMaterials[item] -= 250;
                                item = "Dragonwrath";
                                break;
                            }
                    }

                    counter = -1;
                    break;
                }
            }

            counter--;

        }

        Console.WriteLine($"{item} obtained!");

        foreach (var materialQuantityPair in keyMaterials.OrderByDescending(n => n.Value).ThenBy(n => n.Key))
        {
            Console.WriteLine($"{materialQuantityPair.Key}: {materialQuantityPair.Value}");
        }
        foreach (var materialQuantityPair in junkMaterials.OrderBy(n => n.Key))
        {
            Console.WriteLine($"{materialQuantityPair.Key}: {materialQuantityPair.Value}");
        }

    }

    private static string ThisItemIsDone(Dictionary<string, long> keyMaterials)
    {
        foreach (var materialQuantityPair in keyMaterials)
        {
            if (materialQuantityPair.Value >= 250)
            {
                return materialQuantityPair.Key;
            }
        }

        return string.Empty;
    }

    private static void FillTheMaterailsLists(Dictionary<string, long> keyMaterials, Dictionary<string, long> junkMaterials, long quantity, string material)
    {
        if (material == "shards" || material == "fragments" || material == "motes")
        {
     
            keyMaterials[material] += quantity;
        }
        else
        {
            if (!junkMaterials.ContainsKey(material))
            {
                junkMaterials[material] = 0;
            }

            junkMaterials[material] += quantity;
        }
    }
}

