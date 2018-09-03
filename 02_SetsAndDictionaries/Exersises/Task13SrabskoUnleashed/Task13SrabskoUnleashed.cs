using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;


    class Task13SrabskoUnleashed
    {
        static void Main(string[] args)
        {

        string input = Console.ReadLine();

        Dictionary<string, Dictionary<string, int>> data = new Dictionary<string, Dictionary<string, int>>();

        Regex regex = new Regex(@"^(?<singer>[A-Za-z ]+) @(?<venue>[A-Za-z ]+) (?<price>[0-9]+) (?<people>[0-9]+)$");

        while (input!="End")
        {
            if (regex.IsMatch(input))
            {
                string venue = regex.Match(input).Groups["venue"].Value;

                string singer = regex.Match(input).Groups["singer"].Value;

                int ticketPrice = int.Parse(regex.Match(input).Groups["price"].Value);

                int people = int.Parse(regex.Match(input).Groups["people"].Value);

                int profit = ticketPrice * people;

                if (!data.ContainsKey(venue))
                {
                    data[venue] = new Dictionary<string, int>();
                }
                if (!data[venue].ContainsKey(singer))
                {
                    data[venue][singer] = 0;
                }

                data[venue][singer] += profit;

            }

            input = Console.ReadLine();
        }

        foreach (var venueSingerPair in data)
        {
            Console.WriteLine(venueSingerPair.Key);

            foreach (var singerProfitPair in venueSingerPair.Value.OrderByDescending(n=>n.Value))
            {
                Console.WriteLine($"#  {singerProfitPair.Key} -> {singerProfitPair.Value}");
            }
        }
        }
    }

