using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Task01CubicArtillery
{
    static void Main(string[] args)
    {


        int capacity = int.Parse(Console.ReadLine());

        var inputLine = Console.ReadLine()
            .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .ToArray();

        Queue<string[]> lines = new Queue<string[]>();

        while (inputLine[0] != "Bunker")
        {
            if (inputLine.Where(n => !TryParseBool(n)).ToArray().Length>0)
            {
                lines.Enqueue(inputLine);
            }
            inputLine = Console.ReadLine()
            .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .ToArray();
        }

        while (lines.Count>0)
        {
            var currentLine = lines.Dequeue();

            string[] bunkers = currentLine.Where(n => !TryParseBool(n)).ToArray();

            Queue<int> weapons = new Queue<int>(currentLine.Where(n => TryParseBool(n)).Select(int.Parse).ToArray());

            if (bunkers.Length>0)
            {
                ManipulateTheCurrentLine(bunkers, weapons, capacity, lines);
            }

        }
    }

    private static void ManipulateTheCurrentLine(string[] bunkers, Queue<int> weapons, int capacity,Queue<string[]> lines)
    {
        Queue<string> bunkersQueue = new Queue<string>(bunkers);
        
          string   currentBunker = bunkersQueue.Peek();

        bool isPrinted = false;

        var currentWeapons = new List<int>();

        while(weapons.Count!=0)
        {
            var weapon = weapons.Dequeue();

            if (weapon <= capacity)
            {
                if (capacity - currentWeapons.Sum() >= weapon)
                {
                    currentWeapons.Add(weapon);
                }
                else if(bunkersQueue.Count>1)
                {
                    PrintTheBunker(currentBunker, currentWeapons);

                    currentWeapons.Clear();

                    currentBunker = bunkersQueue.Dequeue();

                    currentWeapons.Add(weapon);
                }
                else
                {
                    RemoveTheWeaponsToAddNewOne(currentBunker, currentWeapons, capacity, weapon);

                    if (weapons.Count==0 && lines.Count>0)
                    {
                        PrintTheBunker(currentBunker, currentWeapons);
                        isPrinted = true;
                    }
                }
            }
            
        }
        if ((lines.Count>0 || bunkersQueue.Count>1)&& isPrinted)
        {
            PrintTheBunker(currentBunker, currentWeapons);
        }
    }

    private static void PrintTheBunker(string currentBunker, List<int> currentWeapons)
    {
        if (currentWeapons.Count>0)
        {
            Console.WriteLine($"{currentBunker} -> {string.Join(", ", currentWeapons)}");
        }
        else
        {
            Console.WriteLine($"{currentBunker} -> Empty");
        }
    }

    private static void RemoveTheWeaponsToAddNewOne(string currentBunker, List<int> currentWeapons, int capacity, int weapon)
    {
        currentWeapons.Add(weapon);

        while (currentWeapons.Sum()>capacity)
        {
            currentWeapons.RemoveAt(0);
        }
    }

    private static bool TryParseBool(string n)
    {
        if (Int32.TryParse(n, out int r))
        {
            return true;
        }

        return false;
    }


}

