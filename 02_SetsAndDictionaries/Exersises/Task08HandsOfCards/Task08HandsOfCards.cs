using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task08HandsOfCards
{
    class Task08HandsOfCards
    {
        static void Main(string[] args)
        {

            string input = Console.ReadLine();

            Dictionary<string, HashSet<string>> playersCards = new Dictionary<string, HashSet<string>>();

            Dictionary<string, int> playersPoints = new Dictionary<string, int>();

            while (input!="JOKER")
            {
                string name = input.Split(new string[] {": "},StringSplitOptions.RemoveEmptyEntries)[0];

                var cards = input.Split(new string[] { ", " ,": "}, StringSplitOptions.RemoveEmptyEntries).Skip(1).ToArray();

                if (!playersCards.ContainsKey(name))
                {
                    playersCards[name] = new HashSet<string>();
                }
                foreach (var card in cards)
                {
                    playersCards[name].Add(card);
                }

                input = Console.ReadLine();
            }

            foreach (var pair in playersCards)
            {
                var name = pair.Key;

                var cards = pair.Value;

                CalculatePlayerScore(name, cards, playersPoints);
            }

            foreach (var player in playersPoints)
            {
                Console.WriteLine($"{player.Key}: {player.Value}");
            }
        }

        private static void CalculatePlayerScore(string name, HashSet<string> cards, Dictionary<string, int> playersPoints)
        {
            foreach (var card in cards)
            {
                if (!playersPoints.ContainsKey(name))
                {
                    playersPoints[name] = 0;
                }

                int currentScore = CalculateTheCurrentScore(card);

                playersPoints[name] += currentScore;
            }
        }

        private static int CalculateTheCurrentScore(string card)
        {

            int multiplier = 0;

            int power = 0;

            switch (card[card.Length-1])
            {
                case 'S':
                    {
                        multiplier = 4;
                        break;
                    }
                case 'H':
                    {
                        multiplier = 3;
                        break;
                    }
                case 'D':
                    {
                        multiplier = 2;
                        break;
                    }
                case 'C':
                    {
                        multiplier = 1;
                        break;
                    }
            }
            switch (card[0])
            {
                case '2':
                    {
                        power = 2;
                        break;
                    }
                case '3':
                    {
                        power = 3;
                        break;
                    }
                case '4':
                    {
                        power = 4;
                        break;
                    }
                case '5':
                    {
                        power = 5;
                        break;
                    }
                case '6':
                    {
                        power = 6;
                        break;
                    }
                case '7':
                    {
                        power = 7;
                        break;
                    }
                case '8':
                    {
                        power = 8;
                        break;
                    }
                case '9':
                    {
                        power = 9;
                        break;
                    }
                case '1':
                    {
                        power = 10;
                        break;
                    }
                case 'J':
                    {
                        power = 11;
                        break;
                    }
                case 'Q':
                    {
                        power = 12;
                        break;
                    }
                case 'K':
                    {
                        power = 13;
                        break;
                    }
                case 'A':
                    {
                        power = 14;
                        break;
                    }

            }

            return power*multiplier;
        }
    }
}
