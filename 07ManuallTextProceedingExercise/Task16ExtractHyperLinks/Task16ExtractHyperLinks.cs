using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


    class Task16ExtractHyperLinks
    {
        static void Main(string[] args)
    {

        string allText = ReadTheLinesAndPutInTheStringBuilder();

        ExtractFromTextAndPrint(allText);
    }

    private static void ExtractFromTextAndPrint(string allText)
    {
        allText =  Regex.Replace(allText,@"\s+", " ");

        Regex regex = new Regex(@"<a[^<>]*?href[ ]*=[ ]*(?<quotes>[""'])?(?(quotes)(?<content>.+?)\1|(?<content>.+?)[ >]).*?</a>");

        if (regex.IsMatch(allText))
        {
            var matches = regex.Matches(allText).Cast<Match>().Select(n => n.Groups["content"]).ToList();

            foreach (var match in matches)
            {
                Console.WriteLine(match);
            }
        }
    }

    private static string ReadTheLinesAndPutInTheStringBuilder()
    {
        var inputLine = Console.ReadLine();

        var allTextBuilder = new StringBuilder();

        while (inputLine != "END")
        {
            allTextBuilder.Append(inputLine);

            inputLine = Console.ReadLine();
        }

        return allTextBuilder.ToString();
    }
}

