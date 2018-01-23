using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task05FunctionalSolution
{
    class Task05FunctionalSolution
    {
        static void Main(string[] args)
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

            var condition = Console.ReadLine();

            var age = int.Parse(Console.ReadLine());

            var format = Console.ReadLine();

            Func<int,bool> tester = CreateTester(condition, age);

            Action<KeyValuePair<string, int>> printer = CreatePrinter(format);

            InvokePrinter(dict, tester, printer);
            }

        private static void InvokePrinter(Dictionary<string, int> dict, Func<int, bool> tester, Action<KeyValuePair<string, int>> printer)
        {
            foreach (var pair in dict)
            {
                if (tester(pair.Value))
                {
                    printer(pair);
                }                
            }
        }


        private static Action<KeyValuePair<string, int>> CreatePrinter(string format)
        {
            switch (format)
            {
                case "name":

                    return pair => Console.WriteLine(pair.Key);

                case "age":

                    return pair => Console.WriteLine(pair.Value);

                case "name age":

                    return pair => Console.WriteLine($"{pair.Key} - {pair.Value}");

                default: return null;
            }
        }

        private static Func<int, bool> CreateTester(string condition, int age)
        {
            if (condition=="older")
            {
                return n => n >= age;
            }
            else
            {
                return n => n < age;
            }
        }
    }
}
