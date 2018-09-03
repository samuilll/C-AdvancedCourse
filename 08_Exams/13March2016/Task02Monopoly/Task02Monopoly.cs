using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    class Task02Monopoly
    {
        static void Main(string[] args)
        {

        var parameters = Console.ReadLine()
            .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

        var row = parameters[0];

        var col = parameters[1];

        var table = new Dictionary<int, string>();

        long money = 50;

        var hotels = 0;

        var turns = 0;

        for (int i = 1; i <= row; i++)
        {
            table[i] = Console.ReadLine();
        }

        foreach (var pair in table)
        {
            var commands = pair.Value;

            if (pair.Key%2!=0)
            {

            }
            else
            {
                commands = string.Join("", commands.ToCharArray().Reverse());
            }
            for (var i =0; i<commands.Length; i++)
            {
                switch (commands[i])
                {
                    case 'H':
                        {
                            hotels += 1;
                            Console.WriteLine($"Bought a hotel for {money}. Total hotels: {hotels}.");
                            money = 0;
                            break;
                        }
                    case 'J':
                        {
                            Console.WriteLine($"Gone to jail at turn {turns}."); turns += 2;
                            money += hotels * 20;
                            break;
                        }
                    case 'S':
                        {
                            int index;

                            if (pair.Key%2==0)
                            {
                                index = commands.Length - i;

                            }
                            else
                            {
                                index = i + 1;
                            }
                            long spentMoney = Math.Min(money,pair.Key*index);

                            Console.WriteLine($"Spent {spentMoney} money at the shop.");
                            money-=spentMoney;
                            break;
                        }
                    default:
                        break;
                }

                turns += 1;
                money += hotels * 10;
            }
        }   

        Console.WriteLine($"Turns {turns}");
        Console.WriteLine($"Money {money}");


    }
    }

