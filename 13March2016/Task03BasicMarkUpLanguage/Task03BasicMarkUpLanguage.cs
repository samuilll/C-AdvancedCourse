using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

    class Task03BasicMarkUpLanguage
    {
        static void Main(string[] args)
        {

        Regex firstRegex = new Regex("<\\s*(?<operation>(inverse|reverse))\\s*content\\s*=\\s*\"(?<content>.+?)\"\\s*/\\s*>");

        Regex secondRegex = new Regex("<\\s*(?<operation>repeat)\\s*value\\s*=\\s*\"(?<repetition>\\s*\\d+?\\s*)\"\\s*content\\s*=\\s*\"(?<content>.+?)\"\\s*/>");

        var inputLine = Console.ReadLine();

        var outputCount = 1;

        while (inputLine!= "<stop/>")
        {
            if (firstRegex.IsMatch(inputLine))
            {
                var operation = firstRegex.Match(inputLine).Groups["operation"].Value.Trim();

                var content = firstRegex.Match(inputLine).Groups["content"].Value;
                if (content.Length>0)
                {
                    switch (operation)
                    {
                        case "inverse": PrintTheInverseResult(content, outputCount); break;
                        case "reverse": PrintTheReverseResult(content, outputCount); break;
                        default: break;
                    }
                    outputCount++;
                }
               
            }
            if (secondRegex.IsMatch(inputLine))
            {
                var repetitions = int.Parse(secondRegex.Match(inputLine).Groups["repetition"].Value.Trim());
                var content = secondRegex.Match(inputLine).Groups["content"].Value;
                if (content.Length>0)
                {
                    outputCount = PrintTheRepeatResult(repetitions, content, outputCount);
                }
            }

            inputLine = Console.ReadLine();
        }
        }

    private static int PrintTheRepeatResult(int repetitions, string content, int count)
    {
        for (int i = 0; i < repetitions; i++)
        {
            Console.WriteLine($"{count}. {content}");
            count++;
        }

        return count;
    }

    private static void PrintTheReverseResult(string content, int count)
    {
        Console.WriteLine($"{count}. {string.Join("",content.ToCharArray().Reverse())}");    }

    private static void PrintTheInverseResult(string content,int count)
    {
        var builder = new StringBuilder();

        for (int i = 0; i < content.Length; i++)
        {
            if (Char.IsLower(content[i]))
            {
                builder.Append(content[i].ToString().ToUpper());
            }
            else
            {
                builder.Append(content[i].ToString().ToLower());

            }
        }

        Console.WriteLine($"{count}. {builder.ToString()}");


    }
}

