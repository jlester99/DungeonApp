using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public class Combat
    {
        //This class will not have fields, properties, or any custom ctors
        //It is just a "warehouse" for different methods.

        public static void DoAttack(Character attacker, Character defender)
        {
            //Get a random number from 1-100 as our dice roll
            int diceRoll = new Random().Next(1, 101);
            System.Threading.Thread.Sleep(30);
            if (diceRoll <= (attacker.CalcHitChance() - defender.CalcBlock()))
            {
                //If the attacker hit, calculate the damage
                int damageDealt = attacker.CalcDamage();

                //assign the damage
                defender.Life -= damageDealt;

                //Write the result to the screen
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"{attacker.Name} hit {defender.Name} for {damageDealt} damage!");
                Console.ResetColor();
            }//end if
            else
            {
                //the attack missed
                Console.WriteLine($"{attacker.Name} missed!");
            }//end else
        }//end DoAttack()

        public static void DoBattle(Player player, Zombie zombie)
        {
            //player attacks first
            DoAttack(player, zombie);

            //zombie attacks second, if they're alive
            if (zombie.Life > 0)
            {
                DoAttack(zombie, player);
            }//end if
        }//end DoBattle
    }//end class
}//end namespace
