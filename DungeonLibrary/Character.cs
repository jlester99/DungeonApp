using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public abstract class Character
    {
        //all of the fields and props shared between player and zombie classes - these child classes will inherit from
        //Character class

        //frugal  /  fields
        private int _life;

        //people /  properties

        public string Name { get; set; }
        public int HitChance { get; set; }
        public int Block { get; set; }
        public int MaxLife { get; set; }
        public int Life
        {
            get { return _life; }
            set
            {
                //Life should not be MORE than MaxLife
                if (value <= MaxLife)
                {
                    //good to go
                    _life = value;
                }
                else
                {
                    _life = MaxLife;
                }
            }//end set
        }//end Life

        //collect / constructors (ctors)
       

        //money / methods
        //No to string override.

        public virtual int CalcBlock()
        {
            //To be able to override this in a child class,
            //make it VIRTUAL

            //set default that can be overridden in the child classes
            return Block;
        }//end CalcBlock()

        //CalcHitChance() will return the chance of a hit the character has; this can be overridden in child classes.
        public virtual int CalcHitChance()
        {
            return HitChance;
        }//end CalcHitChance()

        //this will just return 0 and be overridable in child classes
        public virtual int CalcDamage()
        {
            return 0;
            
        }//end CalcDamage()

    }//end class
}//end namespace









