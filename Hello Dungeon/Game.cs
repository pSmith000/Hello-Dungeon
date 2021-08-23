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
        bool gameOver = true;

        /// <summary>
        /// Getting input from the player at any point in the code
        /// </summary>
        /// <param name="description"></param>
        /// <param name="choice1"></param>
        /// <param name="choice2"></param>
        /// <returns></returns>
        int GetInput(string description, string choice1, string choice2)
        {
            string input = "";
            int inputRecieved = 0;

            while (!(inputRecieved == 1 || inputRecieved == 2))
            {
                Console.WriteLine(description);
                Console.WriteLine("1. " + choice1);
                Console.WriteLine("2. " + choice2);
                Console.Write("> ");

                input = Console.ReadLine();

                if (input == "1" || input == choice1)
                {
                    inputRecieved = 1;
                }
                else if (input == "2" || input == choice2)
                {
                    inputRecieved = 2;
                }
                else
                {
                    Console.WriteLine("Invalid Input");
                    Console.ReadKey();
                }

                Console.Clear();
            }

            return inputRecieved;
        }

        /// <summary>
        /// Prints player stats neatly in a box
        /// </summary>
        void PrintPlayerStats()
        {
            Console.WriteLine("----------------------------");
            Console.WriteLine("Health: " + health);
            Console.WriteLine("Sanity: " + sanity);
            Console.WriteLine("[REDACTED]: " + infection);
            Console.WriteLine("----------------------------");
            Console.WriteLine("");
        }

        /// <summary>
        /// If player is dead it returns false
        /// If alive it returns true
        /// </summary>
        /// <returns></returns>
        bool PlayerIsAlive()
        {
            if (health <= 0 || sanity <= 0)
            {
                Console.WriteLine("You have perished\n");
                return false;
            }
            return true;
        }

        /// <summary>
        /// This is the start menu where the player goes after each reset
        /// </summary>
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
            Console.WriteLine("Welcome to the game " + name + ".\n'Death teaches th1ngs about l1fe in a way that life never can' - [REDACTED]\n");
            PrintPlayerStats();
        }

        /// <summary>
        /// Asks the player if they choose to have a weapon or not
        /// Sets the weapon variable to true if the player takes a weapon
        /// </summary>
        void AskForWeapon()
        {
            int input = GetInput("Would you like a weapon?", "Yes", "No");

            if (input == 1)
            {
                weapon = true;
                Console.WriteLine("Good choice " + name + "... Survival is key here..");
                Console.WriteLine("*You have picked up a small dagger*\n");
            }

            else if (input == 2)
            {
                weapon = false;
                Console.WriteLine("Hmmm, thats a choice " + name + "... Not a very good one if [REDACTED] comes for you.\n");
            }

            Console.WriteLine("...");
            Console.WriteLine("Do you hear that?");
            Console.WriteLine("");
        }

        /// <summary>
        /// Asks user if they want to run away and initiates combat
        /// </summary>
        void FirstEncounter()
        {
            validInputRecieved = false;

            int run = GetInput("Do you want to run away?", "Yes", "No");

            if (run == 1)
            {
                Console.WriteLine("\nYou run away, blind and alone. [REDACTED] has a way of finding those lost. But you are safe for now.");
                Console.WriteLine("\nPress ENTER to continue");
                Console.ReadKey();
                Console.Clear();
                infection += 20;
                validInputRecieved = true;
            }

            //The monster actually attacks
            else if (run == 2)
            {
                //if the player has a weapon and attacks back
                Console.WriteLine("[REDACTED] is coming. You have no escape\n");
                if (weapon)
                {
                    Console.WriteLine("Ah you have a weapon. You may fight. ");
                    Console.WriteLine("");
                    Console.WriteLine("You slash and hack through [REDACTED] spewing [REDCATED] blood all over the walls. You take mild injuries.");
                    Console.WriteLine("");
                    Console.WriteLine("SUSTAIN 15 DAMAGE");
                    Console.WriteLine("SUSTAIN 20 SANITY LOSS");
                    Console.WriteLine("\nPress ENTER to continue");
                    Console.ReadKey();
                    Console.Clear();
                    health -= 15;
                    sanity -= 20;
                    infection += 5;
                }
                else
                {
                    //the player does not have a weapon
                    Console.WriteLine("");
                    Console.WriteLine("No weapon either... Only god can save you now");
                    Console.WriteLine("");
                    Console.WriteLine("You sit alone in the dark until you feel a soft hand on your shoulder. You look up and see a familiar face.");
                    Console.WriteLine("[REDACTED] lulls you in and attacks. You take severe injuries. [REDACTED] loves playing with prey.");
                    Console.WriteLine("");
                    Console.WriteLine("SUSTAIN 60 DAMAGE");
                    Console.WriteLine("SUSTAIN 40 SANITY LOSS");
                    Console.WriteLine("\nPress ENTER to continue");
                    Console.ReadKey();
                    Console.Clear();
                    health -= 60;
                    sanity -= 40;
                    infection += 5;
                }
            }
        }

        /// <summary>
        /// This is the function to go through 5 random rooms with a random number generator. 
        /// The player has the option after each room to either leave or search another room
        /// </summary>
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
                    //Each of these rooms have a specific scene within them
                    //this could either be good or bad for the player
                    //this is the first room
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
                //The second room
                else if (room1 == 2)
                {
                    Console.WriteLine("You walk in to a room with a roaring fireplace and lush carpets. On the table you find a medkit and heal 20 health!");
                    health += 20;
                    if (health > 100)
                    {
                        health = 100;
                    }
                }
                //the third room
                else if (room1 == 3)
                {
                    Console.WriteLine("You enter in a sanctuary of sorts. There are pews, symbolic pieces, and scripture on the walls. It feels safe. You regain 20 sanity.");
                    sanity += 20;
                    if (sanity > 100)
                    {
                        sanity = 100;
                    }
                }
                //the fourth room
                else if (room1 == 4)
                {
                    Console.WriteLine("You walk in to a room that smells strongly of iron. It is too dark to see but the walls are covered in a warm liquid. \n" +
                        "While it does make you nauseous, you are safe.\n");
                    Console.WriteLine("SUSTAIN 30 SANITY LOSS");
                    sanity -= 30;
                }
                //the fifth room
                else if (room1 == 5)
                {
                    Console.WriteLine("You stumble into a long hallway. As you walk down this dim lit path you find a sword lying on the ground.\n" +
                        "You may take it if you do not have a weapon already.");
                    weapon = true;
                }
                Console.WriteLine("");

                PrintPlayerStats();

                //If the player is dead the function breaks and goes directly to the RestartGame function
                if (PlayerIsAlive() == false)
                {
                    return;
                }
                while (validInputRecieved == false)
                {
                    //the player gets 5 rooms in total to check, but at the risk of losing health or sanity
                    //they get the coice here to either leave or search more rooms
                    Console.Write("You only have time to search " + (i-1) +" more rooms. Would you like to \n1. Leave this building?\n2. Keep searching \n> ");
                    string leaveBuilding = Console.ReadLine();
                    if (leaveBuilding == "1")
                    {
                        i = 0;
                        break;
                    }
                    else if (leaveBuilding == "2")
                    {
                        validInputRecieved = true;
                        Console.WriteLine("\nYou decide to push forward to the next room.");
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

        /// <summary>
        /// This is the boss battle. It gives the player lore and a small fight sequence
        /// </summary>
        void BossBattle1()
        {
            //The start of the boss 'cutscene'
            Console.WriteLine("You trace your steps back and leave the way you came.");
            Console.WriteLine("");
            Console.WriteLine("You approach the darkness surrounding you. You look up and it meets your gaze. \n" 
                + "[Redacted] stares not at you, but through you. Not through the player, but at you " + name +
                ". \nThrough the very screen you stare at. \n[REDACTED] never leaves. \n[REDACTED] never falters.");

            //getting input to see if the player wants to fight. the p[layer has no choice but to fight though
            int input = GetInput("\n'Do you wish to fight?'", "Yes", "Yes");
            Console.Clear();
            if (input == 1)
            {
                //if the player wants to fight and has a weapon they get attacked heavily
                //but if the player has no weapon than the enemy feels bad and doesn't attack as heavily
                Console.WriteLine("\n'You shall regret the moment you ever looked at a screen'");
                Console.WriteLine("");
                Console.WriteLine("[REDACTED] charges at you and attacks, but halts its swing right before landing.");
                Console.WriteLine("\n'Are you scared yet?'");
                Console.WriteLine("\nPress ENTER to continue");
                Console.ReadKey();
                Console.Clear();

                if (weapon == true)
                {
                    //The player has a weapon
                    Console.WriteLine("\nYou take your weapon and swing right for it's throat. It seems to pass through like nothing was ever there.");
                    Console.WriteLine("[REDACTED] makes a sound similar to human laughter");
                    Console.WriteLine("\n'Do you not understand yet. I am [REDACTED] and this is my world!'");
                    Console.WriteLine("\nYou watch as flesh gets torn from your body. Swing after swing this creature rips off more than you can take." +
                        "\nYou black out.\n\nSUSTAIN 60 DAMAGE\nSUSTAIN 50 SANITY LOSS");
                    Console.WriteLine("\n\nPress ENTER to continue");
                    Console.ReadKey();
                    Console.Clear();
                    health -= 60;
                    sanity -= 50;
                    infection += 40;

                    //Another player health and sanity check
                    if (PlayerIsAlive() == false)
                    {
                        return;
                    }


                }
                else
                {
                    //The player does not have a weapon
                    Console.WriteLine("'You have no weapon to hold against me. I feel sorry for such a pitiful creature'");
                    Console.WriteLine("'You hold not a candle to the power I hold. [REDACTED] goes beyond the screen and beyond this user." +
                        "\nBeyond this game as you so call it. I shall try to spare your life with this next blow " + name + " if that even is " +
                        "your real name. Hold on to your life so that I may play with it.'");
                    Console.WriteLine("");
                    Console.WriteLine("You feel a strike lay upon your chest. You begin to fall faint from such a quick blow." +
                        "\nSUSTAIN 35 DAMAGE\nSUSTAIN 40 SANITY LOSS");
                    Console.WriteLine("\n\nPress ENTER to continue");
                    Console.ReadKey();
                    Console.Clear();
                }
            }
            else if (input == 2)
            {
                //if the play trie to hit the second yes ooption, which was in other questions the no option,
                //then the enemy instantly kills the player
                Console.WriteLine("'You tried not to fight me, didn't you. You tried to press no, but you couldn't. " +
                    "\nSee what you don't understand is that I am all powerful. I am all encompassing. I am [REDACTED]." +
                    "\nIf you were too afraid to fight me, then I won't even give you the chance. I shall reboot you now.");
                Console.WriteLine("\nPress ENTER to reboot");
                Console.ReadKey();
                Console.Clear();
                health -= 200;
                sanity -= 200;
                infection += 50;

                if (PlayerIsAlive() == false)
                {
                    return;
                }

            }
        }

        /// <summary>
        /// Asks if player would like to restart game
        /// </summary>
        void RestartGame()
        {
            int continueGame = GetInput("This is all there is in the BETA build. Would you like to restart?", "Yes", "No");

            //player chooses to restart, exiting the function and reitterating the while loop
            if (continueGame == 1)
            {
                Console.WriteLine("\nYou have chosen to restart. [REDACTED] reaches out and you grab it's hand. \n'It is time to reboot you now, little one'\n");
                Console.WriteLine("Press ENTER to continue");
                Console.ReadKey();
                Console.Clear();
            }
            //the game ends
            else if (continueGame == 2)
            {
                //Setting gameOver to false to end the game
                Console.WriteLine("You have chosen the easy way out this time...\nNext time you won't be so lucky."+
                    "\n\nPress ENTER to end this world");
                Console.ReadKey();
                Console.Clear();
                gameOver = false;
            }
        }
        
        public void Run()
        {
            //The main code uses gameOver boolean for checking if the game has ended yet
            while (gameOver != false)
            {
                //resets health and sanity but not infection. That lasts through games
                health = 100;
                sanity = 100;

                StartMenu();

                AskForWeapon();

                //The monster starts to sense the player
                FirstEncounter();

                //End of stage 1
                Console.WriteLine("---------------------------------------");
                Console.WriteLine("-------------END OF STAGE 1------------");
                Console.WriteLine("---------------------------------------");
                Console.WriteLine("");
                PrintPlayerStats();
                Console.WriteLine("");
                Console.WriteLine("Press ENTER to continue");
                Console.ReadKey();
                Console.Clear();

                //Start screen for stage 2
                Console.WriteLine("---------------------------------------");
                Console.WriteLine("------------START OF STAGE 2-----------");
                Console.WriteLine("---------------------------------------");
                Console.WriteLine("");
                Console.WriteLine("Press ENTER to continue");
                Console.ReadKey();
                Console.Clear();

                RoomJourney();

                Console.Clear();

                //End screen for stage 2
                Console.WriteLine("---------------------------------------");
                Console.WriteLine("-------------END OF STAGE 2------------");
                Console.WriteLine("---------------------------------------");
                Console.WriteLine("");
                PrintPlayerStats();
                Console.WriteLine("");
                Console.WriteLine("Press ENTER to continue");
                Console.ReadKey();
                Console.Clear();

                //Start screen for stage 3
                Console.WriteLine("---------------------------------------");
                Console.WriteLine("------------START OF STAGE 3-----------");
                Console.WriteLine("---------------------------------------");
                Console.WriteLine("");
                Console.WriteLine("Press ENTER to continue");
                Console.ReadKey();
                Console.Clear();

                BossBattle1();

                //End screen for stage 3
                Console.WriteLine("---------------------------------------");
                Console.WriteLine("-------------END OF STAGE 3------------");
                Console.WriteLine("---------------------------------------");
                Console.WriteLine("");
                PrintPlayerStats();
                Console.WriteLine("");
                Console.WriteLine("Press ENTER to continue");
                Console.ReadKey();
                Console.Clear();

                RestartGame();
            }
            

        }
    }
}
