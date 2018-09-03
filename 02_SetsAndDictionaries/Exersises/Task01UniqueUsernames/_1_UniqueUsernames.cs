using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class _1_UniqueUsernames
{
    static void Main(string[] args)
    {

        int numberOfLines = int.Parse(Console.ReadLine());

         HashSet<string> namesList = new HashSet<string>();

        for (int i = 0; i < numberOfLines; i++)
        {
            string name = Console.ReadLine();

            namesList.Add(name);
        }

        foreach (var name in namesList)
        {
            Console.WriteLine(name);
        }
    }
}

