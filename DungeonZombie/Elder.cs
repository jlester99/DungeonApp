using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DungeonLibrary; //added

namespace DungeonZombie
{
    public class Elder : Zombie
    {

        //Public and a child of zombie

        //props

        public bool IsVerySlowMoving { get; set; }

        //ctors
        public Elder()
        {
            //SET MAX VALUES FIRST!
            MaxLife = 6;
            MaxDamage = 3;
            Name = "Mortimer";
            Life = 6;
            HitChance = 20;
            Block = 20;
            MinDamage = 1;
            Description = "This male zombie has gray eyes, an olive complexion, and wavy blond hair worn long.  He is tall, of average weight, and is wearing very little clothing to speak of.  He is quite old and is missing both legs and both ears.";
            IsVerySlowMoving = true;

        }//end default ctor

        public Elder(string name, int life, int maxLife, int hitChance,
            int block, int minDamage, int maxDamage, string description, bool isVerySlowMoving)
            : base(name, life, maxLife, hitChance, block, minDamage,
                  maxDamage, description)
        {
            //just handle the unique ones
         
        }//end FQCTOR

        //methods
        public override string ToString()
        {


            return base.ToString() + (IsVerySlowMoving ? "Moves very slow" : "Doesn't move very slow");
        }//end ToString()

        //overrride block : if they are elderly, they get a 50% less chance to their block value
        public override int CalcBlock()
        {
            //Typically when dealing with a method that has return type,
            //we create the return type first.
            int calculatedBlock = Block;

            if (IsVerySlowMoving)
            {
                calculatedBlock -= calculatedBlock / 2;
            }

            return calculatedBlock;
        }//end CalcBlock()

    }//end class
}//end namespace
