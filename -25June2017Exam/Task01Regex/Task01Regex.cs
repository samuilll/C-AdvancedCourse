using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Task01Regex
{
    class Task01Regex
    {
        static void Main(string[] args)
        {


            var input = Console.ReadLine();

            Regex regex = new Regex(@"\[([^\[\s]+)<(?<number1>\d+)REGEH(?<number2>\d+)>([^\]\s]+)\]");

            var matches = regex.Matches(input).Cast<Match>().ToArray();

            var builder = new StringBuilder();

            var index = 0;

            foreach (var match in matches)
            {
                var number1 = int.Parse(match.Groups["number1"].Value);

                var number2 = int.Parse(match.Groups["number2"].Value);

                index += number1;

                AppendDigitIndex(input, builder, index);

                index += number2;

                AppendDigitIndex(input, builder, index);

            }

            Console.WriteLine(builder.ToString());
        }

        private static void AppendDigitIndex(string input, StringBuilder builder, int index)
        {
            if (index >= input.Length)
            {
                var currentIndex = (index % input.Length)+1;

                builder.Append(input[currentIndex]);
            }
            else
            {
                builder.Append(input[index]);
            }
        }
    }
}
