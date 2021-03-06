using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public class Weapon
    {
        //frugal / fields
        private int _minDamage;

        //people / properties
        public int MaxDamage { get; set; }
        public string Name { get; set; }
        public int AdditionalHitChance { get; set; }
        public bool IsCloseRangeRequired { get; set; }
        public string WeaponPic { get; set; }

        public int MinDamage
        {
            get { return _minDamage; }
            set
            {
                if (value > 0 && value <= MaxDamage)
                {
                    //you haven't reached max damage
                    _minDamage = value;
                }//end if
                else
                {
                    _minDamage = 1;
                }//end else

            }//end set
        }//end MinDamage


        //collect / constructors (ctors)
        public Weapon(int minDamage, int maxDamage, string name, int additionalHitChance, bool isCloseRangeReqired, string weaponPic)
        {
            MaxDamage = maxDamage;
            MinDamage = minDamage;
            Name = name;
            IsCloseRangeRequired = isCloseRangeReqired;
            WeaponPic = weaponPic;
        }//end FQ ctor  -- No default ctor required

        public string weaponPic = "";

        //money / methods

        public override string ToString()
        {
            return $"{Name}\n{(IsCloseRangeRequired ? "Weapon is not capable of long range hit" : "Weapon is capable of long range hit")}\n" +
                $"{weaponPic}\n" +
                $"{MinDamage} - {MaxDamage} Damage\n" +
                $"Additional Hit: {AdditionalHitChance}%\t";
        }

    }//end class
}//end namespace
