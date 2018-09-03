using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Task01NewDecision
{
    static void Main(string[] args)
    {
        int capacity = int.Parse(Console.ReadLine());

        var inputLine = Console.ReadLine();


        Queue<string[]> lines = new Queue<string[]>();

        var bulder = new StringBuilder();

        while (inputLine != "Bunker Revision")
        {
            bulder.Append(inputLine + " ");

            inputLine = Console.ReadLine();

        }

        var overflowed = new Dictionary<string, List<int>>();

        var currentLine = bulder.ToString().Split();

        var bunkers = new Queue<string>();

        var weapons = new Queue<int>();

        for (int i = 0; i < currentLine.Length; i++)
        {
            var item = currentLine[i];

            int currentWeapon;

            bool hasWeapon = false;

            if (TryParseBool(item))
            {

                currentWeapon = int.Parse(item);

                if (bunkers.Count == 1)
                {
                    if (currentWeapon < capacity - weapons.Sum())
                    {
                        weapons.Enqueue(currentWeapon);
                    }
                    else if (currentWeapon == capacity - weapons.Sum())
                    {
                        weapons.Enqueue(currentWeapon);

                        overflowed[bunkers.Dequeue()] = weapons.ToList();

                        weapons.Clear();
                    }
                    else if (currentWeapon > capacity - weapons.Sum() && currentWeapon <= capacity)
                    {
                        RemoveTheWeaponsToAddNewOne(weapons, capacity, currentWeapon);
                    }
                    else
                    {
                        overflowed[bunkers.Dequeue()] = weapons.ToList();

                        weapons.Clear();
                    }
                }
                else if (bunkers.Count > 1)
                {
                    if (currentWeapon < capacity - weapons.Sum())
                    {
                        weapons.Enqueue(currentWeapon);
                    }
                    else if (currentWeapon == capacity - weapons.Sum())
                    {
                        weapons.Enqueue(currentWeapon);

                        overflowed[bunkers.Dequeue()] = weapons.ToList();

                        weapons.Clear();
                    }
                    else
                    {
                        overflowed[bunkers.Dequeue()] = weapons.ToList();

                        weapons.Clear();

                        if (currentWeapon <= capacity)
                        {
                            weapons.Enqueue(currentWeapon);
                        }

                    }
                }
            }

            else
            {
                bunkers.Enqueue(item);
            }


        }

        foreach (var pair in overflowed)
        {
            if (overflowed.Last().Key == pair.Key)
            {
                break;
            }
            if (pair.Value.Count > 0)
            {
                Console.WriteLine($"{pair.Key} -> {string.Join(", ", pair.Value)}");
            }
            else
            {
                Console.WriteLine($"{pair.Key} -> Empty");

            }
        }

    }
    private static void RemoveTheWeaponsToAddNewOne(Queue<int> weapons, int capacity, int currentWeapon)
    {
        weapons.Enqueue(currentWeapon);

        while (weapons.Sum() > capacity)
        {
            weapons.Dequeue();
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

