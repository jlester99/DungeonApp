using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public sealed class Player : Character //this is now a child of Character
                                           //The sealed keyword indicates that this class cannot be used as a 
                                           //parent (base) class for any other classses. this ends inheritance chain
    {
        //frugal / fields
        //private int _life;
        //We only need to create fields for the ones we will have business rules on.  Other can be used as auto props

        //people / properties
        //Automatic properties are a shortcut syntax that allows you 
        //to create a shortened version of a public property.
        //They have an "open" getter and setter! The guard is asleep!
        //Auto props automatically create default fields for you at runtime.

        //public string Name { get; set; }
        //public int HitChance { get; set; }//modified based on our weapon
        //public int Block { get; set; } //random number
        //public int MaxLife { get; set; }
        //TODO 17. Create a Race

        public ExperienceLevel CharacterExperience { get; set; }//enum in ExperienceLevel.cs
        //TODO 18. Create a Weapon
       
        public Weapon WeaponRetrieved { get; set; }//Weapon.cs

       
        //collect / constructors (ctors)
        public Player(string name, int hitChance, int block, int life, int maxLife,
            ExperienceLevel characterExperience, Weapon weaponRetrieved)
        {
            //ASSIGNMENTS: PascalCase = camelCase;
            //do MaxLife first due to business rules - life depends on MaxLife
            MaxLife = maxLife;
            Name = name;
            HitChance = hitChance;
            Life = life;
            CharacterExperience = characterExperience;
            WeaponRetrieved = weaponRetrieved;
            Block = block;

            //BONUS: Customize a prop based off of Race
            switch (CharacterExperience)
            {//click enter and will see all the race because Race is an enum
                case ExperienceLevel.Veteran:
                    HitChance += 10;
                    break;

                case ExperienceLevel.Expert:
                    HitChance += 7;
                        break;

                case ExperienceLevel.Advanced:
                    HitChance += 5;
                    break;

                case ExperienceLevel.Novice:
                    HitChance -= 5;
                    break;
            }
        }//end FQ CTOR

        //money / methods

        public override string ToString()
        {
            string description = ""; //save a formatted version of ExperienceLevel

            switch (CharacterExperience)
            {
                case ExperienceLevel.Novice:
                    description = "Has killed very few zombies";
                    break;

                case ExperienceLevel.Beginner:
                    description = "Has killed less than 10 zombies";
                    break;

                case ExperienceLevel.Trainee:
                    description = "Has killed less than 20 zombies";
                    break;

                case ExperienceLevel.Amateur:
                    description = "Has killed less than 30 zombies";
                    break;

                case ExperienceLevel.Competent:
                    description = "Has killed more than 30 zombies but less than 50";
                    break;

                case ExperienceLevel.Advanced:
                    description = "Has killed more than 50 zombies and has a very fairly good chance at killing the zombie";
                    break;

                case ExperienceLevel.Expert:
                    description = "Has killed more than 100 zombies and is extremely good at killing the zombie";
                    break;

                    //No default needed
            }//end Switch

            //outside of switch, return values
            return $"-=-= {Name} =-=-\n" +
                $"Life: {Life} / {MaxLife}\n" +
                $"Experience: {CharacterExperience}: {description}\n" +
                //$"Hit Chance: {CalcHitChance()}%\n" +
                $"Hit Chance: {HitChance}%\n" +
                $"Block: {Block}\n" +
                $"Weapon:\t{WeaponRetrieved}\n";

        }//end ToString() Override

        public override int CalcDamage()
        {
            //return base.CalcDamage();
            //create a random object
            Random rand = new Random();

            //determine damage
            int damage = rand.Next(WeaponRetrieved.MinDamage, WeaponRetrieved.MaxDamage + 1);
            //return the damage
            return damage;
        }//end CalcDamage()

        public override int CalcHitChance()
        {
            return base.CalcHitChance() + WeaponRetrieved.AdditionalHitChance;
        }//end CalcHitChance()
    }//end class
}//end namespace
