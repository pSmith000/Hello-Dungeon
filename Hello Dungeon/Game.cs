using System;
using System.Collections.Generic;
using System.Text;

namespace Hello_Dungeon
{
    class Game
    {
        public void Run()
        {
            //Initialize variables
            int healthRegen = 50;
            int health = 100;
            int sanity = 100;
            float infection = 1;
            string name = "Empty";
            string medkit = "";
            string weaponAsk = "";
            string run = "";
            bool weapon = false;


            //Injury Check
            if (medkit == "Y")
            {
                health = 100;
                Console.WriteLine("You have been healed.");
            }
    
            //Welcome screen
            Console.WriteLine("H- Hello? Is anyone there?? Please!");
            Console.WriteLine("I can't let this m- maachine take over my mi-");
            Console.WriteLine("R̸͕̻͇͌̿e̵͚͉͇̐́̚b̸͓͙͕́̀o̵̢͓̘͒́ó̴̻̝͓̓͠t̴̙̘͍͌̀̽\n");

            //Ask for name and display stats
            Console.Write("Hello {user}. Please enter your name: ");
            name = Console.ReadLine();
            Console.WriteLine("");
            Console.WriteLine("Hello " + name + "! Your health is " + health + ", your sanity is " + sanity + ", and your [REDACTED] is " + infection + ".");

            //Ask if player wants a weapon
            Console.WriteLine("");
            Console.Write("Would you like a weapon? (Y/N): ");
            weaponAsk = Console.ReadLine();
            Console.WriteLine("");

            //Weapon Check
            if (weaponAsk == "Y")
            {
                weapon = true;
                Console.WriteLine("Good choice " + name + "... Survival is key here..\n");
                Console.WriteLine("*You have picked up a small dagger*\n");
            }

            else
            {
                weapon = false;
                Console.WriteLine("Hmmm, thats a choice " + name + "... Not a very good one if [REDACTED] comes for you.\n");
            }

            Console.WriteLine("...");
            Console.WriteLine("Do you hear that?");
            Console.Write("Do you want to run away? (Y/N): ");
            run = Console.ReadLine();
            Console.WriteLine("");

            //The monster starts to sense the player
            if (run == "Y")
            {
                Console.WriteLine("You run away, blind and alone. [REDACTED] has a way of finding those lost. But you are safe for now.");
                infection += 20;
            }

            //The monster actually attacks
            else
            {
                Console.WriteLine("[REDACTED] is coming. You have no escape\n");
                if (weapon)
                {
                    Console.WriteLine("Ah you have a weapon. You may fight. ");
                    Console.WriteLine("");
                    Console.WriteLine("You slash and hack through [REDACTED] spewing [REDCATED] blood all over the walls. You take mild injuries.");
                    Console.WriteLine("");
                    Console.WriteLine("SUSTAIN 15 DAMAGE");
                    Console.WriteLine("SUSTAIN 20 SANITY LOSS");
                    health -= 15;
                    sanity -= 20;
                    infection += 5;
                }
                else
                {
                    Console.WriteLine("");
                    Console.WriteLine("No weapon either... Only god can save you now");
                    Console.WriteLine("");
                    Console.WriteLine("You sit alone in the dark until you feel a soft hand on your shoulder. You look up and see a familiar face.");
                    Console.WriteLine("[REDACTED] lulls you in and attacks. You take severe injuries. [REDACTED] loves playing with prey.");
                    Console.WriteLine("");
                    Console.WriteLine("SUSTAIN 60 DAMAGE");
                    Console.WriteLine("SUSTAIN 40 SANITY LOSS");
                    health -= 60;
                    sanity -= 40;
                    infection += 5;
                }
            }

            //End of stage 1
            Console.WriteLine("");
            Console.WriteLine("---------------------------------------");
            Console.WriteLine("-------------END OF STAGE 1------------");
            Console.WriteLine("---------------------------------------");
            Console.WriteLine("");
            Console.WriteLine("Health: " + health);
            Console.WriteLine("Sanity: " + sanity);
            Console.WriteLine("[REDACTED]: " + infection);
            Console.WriteLine("");
            Console.WriteLine("Press ENTER to continue");
            Console.ReadKey();
            Console.Clear();

            Console.WriteLine("---------------------------------------");
            Console.WriteLine("------------START OF STAGE 2-----------");
            Console.WriteLine("---------------------------------------");
            Console.WriteLine("");

            Console.WriteLine("You run away and find yourself upon an old building. You hear footsteps behind you. You rush forward into the first room.\n");

            //Random Room Generator
            Random rnd = new Random();
            int room1 = rnd.Next(1, 4);

            if (room1 == 1)
            {
                Console.WriteLine("You walk in to a dimly lit room. A man stands before you bloodied and bruised." +
                    "\n He holds a sword in his hand. He slowly face you and says 'r-r-re b-boot?' The man then" +
                    "\n lunges at you.\n");
                if (weapon == true)
                {
                    Console.WriteLine("You pull out your dagger and slash at the man's face. He pulls back and tilts his head at you." +
                        "\n 're...boot...' He turns away and as he does his body siezes and falls to the ground. He is dead.\n");
                    Console.WriteLine("SUSTAIN 5 SANITY LOSS");
                    infection += 5;
                    sanity -= 5;
                }
                else
                {
                    Console.WriteLine("The man swings his sword widly at you. With no weapon yourself you are defenseless." +
                        "\n He madly slashes your chest and arms screaming the same word over and over again." +
                        "\n re..boot   rebOOT   REBOOT   ??REE??BOOTT?????REEEB?OO?TTT\n He collapses to the floor in the middle of one of his swings at you.\n");
                    Console.WriteLine("You take severe injuries");
                    Console.WriteLine("SUSTAIN 35 DAMAGE");
                    Console.WriteLine("SUSTAIN 15 SANITY LOSS");
                    infection += 5;
                    health -= 35;
                    sanity -= 15;
                }
            }
            else if (room1 == 2)
            {
                Console.WriteLine("You walk in to a room with a roaring fireplace and lush carpets. On the table you find a medkit and heal 50 health!");
                health += 50;
                if (health > 100)
                {
                    health = 100;
                }
            }
            else if (room1 == 3)
            {
                Console.WriteLine("You enter in a sanctuary of sorts. There are pews, symbolic pieces, and scripture on the walls. It feels safe. You regain 50 sanity.");
                sanity += 50;
                if (sanity > 100)
                {
                    sanity = 100;
                }
            }
            else
            {
                Console.WriteLine("You walk in to a room that smells strongly of iron. It is too dark to see but the walls are covered in a warm liquid. \n" +
                    "While it does make you nauseous, you are safe.\n");
                Console.WriteLine("SUSTAIN 30 SANITY LOSS");
                sanity -= 30;
            }

            Console.WriteLine(health sanity )
        }
    }
}
