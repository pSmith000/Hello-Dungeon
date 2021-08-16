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
            Console.WriteLine("Hello " + name + "! Your health is " + health + ".");

            Console.WriteLine("");
            Console.Write("Would you like a weapon? (Y/N): ");
            weaponAsk = Console.ReadLine();

            if (weaponAsk == "Y")
            {
                weapon = true;
                Console.WriteLine("Good choice" + name + "... Survival is key here..");
            }

            else
            {
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
                if (weapon = true)
                {
                    Console.WriteLine("Ah you have a weapon. ")
                }
            }
        }
    }
}
