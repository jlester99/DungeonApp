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
            string txt = "Zombie Slayer";
            Console.Title = txt;

            //centering text in the console window
            Console.WriteLine("{0," +
                ((Console.WindowWidth / 2) + txt.Length / 2) + "}", txt);

            Console.WriteLine("Welcome to the Apocolypse!  Your Journey starts now....\n");

            int score = 0;

            //1.Create a Random Weapon for the Player
             string weaponRetrieved =GetWeapon();

            Weapon useWeapon = new Weapon(1, 8, weaponRetrieved, 10, true);

            switch (weaponRetrieved)
            {
                case "CrossBow":
                case "Grenade":
                case "Spear Gun":
                case "Handgun":
                case "Automatic Rifle":
                    useWeapon.IsCloseRangeRequired = false;
                    break;
            }

            //2. Create a Player
            Player player = new Player("Leeroy Jenkins", 70, 5, 40, 10, ExperienceLevel.Novice, useWeapon );
           
            //TODO 3. Add Customization based on player weapon
         

            //4. Create a loop for the room and zombie

            bool exit = false;
            do
            {
                //enter the room

                //5. Get a room description from a custom method that generates them
                Console.WriteLine(GetRoom());
                // 6. Create a zombie in the room for the Player to battle.
                //Learn about creating objects and randomly selecting them
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

                //Since all of our child class zombies are all of the type Zombie, we 
                //can store them in an array of type Zombie.
                //Zombie[] zombies = { z1, z1, z2, z1, z2, z2, z1, z5, z6, z6, z1, z5, z5, z6 };

                Zombie[] zombieWork = { z1, z2, z3, z4, z5, z6, z7, z8, z9 };
                Zombie[] populateZombie = new Zombie[100];
                //Zombie[] zombieWork = { z1, z2, z3, z4, z5, z6, z7, z8, z9, z10 };
                ////string[] zombieChoices;

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
                Console.WriteLine("\nBEWARE: In this room, "+ useZombie.Name + " lurks about!!");

                //7. Create a loop for the user choice menu (inner loop)
                bool reload = false;
                do
                {
                    //8. Create a menu of options
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
                                Console.WriteLine("\n {0} killed {1}!\n", player.Name, useZombie.Name);
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
                            Console.WriteLine("Thou hast chosen an invalid option.");
                            break;
                    }//end switch

                    //16. Check Player Life
                    if (player.Life <= 0)
                    {
                        Console.WriteLine("\nSorry, Zombie Slayer... you will soon be joining the Zombies!!!\a");
                        exit = true;
                    }//end if player is dead!

                } while (!reload && !exit);
                //While reload and exit are BOTH NOT TRUE, keep looping.
                //If reload is true, leave the inner loop. If exit is true, leave both loops.
            } while (!exit);//While exit is NOT TRUE, keep looping

            Console.WriteLine($"" +
                $"You defeated {score:n0} zombie{(score == 1 ? "." : "s.")}");

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
            //MINI-LAB
            //Finish the string array, and return one of the room descriptions.
            //Random rand = new Random();

            //int indexNbr = rand.Next(rooms.Length);

            //string room = rooms[indexNbr];

            //return room;

            //refactored
            return rooms[new Random().Next(rooms.Length)];
            
        }

        private static string GetWeapon()
        {
            string[] weapons =
            {
                "Crossbow",
                "Grenade",
                "Katana",
                "Slingshot",
                "Barbed Wire Bat",
                "Automatic Rifle",
                "Machete",
                "Mace",
                "Battle Axe",
                "Khukuri Knife"
            }; //end string 
                  return weapons[new Random().Next(weapons.Length)];
        }//GetWeapon()
        

        //private static string GetZombie()
        //{
        //    string[] zombies =
        //    {
        //        "This female zombie is middle-aged and has brown eyes, an olive complexion, and wavy blond hair cut short.  She is very tall, of average weight, and is wearing old fashioned clothing.  She is extremely decayed and is missing an arm, both legs, and half a face.",
        //        "This male zombie is a teenager and has dark brown eyes, a dark complexion, and curly dark brown hair cut short.  He is a little tall, quite heavy, and is wearing very colorful clothing.  He is extremely decayed and is missing both arms, a leg, and both eyes.",
        //        "This female zombie is elderly and has gray eyes, an olive complexion, and straight red hair worn loose about the shoulders.  She is a little tall, of average weight, and is wearing a slogan shirt.  She is extremely decayed and is missing several fingers and half a face.",
        //        "This male zombie is a teenager and has brown eyes, a pale complexion, and wavy light brown hair left uncut.  He is of average height, quite muscular, and is wearing old fashioned clothing.  He is extremely decayed and is missing an arm and both legs.",
        //        "This female zombie is a child and has dark brown eyes, a dark complexion, and wavy light brown hair left uncut.  She is short, quite heavy, and is wearing a slogan shirt.  She is a bit decayed and is missing both legs and an earn",
        //        "This male zombie is an adult and has blue eyes, an olive complexion, and wavy dull blond hair worn short.  He is short, somewhat thin, and is wearing a slogan shirt.  He is quite fresh and is missing an arm, a leg, and the nose.",
        //        "This male zombie is elderly and has gray eyes, an olive complexion, and wavy blond hair worn long.  He is tall, of average weight, and is wearing very little clothing to speak of.  He is quite fresh and is missing both legs and both ears.",
        //        "This female zombie is elderly and has green eyes, a fair complexion, and straight light brown hair left uncut.  She is a little tall, a bit pudgy, and is wearing outrageous clothing.  She is a bit decayed and is missing both arms and a leg.",
        //        "This male zombie is an adult and has gray eyes, a fair complexion, and curly golden-blond hair neatly braided.  He is a little tall, fairly muscular, and is wearing very little clothing to speak of.  He is a bit decayed and is missing both arms and most of the face.",
        //        "This male zombie is a child and has green eyes, a pale complexion, and wavy platinum blond hair in a short braid.  He is of average height, quite muscular, and is wearing old fashioned clothing.  He is a bit decayed and is missing both legs and both eyes." };
        //    }; //end string 
        //    return zombies[new Random().Next(zombies.Length)];

        #endregion
    }//end class
}//end namespace
