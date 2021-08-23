using System;
using System.Collections.Generic;
using System.Text;

namespace Hello_Dungeon
{
    class Game
    {
        //Initialize variables
        int health = 100;
        int sanity = 100;
        float infection = 1;
        bool validInputRecieved = false;
        string run = "";
        string name = "";
        bool weapon = false;
        string weaponAsk = "";
        string continueGame = "";

        int Getinput(string description, int choice1, int choice2)
        {

        }

        void PrintPlayerStats()
        {
            Console.WriteLine("----------------------------");
            Console.WriteLine("Health: " + health);
            Console.WriteLine("Sanity: " + sanity);
            Console.WriteLine("[REDACTED]: " + infection);
            Console.WriteLine("----------------------------");
            Console.WriteLine("");
        }

        void PlayerStatsCheck

        void StartMenu()
        {
            //Welcome screen
            Console.WriteLine("H- Hello? Is anyone there?? Please!");
            Console.WriteLine("I can't let this m- maachine take over my mi-");
            Console.WriteLine("R̸͕̻͇͌̿e̵͚͉͇̐́̚b̸͓͙͕́̀o̵̢͓̘͒́ó̴̻̝͓̓͠t̴̙̘͍͌̀̽\n");

            //Ask for name and display stats
            Console.Write("Hello {user}. Please enter your name: ");
            name = Console.ReadLine();
            Console.WriteLine("");
            Console.WriteLine("Welcome to the game " + name + ".\n 'Death teaches th1ngs about l1fe in a way that life never can' - [REDACTED]\n");
            PrintPlayerStats();

            //Ask if player wants a weapon
            Console.WriteLine("");
        }

        void AskForWeapon()
        {
            validInputRecieved = false;
            while (validInputRecieved == false)
            {
                Console.Write("Would you like a weapon? (Y/N): ");
                weaponAsk = Console.ReadLine();
                Console.WriteLine("");

                //Weapon Check
                if (weaponAsk == "Y")
                {
                    weapon = true;
                    Console.WriteLine("Good choice " + name + "... Survival is key here..");
                    Console.WriteLine("*You have picked up a small dagger*\n");
                    validInputRecieved = true;
                }

                else if (weaponAsk == "N")
                {
                    weapon = false;
                    Console.WriteLine("Hmmm, thats a choice " + name + "... Not a very good one if [REDACTED] comes for you.\n");
                    validInputRecieved = true;
                }
                else
                {
                    Console.WriteLine("ERROR | That is not a valid answer. Try again. | ERROR\n");
                }
            }
        }

        /// <summary>
        /// Asks user if they want to run away and initiates combat
        /// </summary>
        void FirstEncounter()
        {
            validInputRecieved = false;
            while (validInputRecieved == false)
            {
                Console.Write("Do you want to run away? (Y/N): ");
                run = Console.ReadLine();

                if (run == "Y")
                {
                    Console.WriteLine("\nYou run away, blind and alone. [REDACTED] has a way of finding those lost. But you are safe for now.");
                    infection += 20;
                    validInputRecieved = true;
                }

                //The monster actually attacks
                else if (run == "N")
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
                        validInputRecieved = true;
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
                        validInputRecieved = true;
                    }
                }
                else
                {
                    Console.WriteLine("ERROR | That is not a valid answer. Try again. | ERROR\n");
                }
            }
        }

        void RoomJourney()
        {
            validInputRecieved = false;

            //Random Room Generator

            for (int i = 5; i > 0; i--)
            {
                Random rnd = new Random();
                int room1 = rnd.Next(1, 5);

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
                    Console.WriteLine("You walk in to a room with a roaring fireplace and lush carpets. On the table you find a medkit and heal 20 health!");
                    health += 20;
                    if (health > 100)
                    {
                        health = 100;
                    }
                }
                else if (room1 == 3)
                {
                    Console.WriteLine("You enter in a sanctuary of sorts. There are pews, symbolic pieces, and scripture on the walls. It feels safe. You regain 20 sanity.");
                    sanity += 20;
                    if (sanity > 100)
                    {
                        sanity = 100;
                    }
                }
                else if (room1 == 4)
                {
                    Console.WriteLine("You walk in to a room that smells strongly of iron. It is too dark to see but the walls are covered in a warm liquid. \n" +
                        "While it does make you nauseous, you are safe.\n");
                    Console.WriteLine("SUSTAIN 30 SANITY LOSS");
                    sanity -= 30;
                }
                else if (room1 == 5)
                {
                    Console.WriteLine("You stumble into a long hallway. As you walk down this dim lit path you find a sword lying on the ground.\n" +
                        "You may take it if you do not have a weapon already.");
                    weapon = true;
                }
                Console.WriteLine("");
                Console.WriteLine(" Your health is " + health + ", your sanity is " + sanity + ", and your [REDACTED] is " + infection + ".\n");
                while (validInputRecieved == false)
                {
                    Console.Write("You only have time to search " + (i-1) +" more rooms. Would you like to \n1. Leave this building?\n2. Keep searching \n(1/2): ");
                    string leaveBuilding = Console.ReadLine();
                    if (leaveBuilding == "1")
                    {
                        i = 0;
                        break;
                    }
                    else if (leaveBuilding == "2")
                    {
                        validInputRecieved = true;
                        Console.WriteLine("You decide to push forward to the next room.");
                        Console.WriteLine("Press ENTER to continue");
                        Console.ReadKey();
                        Console.Clear();
                    }
                    else
                    {
                        Console.WriteLine("ERROR | That is not a valid answer. Try again. | ERROR\n");
                    }
                }
                validInputRecieved = false;
            }
        }
        
        public void Run()
        {
            health = 100;
            sanity = 100;
            string continueGame = "";
            while (continueGame != "N")
            {
                StartMenu();

                AskForWeapon();

                Console.WriteLine("...");
                Console.WriteLine("Do you hear that?");
                Console.WriteLine("");

                //The monster starts to sense the player
                FirstEncounter();

                //End of stage 1
                Console.WriteLine("");
                Console.WriteLine("---------------------------------------");
                Console.WriteLine("-------------END OF STAGE 1------------");
                Console.WriteLine("---------------------------------------");
                Console.WriteLine("");
                PrintPlayerStats();
                Console.WriteLine("");
                Console.WriteLine("Press ENTER to continue");
                Console.ReadKey();
                Console.Clear();

                Console.WriteLine("---------------------------------------");
                Console.WriteLine("------------START OF STAGE 2-----------");
                Console.WriteLine("---------------------------------------");
                Console.WriteLine("");
                Console.WriteLine("Press ENTER to continue");
                Console.ReadKey();
                Console.Clear();

                Console.WriteLine("You run away and find yourself upon an old building. You hear footsteps behind you. You rush forward into the first room.\n");

                RoomJourney();

                Console.WriteLine("You trace your steps back through the building and come back out the way you came.");
                Console.WriteLine("");
                Console
                while (validInputRecieved == false)
                {
                    Console.Write("This is all there is in this beta build. Would you like to restart? (Y/N): ");
                    continueGame = Console.ReadLine();
                    if (continueGame == "Y")
                    {
                        Console.WriteLine("\nYou have chosen to restart. [REDACTED] reaches out and you grab it's hand. \n'It is time to reboot you now, little one'\n");
                        Console.WriteLine("Press ENTER to continue");
                        Console.ReadKey();
                        Console.Clear();
                        validInputRecieved = true;
                    }
                    else if (continueGame == "N")
                    {

                    }
                    else
                    {
                        Console.WriteLine("ERROR | That is not a valid answer. Try again. | ERROR\n");
                    }
                }
            }
            

        }
    }
}
