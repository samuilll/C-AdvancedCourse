using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;



class Task09UserLogs
    {
        static void Main(string[] args)
        {

        SortedDictionary<string, Dictionary<string,int>> data = new SortedDictionary<string, Dictionary<string,int>>();

        string input = Console.ReadLine();

        var nameRegex = new Regex(@"(?<=user=)\w+");

        var ipRegex = new Regex(@"(?<=IP=).+(?= message)");

        while (input!="end")
        {
            var name = nameRegex.Match(input).ToString();

            var ip = ipRegex.Match(input).ToString();

            if (!data.ContainsKey(name))
            {
                data[name] = new Dictionary<string, int>();
            }
            if (!data[name].ContainsKey(ip))
            {
                data[name][ip] = 0;
            }
            data[name][ip] += 1;
            
            input = Console.ReadLine();
        }

        foreach (var name in data)
        {
            Console.WriteLine($"{name.Key}: ");

            List<string> ipNames = data[name.Key].Select(n => n.Key).ToList();

            for (int i = 0; i < ipNames.Count; i++)
            {
                if (i==ipNames.Count-1)
                {
                    Console.Write($"{ipNames[i]} => {data[name.Key][ipNames[i]]}.\n");
                }
                else
                {
                    Console.Write($"{ipNames[i]} => {data[name.Key][ipNames[i]]}, ");

                }
            }
        }


        }
    }

