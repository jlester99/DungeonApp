using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    //We can't add an ENUM through VS interface.
    //If we want one, just change the word "class" below to "enum"
    //(AND MAKE IT PUBLIC!)
    public enum ExperienceLevel
    {
        //Single values, comma separated, NO SPACES!
        Novice,
        Beginner,
        Trainee,
        Amateur,
        Competent,
        Advanced,
        Expert,
        Veteran
        
    }//end enum
}//end namespace
