using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Task03
{
    class Task03
    {
        static void Main(string[] args)
        {

            Regex regex = new Regex(@"((?<sign>{)|\[)[^\d]*?(?<digits>\d+)[^\d]*?(?(sign)}|\])");

            var linesNumber = int.Parse(Console.ReadLine());

            var builder = new StringBuilder();

            for (int i = 0; i < linesNumber; i++)
            {
                builder.Append(Console.ReadLine());
            }

            var matches = regex.Matches(builder.ToString()).Cast<Match>();

            var fullMatches = new List<string>();

            var numbersString = new List<string>();

            foreach (var match in matches)
            {
                if (match.Groups["digits"].Value.Length%3==0)
                {
                    var digits = match.Groups["digits"].Value;
                    var fullMatch = match.Value;
                    fullMatches.Add(fullMatch);
                    numbersString.Add(digits);
                }
            }

            var nums = new List<int>();

            for (int j=0; j<numbersString.Count;j++)
            {
                for (int i = 0; i < numbersString[j].Length-2; i+=3)
                {
                    var currentNum = int.Parse(numbersString[j][i].ToString() + numbersString[j][i+1].ToString() + numbersString[j][i+2].ToString());

                    if (currentNum - fullMatches[j].Length>0)
                    {
                        nums.Add(currentNum - fullMatches[j].Length);
                    }
                }
            }

            var output = string.Empty;
            foreach (var num in nums)
            {
                output += (char)num;
            }

            Console.WriteLine(output);

        }
    }
}
