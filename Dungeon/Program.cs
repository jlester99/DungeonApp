using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DungeonLibrary;//ADDED
using DungeonZombie;//ADDED

namespace DungeonApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            string txt = "ZOMBIE SLAYER!!!!\n";
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Title = txt;

            //centering text in the console window
            Console.WriteLine("{0," +
                ((Console.WindowWidth / 2) + txt.Length / 2) + "}", txt);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Welcome to the Apocolypse!  You will be sent into rooms where Zombies are known to be lurking about.  Once inside, you must use your assigned weapon to try to inflict damage to their brain which will kill them.  If you do enough damage, victory will be yours!  But, if you don't...well...you know what will happen!!\n" +
                "You can click on the Player Info or Zombie Info in the menu below anytime you need to see the details. Player Info will also show you the weapon that was chosen as randome for you.\nYour journey begins when you choose an option below....Best of luck to you!!\n");

            int score = 0;

            //1.Create a Random Weapon for the Player
             string weaponRetrieved = GetWeapon();
            string weaponPic = "";

            Weapon useWeapon = new Weapon(1, 8, weaponRetrieved, 10, true, weaponPic);

            switch (weaponRetrieved)
            {
                case "CrossBow":
                case "Grenade":
                case "Handgun":
                case "Automatic Rifle":
                    useWeapon.IsCloseRangeRequired = false;
                    break;
            }
            //add switch to populate weaponPic here
            switch (weaponRetrieved)
            {
                case "CrossBow":
                    useWeapon.weaponPic = @"
           4  '^                                     
           4    'b.                                   
           4      $r
           4       $F
           4       *$$F
           4        $$*                                  
-$b ====== 4 =======$b ====*P=-
           4       .$F
           4       dP
           4     *$$F
           4     $F                                       
           4  '$$";

                    break;
                case "Grenade":
                    useWeapon.weaponPic = @"
       \|/                          
            `--+--'                        
              /|\                          
             ' | '                         
               |                           
           ,--'#`--.                       
             ;BVIMMMMMt         
        .=YRBBBMMMMMMMB          
      =RMMMMMMMMMMMMMM;          
    ;BMMR=VMMMMMMMMMMMV.         
   tMMR::VMMMMMMMMMMMMMB:        
 ;MMY ;MMMMMMMMMMMMMMMMMMV       
 VMB +MMMMMMMMMMMMMMMMMMMM:      
 ;MM+ BMMMMMMMMMMMMMMMMMMR       
  tMBVBMMMMMMMMMMMMMMMMMB.       
   tMMMMMMMMMMMMMMMMMMMB:        
    ;BMMMMMMMMMMMMMMMMY          
      +BMMMMMMMMMMMBY:           
        :+YRBBBRVt";


                    break;
                case "Hammer":
                    useWeapon.weaponPic = @"
          - 
       /  |
     /    / 
    /    /     
   |      \                       _________________
   |        |________...-----'''- - -  =- -  - = `.
  /|        |        \-  =  -  -= - =  - =- =  - =|
 ( |        |________/-  =  -  -= - =  - =- =  - =|
   \|      /         ```-----..._________________.'
     |    |   
   ,-'    `-, 
   |        | 
   `--------'  
";


                    break;
                case "Handgun":
                    useWeapon.weaponPic = @"
+--^----------,--------,-----,--------^-,
 | |||||||||   `--------'     |          O
 `+---------------------------^----------|
   `\_,---------,---------,--------------'
     / XXXXXX /'|       /'
    / XXXXXX /  `\    /'
   / XXXXXX /`-------'
  / XXXXXX /
 / XXXXXX /
(________(                
 `------' 
 ";
                    break;
                case "Automatic Rifle":
                    useWeapon.weaponPic= @"
   )|     ______________________.------,_                  _
 _/o|_____/  ,__________.__;__,__,__,__,_Y...:::---===````//
|==========\  ;  ;  ;  ; \__,__\__,_____ --__,-.\(=~\(=)\((
           `--------|__,__/__,__/__/  )=))~((   '-\=(\&(~\\\
                      \ ==== \          \\~~\\     \~~)[JW]\\
                      `| === |           ))~~\\     ```- =,))
                       | === |           | '---')
                      / ==== /           `===== '
";
                    break;
                case "Katana":
                    useWeapon.weaponPic = @"
  __-----________________{]____________________________________________
{&&&&&&&#%%&#%&%&%&%&%#%&|]_____________________________________________\
                         {]";
                    break;
                case "Machete":
                    useWeapon.weaponPic = @"
                                ___________________________
                          _.-''`----------------------|`. |``''--..__
                     _.-'` ' ' '' ' ' ' ' ' ' ' ' ' ' | : |          ``'';';--..__
                _.-'`                                 | : |         '   :';       ```';
           _.-'`                        ________/\_/\_|.'_|_       '   :';           /
       _.-'                         _.-'`                    ``''--:.__;';           _|
     .'`                        _.-'`                                     `'`''-._     /
   .`                       _.-'                                                  `'-./
 .'                    _.-'`
/               __..-'`
``'''----'''````";
                    break;
                case "Mace":
                    useWeapon.weaponPic = @"
|\
        | \        /|
        |  \____  / |
       /|__/AMMA\/  |
     /AMMMMMMMMMMM\_|
 ___/AMMMMMMMMMMMMMMA
 \   |MVKMMM/ .\MMMMM\
  \__/MMMMMM\  /MMMMMM---
  |MMMMMMMMMMMMMMMMMM|  /
  |MMMM/. \MM.--MMMMMM\/
  /\MMM\  /MM\  |MMMMMM   ___
 /  |MMMMMMMMM\ |MMMMMM--/   \-.
/___/MMMMMMMMMM\|M.--M/___/_|   \
     \VMM/\MMMMMMM\  |      /\ \/
      \V/  \MMMMMMM\ |     /_  /
        |  /MMMV'   \|    |/ _/
        | /              _/  /
        |/              /| \'
                       /_  /
                       /  /
";
                    break;
                case "Battle Axe":
                    useWeapon.weaponPic= @"
                             .g88888888888888888p.
                           .d8888P""       ""Y8888b.
                           ^Y8P^               ^Y8P'
                              `.               ,'
                               \      .-.    /
                                \    (___)  /
 .--------------.________________:__________j
/               |               |           |`-.,_
\###############|###############|###########|,-'`
 `--------------'                :    ___   l
                                 /   (   )   \
                                /     `-'     \
                               ,'               `.
                           .d8b.               .d8b.
                             ^Y88888888888888888P^
                                ^^YY8888888PP^^
";
                    break;
                case "Khukuri Knife":
                    useWeapon.weaponPic = @"
                                             |_  |
                                               | |
__                      ____                   | |
\ ````''''----....____.'\   ````''''-----------| |--.               _____      .-.
 :.                      `-._                  | |   `''-----''''```     ``''|`: :|
  '::.                       `'--..____________| |                           | : :|
    '::..       ----.....______________________| |                  _____    | : :|
      `'-::..._________________________________| |   `''-----''''```     ``''|`: :|
           ```'''------------------------------| |--'                         `'-'
                                               | |
                                              _| |
                                              |__| 
";
                    break;

                default:
                    break;
            }

            //TODO 2. Add code here to randomly choose a player
            //     2. Create one player
                    Player player = new Player("Leeroy Jenkins", 70, 5, 40, 10, ExperienceLevel.Novice, useWeapon );
           
            //TODO 3. Add Customization based on player experience
            //TODO 3.5. Add customization based on zombie speed
            //TODO 3.75 Add customization based on weapon chosen
         

            //4. Create a loop for the room and zombie

            bool exit = false;
            do
            {
                //enter the room

                //5. Get a room description from a custom method that generates them
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("------ ROOM INFORMATION-------:\n");
                Console.ForegroundColor = ConsoleColor.White;

                Console.WriteLine(GetRoom());
                // 6. Create a zombie in the room for the Player to battle.  
                Elder z1 = new Elder();//uses default ctor
                Elder z2 = new Elder("Bloater", 25, 25, 40, 15, 2, 8,
                "This female zombie is elderly and has gray eyes, an olive complexion, and straight red hair worn loose about the shoulders.  She is a little tall, of average weight, and is wearing a slogan shirt.  She is extremely decayed and is missing several fingers and half a face." ,false);
                Elder z3 = new Elder("Screecher", 25, 25, 40, 15, 2, 8, 
                    "This female zombie is elderly and has green eyes, a fair complexion, and straight light brown hair left uncut.She is a little tall, a bit pudgy, and is wearing outrageous clothing.She is a bit decayed and is missing both arms and a leg.", true);
                Elder z4 = new Elder("Savage", 25, 25, 40, 15, 2, 8,
                    "This male zombie is a elderly and has blue eyes, an olive complexion, and wavy dull blond hair worn short.  He is short, somewhat thin, and is wearing a slogan shirt.  He is quite decayed and is missing an arm, a leg, and the nose.", true);

                Adult z5 = new Adult();//uses default ctor "Buster"
                Adult z6 = new Adult("Shuffler", 25, 25, 40, 15, 2, 8,
                "This female zombie is an adult and has brown eyes, an olive complexion, and wavy blond hair cut short.  She is very tall, of average weight, and is wearing old fashioned clothing.  She is extremely decayed and is missing an arm, both legs, and half a face.", true);
                Adult z7 = new Adult("Howler", 25, 25, 40, 15, 2, 8,
                "This male zombie is an adult and has gray eyes, a fair complexion, and curly golden-blond hair neatly braided.  He is a little tall, fairly muscular, and is wearing very little clothing to speak of.  He is a bit decayed and is missing both arms and most of the face.", false);
                Adult z8 = new Adult("Fader", 25, 25, 40, 15, 2, 8,
                "This male zombie is a young adult and has blue eyes, a dark complexion, and curly golden-blond hair in a mid-length ponytail.  He is short, of average weight, and is dressed very modestly.  He is quite fresh and is missing both arms and both ears.", false);

                Child z9 = new Child(); //uses default ctor "Bony"
                Child z10 = new Child("Hunter", 25, 25, 40, 15, 2, 8,
                "This male zombie is a child and has green eyes, a pale complexion, and wavy platinum blond hair in a short braid.  He is of average height, quite muscular, and is wearing old fashioned clothing.  He is a bit decayed and is missing both legs and both eyes.", false);
                Child z11 = new Child("Blazer", 25, 25, 40, 15, 2, 8,
                "This female zombie is a child and has green eyes, a fair complexion, and curly platinum blond hair cut short.  She is tall, quite heavy, and is wearing very little clothing to speak of.  She is extremely decayed and is missing an arm and an ear.", false);
                Child z12 = new Child("Chomper", 25, 25, 40, 15, 2, 8,
                "This male zombie is a child and has brown eyes, a pale complexion, and curly platinum blond hair cut short.  He is short, of average weight, and is wearing old fashioned clothing.  He is a bit decayed and is missing several fingers, a leg, and both ears.", false);


                //Since all of our child class zombies are all of the type Zombie, we 
                //can store them in an array of type Zombie.

                Zombie[] zombieWork = { z1, z2, z3, z4, z5, z6, z7, z8, z9, z10, z11 };
                Zombie[] populateZombie = new Zombie[100];

                for (int i = 0; i <= 99; i++)
                {
                    int randomIndex = new Random().Next(zombieWork.Length);
                    populateZombie[i] = zombieWork[randomIndex];

                }//end for
                int randIndex = new Random().Next(populateZombie.Length);;
                Zombie useZombie = populateZombie[randIndex];
                //int randomIndex = new Random().Next(zombies.Length);
                //Zombie useZombie = zombies[randomIndex];//Polymorphism, we don't know what kind
                //we will get, so we'll just save it as a Zombie.

                //Show that zombie in the room
                //TODO  Add description of game
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nBEWARE: In this room, "+ useZombie.Name + " lurks about!!");

                //7. Create a loop for the user choice menu (inner loop)
                bool reload = false;
                do
                {
                    //8. Create a menu of options
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine(@"
Please choose an action:
A) Attack
R) Run Away
P) Player Info
Z) Zombie Info
X) Exit
");
                    //9. Capture user choice.
                    string userChoice = Console.ReadKey(true).Key.ToString();

                    Console.Clear();
                    //10. Perform an action based on the users input
                    Console.ForegroundColor = ConsoleColor.Green;
                    switch (userChoice)
                    {
                        case "A":
                            //11. Create attack/battle functionality
                            Combat.DoBattle(player, useZombie);
                            //12. Handle if the user wins
                            if (useZombie.Life <= 0)
                            {
                                //its dead!!
                                //You could put logic here to have the 
                                //player get some items, heal a bit, or exp
                                //due to defeating the zombie.
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.Beep(523, 100);
                                Console.WriteLine("\n {0} slayed {1}!\n", player.Name, useZombie.Name);
                                Console.ResetColor();
                                reload = true;//new room and zombie
                                score++;
                            }//end if zombie is dead

                            //Console.WriteLine("Attack Method Goes Here...");
                            break;

                        case "R":
                            //13. Give the zombie a free attack
                            Console.WriteLine("Run Away!!");
                            Console.WriteLine($"{useZombie.Name} attacks as you flee!");
                            Combat.DoAttack(useZombie, player);//free attack
                            Console.WriteLine();
                            reload = true; //"re"load a new room
                            break;

                        case "P":
                            Console.WriteLine("Player Info:");
                            //14. Display Player info
                            
                            //Console.WriteLine("Weapon: " + useWeapon);
                            Console.WriteLine(player);
                            Console.WriteLine("Zombies slain: " + score);
                            break;

                        case "Z":
                            Console.WriteLine("Zombie Info:");
                            //15. Display Zombie info
                            Console.WriteLine(useZombie);//this will use
                            //polymorphism to get the correct ToString
                            break;

                        case "X":
                        case "E":
                        case "Escape":
                            Console.WriteLine("No one likes a quitter....");
                            exit = true;
                            break;

                        default:
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Thou hast chosen an invalid option.");
                            break;
                    }//end switch

                    //16. Check Player Life
                    if (player.Life <= 0)
                    {
                        Console.Beep(523, 100);
                        Console.WriteLine("\nSorry, " + player.Name +", your days as a Zombie Slayer are over..." + useZombie.Name + " slayed YOU!!!\a");
                        exit = true;
                    }//end if player is dead!

                } while (!reload && !exit);
                //While reload and exit are BOTH NOT TRUE, keep looping.
                //If reload is true, leave the inner loop. If exit is true, leave both loops.
            } while (!exit);//While exit is NOT TRUE, keep looping

            Console.WriteLine($"" +
                $"You defeated {score:n0} Zombie{(score == 1 ? "." : "s.")}");

        }//end Main()

        #region Custom Methods
        private static string GetRoom()
        {
            string[] rooms =
            {
                "In the centre of the room is a square, box like mechanical contraption, covered in dials and turning cranks. A number of pipes sprout from the back, hissing steam issues from one of them.",
                "This area opens up into a natural cavern wider than your torchlight allows for. The floor here is slick with some kind of translucent slime, and the walls bear a number of tube like tunnels about a foot in diameter. As you take in the details, a peculiar chittering noise issues from the darkness.",
                "This chamber appears to be completely empty. The walls are made of natural stone chiselled flat and straight. The floor and ceiling are both set with alternating black and red tiles.",
                "The walls of this chamber are roughly hewn. In the centre of the room is a wide pool with creeper vines growing around the edges. The water in the pool is still and dark.",
                "This dark stone chamber filled with wooden tables, chairs and bunks filled with straw. The air here is unpleasant and reeks of stale sweat. As you take in the room, something rustles in one of the far bunks.",
                "This small chamber is filled with rotting waste. The smell is ghastly and potent enough to give you a gagging sensation. Amongst the rubbish you spot old bones and decomposing humanoid corpses.",
                "As the door swings open, you are immediately hit with the awful stench of rotting flesh. Inside, human corpses in yellow robes are littered about the room, sprawled in positions suggesting the horrors of self sacrifice. Ornate knives with wavy blades are still lodged in chests, throats and other vital areas, or clutched in the pale grip rigor mortis. In the centre of the chamber is an obsidian altar decorated with runes!",
                "This large chamber has murals of exquisite beauty covering the walls, depicting landscapes, animals and half human gods. A number of life like statutes stand about the room, in poses of surprise, terror or grim determination. A heavy blue curtain with yellow stars hangs upon the far wall.",
                "This cramped, rectangular bedroom has mismatched wooden and glass furniture.  The floor is wood and the walls are painted and decorated with a wallpaper border.  Light is provided by ceiling lights.  The room is done in cool dark colors and overall almost looks extraterrestrial."
            };
            return rooms[new Random().Next(rooms.Length)];
            
        }

        private static string GetWeapon()
        {
            string[] weapons =
            {
                "CrossBow",
                "Grenade",
                "Katana",
                "Hammer",
                "Handgun",
                "Automatic Rifle",
                "Machete",
                "Mace",
                "Battle Axe",
                "Khukuri Knife"
            }; //end string 
                  return weapons[new Random().Next(weapons.Length)];
        }//GetWeapon()
        
        #endregion
    }//end class
}//end namespace
