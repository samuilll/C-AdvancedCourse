using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Task03NumberWars
{
    class Task03NumberWars
    {
        public const string alhpabet = "abcdefghijklmnopqrstuvwxyz";

        //public static Queue<string> firstBottomDeck = new Queue<string>();

        //public static Queue<string> secondBottomDeck = new Queue<string>();

        public static int turns = 0;

        public static Queue<string> firstPlayerDeck;

        public static Queue<string> secondPlayerDeck;

        public static bool lackOfcards = false;

        static void Main(string[] args)
        {
            firstPlayerDeck = new Queue<string>(Console.ReadLine().Split());

            secondPlayerDeck = new Queue<string>(Console.ReadLine().Split());

            if (string.Join(" ",firstPlayerDeck)== string.Join(" ", secondPlayerDeck))
            {
                Console.WriteLine($"Draw after 1 turns"); return;
            }

            int checkTheGame=0;

            Regex reg = new Regex(@"\d+");

            while (checkTheGame == 0)
            {
                PutTheCardsOnTheTable(firstPlayerDeck, secondPlayerDeck,reg);

               // Console.WriteLine(string.Join(", ",firstPlayerDeck));
              //  Console.WriteLine(string.Join(", ", secondPlayerDeck));


                checkTheGame = GameIsOver();
            }

            switch (checkTheGame)
            {
                case 1: Console.WriteLine($"First player wins after {turns} turns"); break;
                case -1: Console.WriteLine($"Second player wins after {turns} turns"); break;
                case 2: Console.WriteLine($"Draw after {turns} turns"); break;
                default:
                    break;
            }

        }

        private static int GameIsOver()
        {
            int firstCards = firstPlayerDeck.Count;

            int secondCards = secondPlayerDeck.Count;

            if (turns > 1000000)
            {
                turns = 1000000;

                return firstCards > secondCards ? 1 : secondCards > firstCards ? -1 : 2;

            }
            if (lackOfcards)
            {
                return firstCards > secondCards ? 1 : secondCards > firstCards ? -1 : 2;
            }
            if (firstCards==0 && secondCards==0)
            {
                return 2;
            }
            if (firstCards == 0)
            {
                return -1;
            }
            if (secondCards == 0)
            {
                return 1;
            }
            return 0;

        }

        private static void PutTheCardsOnTheTable(Queue<string> firstPlayerDeck, Queue<string> secondPlayerDeck,Regex reg)
        {
            if (lackOfcards)
            {
                return;
            }
            var firstCard = firstPlayerDeck.Dequeue();

            var secondCard = secondPlayerDeck.Dequeue();

            var onTheTableCards = new List<string>();

            var winnerCard = GetTheWinnerCardOrDraw(firstCard, secondCard,reg); //first card reutns 1; second card returns -1; draw returns 0;

            
            switch (winnerCard)
            {
                case 1:
                    firstPlayerDeck.Enqueue(firstCard);
                    firstPlayerDeck.Enqueue(secondCard);
                    turns += 1;
                    break;
                case -1:
                    secondPlayerDeck.Enqueue(secondCard);
                    secondPlayerDeck.Enqueue(firstCard);
                    turns += 1;
                    break;
                case 0:
                    onTheTableCards.Add(firstCard);
                    onTheTableCards.Add(secondCard);
                    PutMoreThreeCardsOnTheTable(onTheTableCards, firstPlayerDeck, secondPlayerDeck);
                    turns += 1;
                    break;

                default:
                    break;
            }
        }

        private static void PutMoreThreeCardsOnTheTable(List<string> onTheTableCards, Queue<string> firstPlayerDeck, Queue<string> secondPlayerDeck)
        {
            if (firstPlayerDeck.Count < 3 || secondPlayerDeck.Count < 3)
            {
                lackOfcards = true;
                return;
            }
            string secondPlayerFirstCard = PutEachOfCardsOnTheTable(onTheTableCards, -1);
            string secondPlayerSecondCard = PutEachOfCardsOnTheTable(onTheTableCards, -1);
            string secondPlayerThirdCard = PutEachOfCardsOnTheTable(onTheTableCards, -1);

            string firstPlayerFirstCard = PutEachOfCardsOnTheTable(onTheTableCards, 1);
            string firstPlayerSecondCard = PutEachOfCardsOnTheTable(onTheTableCards, 1);
            string firstPlayerThirdCard = PutEachOfCardsOnTheTable(onTheTableCards, 1);

            int winner = CompareTheCards(firstPlayerFirstCard, firstPlayerSecondCard, firstPlayerThirdCard, secondPlayerFirstCard, secondPlayerSecondCard, secondPlayerThirdCard);

            switch (winner)
            {
                case 1: TheWinnerGetsAll(onTheTableCards, 1); break;
                case -1: TheWinnerGetsAll(onTheTableCards, -1); break;
                case 0:
                    if (GameIsOver()==0)
                    {
                        PutMoreThreeCardsOnTheTable(onTheTableCards, firstPlayerDeck, secondPlayerDeck);
                    }
             
                    break;
                default:
                    break;
            }

        }

        private static void TheWinnerGetsAll(List<string> onTheTableCards, int check)
        {
            onTheTableCards = onTheTableCards.OrderByDescending(n => GetBiggerNumber(n)).ThenBy(n=>n).ToList();

            if (check == -1)
            {
                while (onTheTableCards.Count > 0)
                {
                    secondPlayerDeck.Enqueue(onTheTableCards[0]);
                    onTheTableCards.RemoveAt(0);
                }
            }
            else
            {
                while (onTheTableCards.Count > 0)
                {
                    firstPlayerDeck.Enqueue(onTheTableCards[0]);
                    onTheTableCards.RemoveAt(0);
                }
            }
        }

        private static int GetBiggerNumber(string card)
        {
           var firstLetter = card.Where(n =>Char.IsLetter(n)).First();

            return int.Parse(card.Substring(0, card.IndexOf(firstLetter)));
        }

        private static int CompareTheCards(string firstPlayerFirstCard, string firstPlayerSecondCard, string firstPlayerThirdCard, string secondPlayerFirstCard, string secondPlayerSecondCard, string secondPlayerThirdCard)
        {
            int firstSum = GetTheLetterSumFromTheCard(firstPlayerFirstCard) + GetTheLetterSumFromTheCard(firstPlayerSecondCard) + GetTheLetterSumFromTheCard(firstPlayerThirdCard);

            int secondSum = GetTheLetterSumFromTheCard(secondPlayerFirstCard) + GetTheLetterSumFromTheCard(secondPlayerSecondCard) + GetTheLetterSumFromTheCard(secondPlayerThirdCard);

            return firstSum > secondSum ? 1 : firstSum < secondSum ? -1 : 0;
        }

        private static int GetTheLetterSumFromTheCard(string card)
        {
            int sum = 0;

            if (card == "hasNoCards")
            {
                return 0;
            }

            var index = card.IndexOf(card.Where(n => Char.IsLetter(n)).First());

            var length = card.Length - index;

            var onlyLetters = card.Substring(index,length);

            foreach (var letter in onlyLetters)
            {
                sum += alhpabet.IndexOf(letter) + 1;
            }
            return sum;
        }

        private static string PutEachOfCardsOnTheTable(List<string> onTheTableCards, int player)
        {
            string PlayerFirstCard = null;

            if (player == 1)
            {
                if (firstPlayerDeck.Count > 0)
                {
                    PlayerFirstCard = firstPlayerDeck.Dequeue();
                    onTheTableCards.Add(PlayerFirstCard);
                }
                else
                {
                    return "hasNoCards";
                }
        
            }
            else
            {
                if (secondPlayerDeck.Count > 0)
                {
                    PlayerFirstCard = secondPlayerDeck.Dequeue();
                    onTheTableCards.Add(PlayerFirstCard);
                }
                else
                {
                    return "hasNoCards";
                }

            }
            return PlayerFirstCard;
        }

        private static int GetTheWinnerCardOrDraw(string firstCard, string secondCard,Regex reg)
        {
            var firstCardNumber = int.Parse(reg.Match(firstCard).Value);

            var seondCardNumber = int.Parse(reg.Match(secondCard).Value);


            return firstCardNumber > seondCardNumber ? 1 : seondCardNumber > firstCardNumber ? -1 : 0;
        }
    }
}
