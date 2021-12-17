using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DungeonLibrary; //added

namespace DungeonZombie
{
    public class Adult : Zombie
    {

        //Public and a child of zombie

        //props

        public bool IsVerySlowMoving { get; set; }

        //ctors
        public Adult()
        {
            //SET MAX VALUES FIRST!
            MaxLife = 6;
            MaxDamage = 3;
            Name = "Buster";
            Life = 6;
            HitChance = 20;
            Block = 20;
            MinDamage = 1;
            Description = "This male zombie is an adult and has gray eyes, a fair complexion, and curly golden-blond hair neatly braided.  He is a little tall, fairly muscular, and is wearing very little clothing to speak of.  He is a bit decayed and is missing both arms and most of the face.";
            IsVerySlowMoving = false;

        }//end default ctor

        public Adult(string name, int life, int maxLife, int hitChance,
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
