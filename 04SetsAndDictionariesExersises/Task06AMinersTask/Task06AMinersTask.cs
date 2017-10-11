using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    class Task06AMinersTask
    {
        static void Main(string[] args)
        {

        Dictionary<string, int> resoursesBook = new Dictionary<string, int>();

        string resourse = string.Empty;

        int quantity = 0;

        for (int i = 1; ; i++)
        {
            if (resourse=="stop")
            {
                break;
            }
            if (i%2!=0)
            {
                resourse = Console.ReadLine();
            }
            else
            {
                quantity = int.Parse(Console.ReadLine());
                if (!resoursesBook.ContainsKey(resourse))
                {
                    resoursesBook[resourse] = 0;

                }
                resoursesBook[resourse]+=quantity;
            }
        }

        foreach (var good in resoursesBook)
        {
            Console.WriteLine($"{good.Key} -> {good.Value}");
        }
    }
}

