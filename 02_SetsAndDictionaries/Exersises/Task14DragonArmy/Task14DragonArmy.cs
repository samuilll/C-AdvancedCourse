using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task14DragonArmy
{
    class Dragon
    {

        public int Damage { get; set; }

        public int Health { get; set; }

        public int Armor { get; set; }

        public Dragon(int damage, int health, int armor)
        {

            this.Damage = damage;

            this.Health = health;

            this.Armor = armor;
        }


    }
    class Task14DragonArmy
    {
        static void Main(string[] args)
        {
            int inputsNumber = int.Parse(Console.ReadLine());

            Dictionary<string, Dictionary<string, Dragon>> data = new Dictionary<string, Dictionary<string, Dragon>>();

            for (int i = 0; i < inputsNumber; i++)
            {
                var input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                string dragonType = input[0];

                string dragonName = input[1];

                int damage = input[2] != "null" ? int.Parse(input[2]) : 45;

                int health = input[3] != "null" ? int.Parse(input[3]) : 250;

                int armor = input[4] != "null" ? int.Parse(input[4]) : 10;

                Dragon currentDragon = new Dragon(damage, health, armor);

                if (!data.ContainsKey(dragonType))
                {
                    data[dragonType] = new Dictionary<string, Dragon>();
                }

                data[dragonType][dragonName] = currentDragon;
            }

            PrintTheResult(data);
        }

        private static void PrintTheResult(Dictionary<string, Dictionary<string, Dragon>> data)
        {
            foreach (var typePair in data)
            {
                var avrDamage = typePair.Value.Select(n => n.Value.Damage).Average();
                var avrHealth = typePair.Value.Select(n => n.Value.Health).Average();
                var avrArmor = typePair.Value.Select(n => n.Value.Armor).Average();
                Console.WriteLine($"{typePair.Key}::({avrDamage:f2}/{avrHealth:f2}/{avrArmor:f2})");

                foreach (var dragonPair in typePair.Value.OrderBy(n=>n.Key))
                {
                    Console.WriteLine($"-{dragonPair.Key} -> damage: {dragonPair.Value.Damage}," +
                        $" health: {dragonPair.Value.Health}, armor: {dragonPair.Value.Armor}");
                }
            }
        }
    }
}
