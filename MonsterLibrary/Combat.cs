using DungeonLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonsterLibrary
{
    public class Combat
    {
        public static void DoAttack(Character attacker, Character defender)
        {
            Random rand = new Random();
            int genRand = rand.Next(1, 101);
            Thread.Sleep(100);
            Console.WriteLine("------------------------------------------");
            if (genRand <= (attacker.CalcHitChance() - defender.CalcBlock()))
            {
                int damageDealt = attacker.CalcDamage();

                defender.Life -= damageDealt;

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"{attacker.Name} did {damageDealt} damage to {defender.Name}!");
                Console.ResetColor();
            }
            else
            {
                Console.WriteLine($"{attacker.Name}'s attack missed!");
            }
            Console.WriteLine("------------------------------------------");
        }//end DoAttack()

        public static void DoBattle(Player player, Monster monster)
        {
            //player attacks first
            DoAttack(player, monster);

            //Monster attacks second, if they're alive
            if (monster.Life > 0)
            {
                DoAttack(monster, player);
            }
        }
    }
}
