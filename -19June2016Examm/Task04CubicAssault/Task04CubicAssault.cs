using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Region
{
    public string Name { get; set; }

    public long Black { get; set; }
    public long Green { get; set; }
    public long Red { get; set; }


    public Region(string name)
    {
        this.Black = 0;
        this.Green = 0;
        this.Red = 0;
        this.Name = name;
    }
    public static void ConvertColors(Region region)
    {
        region.Red += region.Green / 1000000;

        region.Green = region.Green % 1000000;

        region.Black += region.Red / 1000000;

        region.Red = region.Red % 1000000;
    }

}

class Task04CubicAssault
    {
        static void Main(string[] args)
        {

        var data = new Dictionary<string, Region>();

        var inputLine = Console.ReadLine()
            .Split(new string[] {" -> "}, StringSplitOptions.RemoveEmptyEntries)
            .ToArray();

        while (inputLine[0]!="Count em all")
        {

            string name = inputLine[0];

            string color = inputLine[1];

            long number = long.Parse(inputLine[2]);

            if (!data.ContainsKey(name))
            {
                data[name] = new Region(name);
            }

            switch (color)
            {
                case "Black":data[name].Black += number; break;
                case "Red": data[name].Red += number; break;
                case "Green": data[name].Green += number; break;
                default:
                    break;
            }
            if (data[name].Green >= 1000000)
            {
                data[name].Red += data[name].Green / 1000000;

                data[name].Green = data[name].Green % 1000000;
            }
            if (data[name].Red >= 1000000)
            {
                data[name].Black += data[name].Red / 1000000;

                data[name].Red = data[name].Red % 1000000;
            }

            inputLine = Console.ReadLine()
            .Split(new string[] { " -> " }, StringSplitOptions.RemoveEmptyEntries)
            .ToArray();
        }

     
        foreach (var pair in data.OrderByDescending(n=>n.Value.Black).ThenBy(n=>n.Key.Length).ThenBy(n=>n.Key))
        {
            Console.WriteLine(pair.Key);

            var order = GetTheOrder(pair.Value);

            foreach (var color in order.OrderByDescending(n => n.Value).ThenBy(n => n.Key))
            {
                Console.WriteLine($"-> {color.Key} : {color.Value}");
            }
        }


        }

    private static Dictionary<string,long> GetTheOrder(Region region)
    {

        var order = new Dictionary<string, long>();

        order["Black"] = region.Black;
        order["Red"] = region.Red;
        order["Green"] = region.Green;

        return order;


    }
}

// Cubica -> Black -> 1

//Cubica
//-> Red : 1000
//-> Black : 1
//-> Green : 0
