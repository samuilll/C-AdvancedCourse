using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task05FilterByAge
{
    class Task05FilterByAge
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> dict = GetTheInformationAndPutInInTheDict();

            var condition = Console.ReadLine();

            var age = int.Parse(Console.ReadLine());

            var format = Console.ReadLine();

            dict = SortDict(dict, condition, age);

            PrintTheResult(dict, format);
        }

        private static Dictionary<string, int> GetTheInformationAndPutInInTheDict()
        {
            var linesNumber = int.Parse(Console.ReadLine());

            var dict = new Dictionary<string, int>();

            for (int i = 0; i < linesNumber; i++)
            {
                var pair = Console.ReadLine()
                    .Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                var currentName = pair[0];

                var currentAge = int.Parse(pair[1]);

                dict[currentName] = currentAge;
            }

            return dict;
        }

        private static void PrintTheResult(Dictionary<string, int> dict, string format)
        {
            switch (format)
            {
                case "name":
                    foreach (var pair in dict)
                    {
                        Console.WriteLine(pair.Key);
                    }
                    break;
                case "age":
                    foreach (var pair in dict)
                    {
                        Console.WriteLine(pair.Value);
                    }
                    break;
                case "name age":
                    foreach (var pair in dict)
                    {
                        Console.WriteLine($"{pair.Key} - {pair.Value}");
                    }
                    break;
            }
        }

        public static Dictionary<string,int> SortDict(Dictionary<string,int> dict,string condition, int age)
        {

            var newDict = new Dictionary<string,int>();

            foreach (var pair in dict)
            {
                if (condition == "younger")
                {
                    if (pair.Value < age)
                    {
                        newDict[pair.Key] = pair.Value;
                    }
                }
                else if (condition == "older")
                {
                    if (pair.Value > age)
                    {
                        newDict[pair.Key] = pair.Value;
                    }
                }
            }

            return newDict;
        }
    }
}
