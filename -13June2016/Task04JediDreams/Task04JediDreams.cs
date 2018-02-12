using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


    class Task04JediDreams
    {
        static void Main(string[] args)
        {

        var N = int.Parse(Console.ReadLine());

        var linesData = new StringBuilder();

        for (int i = 0; i < N; i++)
        {
            var line = Console.ReadLine();

            linesData.Append(line+" ");
        }

        var data = new Dictionary<string, List<string>>();

        Regex declareMethodReg = new Regex(@"static\s+?\w+\s+?(?<name>\w+?)\(.+?(?=static|$)");

        Regex internalMethodsReg = new Regex(@"(?<name>[A-Z]\w*)\((?<value>.*?\))");


        var declaredMethods = declareMethodReg.Matches(linesData.ToString()).Cast<Match>().ToArray();

        foreach (var method in declaredMethods)
        {
            data[method.Groups["name"].Value] = new List<string>();

          
                var internalMethodsList = internalMethodsReg.Matches(method.Value).Cast<Match>().ToList();

                internalMethodsList.RemoveAt(0);

                foreach (var internalMethod in internalMethodsList)
                {
                    Input(data, internalMethodsReg, method, internalMethod);
                }
            
 
        }

        foreach (var pair in data.OrderByDescending(n=>n.Value.Count).ThenBy(n=>n.Key))
        {
            if (pair.Value.Count!=0)
            {
                Console.WriteLine($"{pair.Key} -> {pair.Value.Count} -> {string.Join(", ", pair.Value.OrderBy(n => n))}");
            }
            else
            {
                Console.WriteLine($"{pair.Key}->None");
            }
        }
    }

    private static void Input(Dictionary<string, List<string>> data, Regex internalMethodsReg, Match method, Match internalMethod)
    {
        var name = internalMethod.Groups["name"].Value;
        data[method.Groups["name"].Value].Add(name);
        var value = internalMethod.Groups["value"].Value;

        if (internalMethodsReg.IsMatch(value))
        {
            Input(data, internalMethodsReg, method, internalMethodsReg.Match(internalMethod.Groups["value"].Value));
        }
    }
}
    
