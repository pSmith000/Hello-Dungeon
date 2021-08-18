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
            Console.WriteLine("R̸͕̻͇͌̿e̵͚͉͇̐́̚b̸͓͙͕́̀o̵̢͓̘͒́ó̴̻̝͓̓͠t̴̙̘͍͌̀̽");
            Console.WriteLine("");

            //Ask for things
            Console.Write("Hello {user}. Please enter your name: ");
            name = Console.ReadLine();
            Console.WriteLine("Hello " + name + "! Your health is " + health + ". And your sanity is " + sanity);

            Console.WriteLine("");
            Console.Write("Would you like a weapon? (Y/N): ");
            weaponAsk = Console.ReadLine();

            //Weapon Check
            if (weaponAsk == "Y")
            {
                weapon = true;
                Console.WriteLine("Good choice " + name + "... Survival is key here..");
            }

            else
            {
                weapon = false;
                Console.WriteLine("Hmmm, thats a choice " + name + "... Not a very good one if [REDACTED] comes for you.");
            }

            Console.WriteLine("...");
            Console.WriteLine("Do you hear that?");
            Console.WriteLine("Do you want to run away? (Y/N): ");
            run = Console.ReadLine();

            if (run == "Y")
            {
                Console.WriteLine("You run away, blind and alone. [REDACTED] has a way of finding those lost. But you are safe for now.");
            }

            else
            {
                Console.WriteLine("[REDACTED] is coming. You have no escape");
                if (weapon == true)
                {
                    Console.WriteLine("Ah you have a weapon. You may fight. ");
                    Console.WriteLine("");
                    Console.WriteLine("You slash and hack through [REDACTED] spewing [REDCATED] blood all over the walls. You take mild injuries.");
                    health -= 15;
                }
                else
                {
                    Console.WriteLine("");
                    Console.WriteLine("No weapon either... Only god can save you now");
                    Console.WriteLine("");
                    Console.WriteLine("You sit alone in the dark until you feel a soft hand on your shoulder. You look up and see a familiar face.");
                    Console.WriteLine("[REDACTED] lulls you in and attacks. You take severe injuries. [REDACTED] loves playing with prey.");
                    health -= 60;
                }
            }
            Console.WriteLine("");
            Console.WriteLine("END OF STAGE 1");
            Console.WriteLine("Health: " + health);
        }
    }
}
