using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    class Task01JediMeditation
    {
        static void Main(string[] args)
        {

        int linesNumber = int.Parse(Console.ReadLine());

        var m = new List<string>();
        var k = new List<string>();
        var p = new List<string>();
        var slavAndTosho = new List<string>();
        string output =string.Empty;
        bool isThereAMaster = false;

        for (int i = 0; i < linesNumber; i++)
        {
            var line = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            foreach (var jedi in line)
            {
                switch (jedi[0])
                {
                    case 'm':m.Add(jedi); break;
                    case 'k': k.Add(jedi); break;
                    case 'p': p.Add(jedi); break;
                    case 'y':isThereAMaster = true; break;
                    case 's': slavAndTosho.Add(jedi); break;
                    case 't': slavAndTosho.Add(jedi); break;

                    default:
                        break;
                }
            }
        }

        if (isThereAMaster)
        {
            output = string.Join(" ", m) + " "
                + string.Join(" ", k) + " "
                + string.Join(" ", slavAndTosho) + " "
                + string.Join(" ", p);
        }
        else
        {
            output = string.Join(" ", slavAndTosho) + " "
                + string.Join(" ", m) + " "
                + string.Join(" ", k) + " " 
                + string.Join(" ", p);
        }

        Console.WriteLine(output);
        }
    }

