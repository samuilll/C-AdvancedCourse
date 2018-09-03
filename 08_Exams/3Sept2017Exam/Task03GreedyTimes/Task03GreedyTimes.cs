using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Numerics;

namespace Task03GreedyTimes
{
    class Task03GreedyTimes
    {
        static void Main(string[] args)
        {

            long num = long.Parse(Console.ReadLine());

            BigInteger capacity = new BigInteger();

            capacity = num;

            var input = Console.ReadLine();

            Regex regAll = new Regex(@"\w+ \d+");
            Regex regGold = new Regex(@"[Gg][Oo][Ll][Dd] \d+");
            Regex regGem = new Regex(@"\w+[Gg][Ee][Mm] \d+");
            Regex regGash = new Regex(@"^\w{3} \d+");

            var data = new Dictionary<string, Dictionary<string, long>>();

            data["Gold"] = new Dictionary<string, long>();
            data["Gem"] = new Dictionary<string, long>();
            data["Cash"] = new Dictionary<string, long>();


            string[] splitted = regAll.Matches(input).Cast<Match>().Select(n => n.Value).ToArray();

            foreach (var treasure in splitted)
            {
                string name = treasure.Split().First();

                long amount = long.Parse(treasure.Split().Last());

                if (regGold.IsMatch(treasure) && CalculateAllAmount(data) + amount <= capacity)
                {
                    if (!data["Gold"].ContainsKey(name))
                    {
                        data["Gold"][name] = 0;
                    }
                    data["Gold"][name] += amount;
                }
                else if (regGem.IsMatch(treasure))
                {
                    if (data["Gold"].Values.Sum() >= data["Gem"].Values.Sum() + amount && (CalculateAllAmount(data) + amount) <= capacity)
                    {
                        data["Gem"][name] = amount;
                    }
                }
                if (regGash.IsMatch(treasure))
                {
                    if (data["Gem"].Values.Sum() >= data["Cash"].Values.Sum() + amount && CalculateAllAmount(data) + amount <= capacity)
                    {
                        data["Cash"][name] = amount;
                    }
                }
            }

            foreach (var pair in data.Where(n=>n.Value.Keys.Count>0).OrderByDescending(n=>n.Value.Values.Sum()))
            {
                Console.WriteLine($"<{pair.Key}> ${pair.Value.Values.Sum()}");

                foreach (var treasure in pair.Value.OrderByDescending(n=>n.Key).ThenBy(n=>n.Value))
                {
                    Console.WriteLine($"##{treasure.Key} - {treasure.Value}");
                }
            }
        }

        private static BigInteger CalculateAllAmount(Dictionary<string, Dictionary<string, long>> data)
        {

            BigInteger sum = data["Gold"].Values.Sum() + data["Gem"].Values.Sum() + data["Cash"].Values.Sum();

            return data["Gold"].Values.Sum() + data["Gem"].Values.Sum() + data["Cash"].Values.Sum();
        }
    }
}
