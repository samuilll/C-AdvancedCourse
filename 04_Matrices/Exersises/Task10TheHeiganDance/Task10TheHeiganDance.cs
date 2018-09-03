using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Player
{

    public int Row { get; set; }

    public int Col { get; set; }

    public int Health { get; set; }

    public double Damage { get; set; }

    public bool IsHitByCloud { get; set; }

    public bool IsAlive { get; set; }

    public Player(int row, int col, int health, double damage, bool isHit, bool isAlive)
    {
        this.Row = row;
        this.Col = col;
        this.Health = health;
        this.Damage = damage;
        this.IsHitByCloud = isHit;
        this.IsAlive = isAlive;
    }

}

class Task10TheHeiganDance
{
    static void Main(string[] args)
    {
        double playerDamage = double.Parse(Console.ReadLine());

        Player player = new Player(7, 7, 18500, playerDamage, false, true);

        var matrix = InticializeTheMatrix();

        double heiganHealth = 3000000;

        var lastKindOfAttack = string.Empty;

        string spell = string.Empty;

        while (true)
        {
            heiganHealth -= playerDamage;

            if (player.IsHitByCloud)
            {
                player.Health -= 3500;
                if (player.Health <= 0)
                {
                    player.Health = 0;
                    break;
                }
                player.IsHitByCloud = false;
            }

            if (heiganHealth <= 0)
            {
                heiganHealth = 0;
                break;
            }

            string[] hitCorrdinatesAndKindOfSpell = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            int hitRow = int.Parse(hitCorrdinatesAndKindOfSpell[1]);

            int hitCol = int.Parse(hitCorrdinatesAndKindOfSpell[2]);

            spell = hitCorrdinatesAndKindOfSpell[0];

            if (IsPlayerInTheDamgedZone(player, matrix, hitRow, hitCol))
            {
                player = RunPlayerRun(player, matrix, hitRow, hitCol, spell);
            }

            if (player.Health <= 0)
            {
                break;
            }
        }

        PrintTheResult(player, heiganHealth, spell);
    }

    private static void PrintTheResult(Player player, double heiganHealth, string spell)
    {
        if (player.Health <= 0 && heiganHealth <= 0)
        {
            Console.WriteLine("Heigan: Defeated!");

            if (spell == "Eruption")
            {
                Console.WriteLine($"Player: Killed by {spell}");
            }
            else
            {
                Console.WriteLine($"Player: Killed by Plague {spell}");
            }

            Console.WriteLine($"Final position: {player.Row}, {player.Col}");

        }
        else if (player.Health <= 0)
        {
            Console.WriteLine($"Heigan: {heiganHealth:f2}");

            if (spell == "Eruption")
            {
                Console.WriteLine($"Player: Killed by {spell}");
            }
            else
            {
                Console.WriteLine($"Player: Killed by Plague {spell}");
            }

            Console.WriteLine($"Final position: {player.Row}, {player.Col}");
        }
        else
        {
            Console.WriteLine("Heigan: Defeated!");

            Console.WriteLine($"Player: {player.Health}");

            Console.WriteLine($"Final position: {player.Row}, {player.Col}");
        }
    }

    private static Player RunPlayerRun(Player player, int[][] matrix, int hitRow, int hitCol, string spell)
    {

        if (player.Row - 1 < hitRow - 1 && player.Row - 1 >= 0) //try up
        {
            player.Row -= 1;
        }
        else if (player.Col + 1 > hitCol + 1 && player.Col + 1 < matrix[0].Length) //try right
        {
            player.Col += 1;
        }
        else if (player.Row + 1 > hitRow + 1 && player.Row + 1 < matrix.Length)  //try down
        {
            player.Row += 1;
        }
        else if (player.Col - 1 < hitCol - 1 && player.Col - 1 >= 0)  // try left
        {
            player.Col -= 1;
        }
        else
        {
            if (spell == "Cloud")
            {
                player.Health -= 3500;

                player.IsHitByCloud = true;
            }

            if (spell == "Eruption")
            {
                player.Health -= 6000;
            }
        }

        return player;

    }

    private static bool IsPlayerInTheDamgedZone(Player player, int[][] matrix, int hitRow, int hitCol)
    {
        if (((player.Row == hitRow - 1) || (player.Row == hitRow) || (player.Row == hitRow + 1)) &&
            ((player.Col == hitCol - 1) || (player.Col == hitCol) || (player.Col == hitCol + 1)))
        {
            return true;
        }

        return false;
    }

    private static int[][] InticializeTheMatrix()
    {
        int rows = 15;

        int columns = 15;

        int[][] matrix = new int[rows][].Select(r => r = new int[columns]).ToArray();

        return matrix;
    }
}

