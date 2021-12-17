using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public class Zombie : Character
    {
        //frugal / fields
        //we will have a business rule on MinDamage, we need a full prop and full field

        private int _minDamage;

        //people / properties
        //Auto props go first (no business rules)
        public int MaxDamage { get; set; }
        public string Description { get; set; }

        public int MinDamage
        {
            get { return _minDamage; }
            //Can't be more than MaxDamage and can't be less than 1
            set
            {
                if (value > 0 && value <= MaxDamage)
                {
                    //you're good
                    _minDamage = value;
                }//end if
                else
                {
                    _minDamage = 1;
                }//end else
                //_minDamage = (value > 0 && value <= MaxDamage) ? value : 1;
            }//end set
        }//end MinDamage

        //collect / constructors (ctors)
        public Zombie() { }

        public Zombie(string name, int life, int maxLife, int hitChance,
            int block, int minDamage, int maxDamage, string description)
        {
            //PascalCase = camelCase;
            MaxLife = maxLife;
            MaxDamage = maxDamage;
            Name = name;
            Life = life;
            HitChance = hitChance;
            Block = block;
            Description = description;
            MinDamage = minDamage;
        }//end FQ CTOR

        //money / methods
        public override string ToString()
        {
            return $"\n*********** ZOMBIE ***********\n" +
                $"{Name}\n" +
                $"Life: {Life} / {MaxLife}\n" +
                $"Damage: {MinDamage} to {MaxDamage}\n" +
                $"Block: {Block}\n" +
                $"Description: {Description}\n" ; 
        }//end ToString()

        //We are overriding the CalcDamage() to use the props MinDamage and MaxDamage
        public override int CalcDamage()
        {
            Random rand = new Random();
            return rand.Next(MinDamage, MaxDamage + 1);
            //If we had a zombie that had a mindamage of 2 and max of 8...
            //and passed just MinDamage and MaxDamage to the Next(), it would
            //only return a random number between 2 and 7.
        }//end CalcDamage()

        }//end class
}//end namespace
