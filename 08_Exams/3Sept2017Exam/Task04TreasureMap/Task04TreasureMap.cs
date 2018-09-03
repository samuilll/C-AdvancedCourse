using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Task04TreasureMap
{
    class Task04TreasureMap
    {
        static void Main(string[] args)
        {

            Regex reg = new Regex(@"\![^!#]*?\b(?<street>[A-Za-z]{4})\b[^!#]*[^\d](?<number>\d{3})-(?<pass>\d{6}|\d{4})(?:[^\d!#][^!#]*)?\#|\#[^!#]*?\b(?<street>[A-Za-z]{4})\b[^!#]*[^\d](?<number>\d{3})-(?<pass>\d{6}|\d{4})(?:[^\d!#][^!#]*)?\!");

            var N = int.Parse(Console.ReadLine());
            var input = Console.ReadLine();

            for (int i = 0; i < N; i++)
            {
                var matches = reg.Matches(input).Cast<Match>().ToArray();

               var index = matches.Length / 2;

                var match = matches[index];

                var street = match.Groups["street"].Value;
                var number = match.Groups["number"].Value;
                var pass = match.Groups["pass"].Value;


                Console.Write($"Go to str. {street} {number}. ");
                Console.WriteLine($"Secret pass: {pass}.");

                input = Console.ReadLine();
            }
        }
    }
}
