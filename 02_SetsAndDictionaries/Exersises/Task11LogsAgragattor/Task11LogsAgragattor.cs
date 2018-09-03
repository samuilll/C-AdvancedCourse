using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;


class Task11LogsAgragattor
{
    static void Main(string[] args)
    {

        int inputNumber = int.Parse(Console.ReadLine());

        Dictionary<string, Dictionary<string, int>> information = new Dictionary<string, Dictionary<string, int>>();

        var regex = new Regex(@"(?<ip>\S+) (?<user>\w+) (?<duration>\d+)$");

        for (int i = 0; i < inputNumber; i++)
        {
            string input = Console.ReadLine();

            var user = regex.Match(input).Groups["user"].Value;

            var ip = regex.Match(input).Groups["ip"].Value;

            int duration = int.Parse(regex.Match(input).Groups["duration"].Value);

            UpdateTheInformation(information, user, ip, duration);

        }

        PrintTheResult(information);
    }

    private static void PrintTheResult(Dictionary<string, Dictionary<string, int>> information)
    {
        foreach (var userInfo in information.OrderBy(n => n.Key))
        {
            List<string> ipList = userInfo.Value.Keys.OrderBy(n => n).ToList();

            Console.WriteLine($"{userInfo.Key}: {userInfo.Value.Values.Sum()} [{string.Join(", ", ipList)}]");
          
        }
    }

    private static void UpdateTheInformation(Dictionary<string, Dictionary<string, int>> information, string user, string ip, int duration)
    {
        if (!information.ContainsKey(user))
        {
            information[user] = new Dictionary<string, int>();
        }
        if (!information[user].ContainsKey(ip))
        {
            information[user][ip]=0;
        }

        information[user][ip] += duration;
    }
}

