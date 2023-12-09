using System;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;


namespace MyApp // Note: actual namespace depends on the project name.
{
    internal class Program
    {

        static void Main(string[] args)
        {
            string[] inventory = new string[5] { " ", " ", " ", " ", " " };
            int inventory_spaces = 0;
            Random rnd = new Random();
            Console.Title = "YOUR MOTHER";
            Console.ForegroundColor = ConsoleColor.Green;

            title_image();

            // figure out character stuff
            
            string? name; 
            do
            {
                Console.Write("Your Character's name: ");
                name = Console.ReadLine();
                if (name == null)
                {
                    Console.WriteLine("No.");
                    Console.ReadKey();
                    Console.Clear();
                } // name
            }
            while(name == null);
            
            string? gender;
            do
            {
                Console.Write(name + "'s gender? (m/f): ");
                gender = Console.ReadLine();
                if (gender != "m" && gender != "f")
                {
                    Console.WriteLine("INVALID RESPONSE");
                    Console.ReadKey();
                    Console.Clear();
                } 
            }
            while(gender != "m" && gender != "f");


            Console.WriteLine("\nTap to roll for " + name + "'s stats \n");
            Console.ReadKey();
            int[] statroll = new int[3];
            for (int i = 0; i < 3; i++)
            {
                statroll[i] = rnd.Next(1, 7) + rnd.Next(1, 7) + rnd.Next(1, 7);
            }

            int chaStrength = statroll[0]; // character strength
            int chaIntel = statroll[1]; // character intelligence
            int chaDex = statroll[2]; // character dexterity

            int strengthbonus = calc_modifier(chaStrength); // bonus calculated by strength, intelligence, and dexterity score.
            int intelbonus = calc_modifier(chaIntel);
            int dexbonus = calc_modifier(chaDex);

            int maxHealth = calc_maxhealth(chaStrength, chaDex);
            int currentHealth = maxHealth;
            string clothes = "null";

            Console.WriteLine("\nYour strength is: " + chaStrength + "\nAnd your strength mod is: +" + strengthbonus); // display Ability scores and mods.
            Console.WriteLine("\nYour intelligence is: " + chaIntel + "\nAnd your intelligence mod is: +" + intelbonus);
            Console.WriteLine("\nYour dexterity is: " + chaDex + "\nAnd your dexterity mod is: +" + dexbonus);
            Console.WriteLine("\nYour total health is: " + maxHealth);
            Console.WriteLine("\nPress any key to Continue");
            Console.ReadKey();

            Console.Clear();

            // start the story
            Console.WriteLine("\n" + name + " wakes up to the same annoying alarm clock, as usual.\n");
            Console.WriteLine("It seems to be another dull morning today. Something feels wrong in your head, but you push off your worries to the side. \n ");

            string? decision1 = decisionMethod1();
            bool death0 = decisionConditional1(decision1);
            if (death0 == true)
            {
                return;
            }

            Console.ReadKey();
            Console.Clear();
            

            string? decision2 = decisionMethod2(decision1);
            Tuple<string, int, int, string[]> decision2CondTupleValues = decisionConditional2(decision2, clothes, intelbonus, currentHealth, maxHealth, inventory_spaces, inventory);

            (clothes, currentHealth, inventory_spaces, inventory) = (decision2CondTupleValues.Item1, decision2CondTupleValues.Item2, decision2CondTupleValues.Item3, decision2CondTupleValues.Item4);
            Console.Clear();

            Console.WriteLine("As " + name + " walks out of their room, they hear a big crash, straight ahead, in the living room. \n");
            Console.ReadKey();
            Console.Clear();


            string? decision3 = decisionMethod3();

            Console.Clear();

            decisionConditional3(decision3, clothes, dexbonus, name ?? clothes, currentHealth, maxHealth, inventory);
        }
        static void title_image()
        {

            string[] title = { " █████╗      ██████╗  █████╗ ███╗   ███╗███████╗", "██╔══██╗    ██╔════╝ ██╔══██╗████╗ ████║██╔════╝", "███████║    ██║  ███╗███████║██╔████╔██║█████╗ ", "██╔══██║    ██║   ██║██╔══██║██║╚██╔╝██║██╔══╝  ", "██║  ██║    ╚██████╔╝██║  ██║██║ ╚═╝ ██║███████╗", "╚═╝  ╚═╝     ╚═════╝ ╚═╝  ╚═╝╚═╝     ╚═╝╚══════╝ \n" };


            Console.WriteLine(title[0]);
            Console.WriteLine(title[1]); Thread.Sleep(200);
            Console.WriteLine(title[2]); Thread.Sleep(200);
            Console.WriteLine(title[3]); Thread.Sleep(200);
            Console.WriteLine(title[4]); Thread.Sleep(200);
            Console.WriteLine(title[5]);
            Console.WriteLine("Press Any Key To Start");
            Console.ReadKey();
            Console.Clear();
        }
        static int calc_modifier(int ability_score)
        {
            int ability_mod = 0;

            if (ability_score >= 3 && ability_score <= 5)
            {
                ability_mod = 1;
            }

            else if (ability_score >= 6 && ability_score <= 8)
            {
                ability_mod = 2;
            }

            else if (ability_score >= 9 && ability_score <= 13)
            {
                ability_mod = 3;
            }

            else if (ability_score >= 14 && ability_score <= 16)
            {
                ability_mod = 4;
            }

            else if (ability_score >= 17 && ability_score <= 18)
            {
                ability_mod = 5;
            }

            return ability_mod;
        }
        static int calc_maxhealth(int strength, int dex)
        {
            int maxHealth = (int)Math.Round((strength * 1.5) + (dex * 1.2));
            return maxHealth;
        }
        static string decisionMethod1()
        {
            string? decision1;
            do
            {

                Console.WriteLine("\n  1. Get out of bed.    2. Go back to sleep.    3. Go outside to the hallway.\n");
                decision1 = Console.ReadLine();
                if (decision1 != "1" && decision1 != "2" && decision1 != "3")
                {
                    Console.WriteLine("INVALID ANSWER");
                    Console.ReadKey();
                    Console.Clear();
                }
            }
            while (decision1 != "1" && decision1 != "2" && decision1 != "3");
            return decision1;
        }
        static bool decisionConditional1(string decision1)
        {
            Random rnd = new Random();
            bool death = false;
            if (decision1 == "1")
            {
                Console.WriteLine("\nYou get out of your bed and find that your room is way colder than it should be. Strange.\n");

            }
            else if (decision1 == "2")
            {
                int i = rnd.Next(1, 6);

                if (i == 1 || i == 2)
                {
                    Console.WriteLine("\nYou pass out and suffocate on your pillow.\n\n Press Y to end the game \n");
                    string? s = Console.ReadLine();

                    if (s == "y" || s == "Y")
                    {
                        death = true;
                    }
                    else
                    {
                        Console.WriteLine("Can you seriously not follow simple instructions?");
                        int ii = rnd.Next(1, 5);

                        if (ii <= 3)
                        {
                            Console.ReadKey();

                        }
                        else if (ii == 4)
                        {
                            Console.ReadKey();
                            Console.WriteLine("Fine, I'll give you one more chance. but don't pull more shit on me.\n");
                            Console.WriteLine("YOU'VE BEEN WARNED");
                            Console.ReadKey();
                            Console.WriteLine("You wake up a bit later feeling even more refrefeshed");
                        }

                    }
                }
                else if (i >= 3)
                {
                    Console.WriteLine("You wake up a bit later feeling a bit more refreshed");
                }
            }
            return death;
        }
        static string decisionMethod2(string decision1)
        {
            string? decision2;
            string temp = " ";
            if (decision1 != "3")
            {
                do
                {
                    Console.WriteLine(" 1. Open your closet.  2. Investigate Your room.(D20) \n");
                    decision2 = Console.ReadLine();
                    if (decision2 != "1" && decision2 != "2")
                    {
                        Console.WriteLine("INVALID RESPONSE");
                        Console.ReadKey();
                        Console.Clear();
                    }
                }
                while (decision2 != "1" && decision2 != "2");
                return decision2;
            }
            return temp;

        }
        static Tuple<string, int, int, string[]> decisionConditional2(string decision2, string clothes, int intelbonus, int currentHealth, int maxHealth, int inventory_spaces, string[] inventory)
        {
            Random rnd = new Random();
            if (decision2 == "1")
            {
                Console.WriteLine("\nYou open your closet and get dressed for the day ahead.");
                clothes = "Common Clothes";
                Console.WriteLine("\nNow wearing: " + clothes);
                Console.ReadKey();
                Console.Clear();

                string? inside_decision2_1;
                do
                {
                    Console.WriteLine("1. Investigate Your room.(D20)  2. Go to the hallway");
                    inside_decision2_1 = Console.ReadLine();
                    if (inside_decision2_1 != "1" && inside_decision2_1 != "2")
                    {
                        Console.WriteLine("INVALID RESPONSE");
                        Console.ReadKey();
                        Console.Clear();
                    }

                }
                while (inside_decision2_1 != "1" && inside_decision2_1 != "2");

                if (inside_decision2_1 == "1")
                {
                    // add stuff from (decision2 == "2") the stuff right down there ⬇️
                    Console.WriteLine("\n Press any key to roll...");
                    Console.ReadKey();
                    Console.WriteLine("\n Rolling intelligence (d20)...");
                    int rollIntel = rnd.Next(1, 21);
                    Console.WriteLine("\n You rolled a: " + (rollIntel + intelbonus) + "(" + rollIntel + " + " + intelbonus + ")");
                    Console.ReadKey();
                    Console.Clear();

                    if (rollIntel == 1)
                    {
                        Console.WriteLine("\nAs you search the room, You accidentally slip on a perfectly placed banana peel.");
                        Console.WriteLine("\nTake twelve damage");
                        currentHealth = currentHealth - 12;
                        Console.WriteLine("HP: " + currentHealth + "/" + maxHealth);


                    }
                    else if (rollIntel == 20)
                    {
                        Console.WriteLine("\nAs you search the room, you find a really rusty crowbar under your bed and a very suspicisous banana peel.");

                        Console.WriteLine("Pickup crowbar? (y/n)");
                        string? i = Console.ReadLine();
                        if (i == "y" || i == "Y")
                        {
                            Console.WriteLine("You have picked up: Rusty Crowbar.");
                            inventory[inventory_spaces] = "Rusty Crowbar";
                            inventory_spaces++;
                        }

                        Console.WriteLine("Pickup Banana Peel? (y/n)");
                        string? ii = Console.ReadLine();
                        if (ii == "y" || ii == "Y")
                        {
                            Console.WriteLine("You have picked up: Banana Peel");
                            inventory[inventory_spaces] = "Banana Peel";
                            inventory_spaces++;
                        }
                        Console.WriteLine("\n\n Inventory:");

                        foreach (string item in inventory)
                        {
                            Console.WriteLine(item);
                        }


                    }
                    else if (rollIntel >= 2 && rollIntel <= 10)
                    {
                        Console.WriteLine("\nYou find nothing of real interest.");
                    }
                    else if (rollIntel >= 10 && rollIntel <= 19)
                    {
                        Console.WriteLine("\nYou find a really rusty crowbar under your bed.");
                        Console.WriteLine("Pickup crowbar? (y/n)");
                        string? i = Console.ReadLine();

                        if (i == "y" || i == "Y")
                        {
                            Console.WriteLine("You have picked up: Rusty Crowbar. \n\nInventory: ");
                            inventory[inventory_spaces] = "Rusty Crowbar";
                            inventory_spaces++;
                            foreach (string item in inventory)
                            {
                                Console.WriteLine(item);
                            }
                        }

                    }
                }
            }
            else if (decision2 == "2")
            {
                Console.WriteLine("\n Press any key to roll...");
                Console.ReadKey();
                Console.WriteLine("\n Rolling intelligence (d20)...");
                int rollIntel = rnd.Next(1, 21);
                Console.WriteLine("\n You rolled a: " + (rollIntel + intelbonus) + "(" + rollIntel + " + " + intelbonus + ")");
                Console.ReadKey();

                if (rollIntel == 1)
                {
                    Console.WriteLine("\nAs you search the room, You accidentally slip on a perfectly placed banana peel.");
                    Console.WriteLine("\nTake twelve damage");
                    currentHealth = currentHealth - 12;
                    Console.WriteLine("HP: " + currentHealth + "/" + maxHealth);


                }
                else if (rollIntel == 20)
                {
                    Console.WriteLine("\nAs you search the room, you find a really rusty crowbar under your bed and a very suspicisous banana peel.");

                    Console.WriteLine("Pickup crowbar? (y/n)");
                    string? i = Console.ReadLine();
                    if (i == "y" || i == "Y")
                    {
                        Console.WriteLine("You have picked up: Rusty Crowbar.");
                        inventory[inventory_spaces] = "Rusty Crowbar";
                        inventory_spaces++;
                    }

                    Console.WriteLine("Pickup Banana Peel? (y/n)");
                    string? ii = Console.ReadLine();
                    if (ii == "y" || ii == "Y")
                    {
                        Console.WriteLine("You have picked up: Banana Peel");
                        inventory[inventory_spaces] = "Banana Peel";
                        inventory_spaces++;
                    }
                    Console.WriteLine("\n\n Inventory:");

                    foreach (string item in inventory)
                    {
                        Console.WriteLine(item);
                    }


                }
                else if (rollIntel >= 2 && rollIntel <= 10)
                {
                    Console.WriteLine("\nYou find nothing of real interest.");
                }
                else if (rollIntel >= 10 && rollIntel <= 19)
                {
                    Console.WriteLine("\nYou find a really rusty crowbar under your bed.");
                    Console.WriteLine("Pickup crowbar? (y/n)");
                    string? i = Console.ReadLine();

                    if (i == "y" || i == "Y")
                    {
                        Console.WriteLine("You have picked up: Rusty Crowbar. \n\nInventory: ");
                        inventory[inventory_spaces] = "Rusty Crowbar";
                        inventory_spaces++;
                        foreach (string item in inventory)
                        {
                            Console.WriteLine(item);
                        }
                    }

                }

                Console.ReadKey();
                Console.Clear();

                string? inside_decision2_2;
                do
                {
                    Console.WriteLine("1. Open your closet.  2. Go to the hallway.");
                    inside_decision2_2 = Console.ReadLine();
                    if (inside_decision2_2 != "1" && inside_decision2_2 != "2")
                    {
                        Console.WriteLine("INVALID RESPONSE");
                        Console.ReadKey();
                        Console.Clear();
                    }

                }
                while (inside_decision2_2 != "1" && inside_decision2_2 != "2");


                if (inside_decision2_2 == "1")
                {
                    Console.WriteLine("You open your closet and get dressed for the day ahead.\n");
                    clothes = "Common Clothes";
                    Console.WriteLine("You are now wearing: " + clothes + "\n");
                    Console.WriteLine("Press any key...");
                    Console.ReadKey();

                }
                else if (inside_decision2_2 == "2")
                {
                    Console.WriteLine("Press any key...");
                    Console.ReadKey();
                }


            }
            return Tuple.Create(clothes, currentHealth, inventory_spaces, inventory);
        }
        static string decisionMethod3()
        {
            string? decision3;
            do
            {
                Console.WriteLine("1. Go to the living room.  2. Go to the Laundry Room.\n");
                decision3 = Console.ReadLine();

                if (decision3 != "1" && decision3 != "2")
                {
                    Console.WriteLine("INVALID RESPONSE");
                    Console.ReadKey();
                    Console.Clear();
                }
            }
            while (decision3 != "1" && decision3 != "2");
            return decision3;
        }
        static void decisionConditional3(string decision3, string clothes, int dexbonus, string name, int currentHealth, int maxHealth, string[] inventory)
        {
            
            if (decision3 == "1")
            {
                string? inside_decision3_1;
                do
                {
                    Console.WriteLine("1. Walk  2. Run  3. Stealth");
                    inside_decision3_1 = Console.ReadLine();
                    if (inside_decision3_1 != "1" && inside_decision3_1 != "2" && inside_decision3_1 != "3")
                    {
                        Console.WriteLine("INVALID RESPONSE");
                        Console.ReadKey();
                        Console.Clear();
                    }
                }
                while (inside_decision3_1 != "1" && inside_decision3_1 != "2" && inside_decision3_1 != "3");
                decisionConditional3path1(decision3, clothes, dexbonus, name, currentHealth, maxHealth, inventory);

            }
            else if (decision3 == "2")
            {

            }



        }
        static string decisionConditional3path1(string decision3, string clothes, int dexbonus, string name, int currentHealth, int maxHealth, string[] inventory)
        {   
            Random rnd = new Random();
            bool advantage = true;
            bool staggered = true;
            int banditHealth = 13;
            if (decision3 == "1")
            {
                string? inside_decision3_1_walk;
                
                if (clothes == "null")
                {
                    Console.WriteLine("As you casually strut into the room, you see a shocked figure in a burglar outfit, holding a huge duffel bag. As he sees you, he looks at your legs and faints.\n");
                    Console.WriteLine("Now your confused. You look down at your own legs and realize that your naked!");
                    Console.WriteLine("Get dressed now? (y/n)");
                    string? i;

                    do
                    {
                        i = Console.ReadLine();
                        if (i != "y" && i != "n")
                        {
                            Console.WriteLine("INVALID RESPONSE");
                            Console.ReadKey();
                            Console.Clear();
                        }
                    }
                    while (i != "y" && i != "n");

                    if (i == "y")
                    {
                        Console.WriteLine("You walk back to your closet and get dressed.");
                        clothes = "Common Clothes";
                        Console.ReadKey();
                        return clothes;
                    }
                    else if (i == "n")
                    {
                        Console.WriteLine("You choose to flex your thighs and stay nude, as you are him.");
                        Console.ReadKey();
                    }
                    Console.Clear();
                }

                else
                {
                    Console.WriteLine("As you casually strut into the room, you see a shocked figure in a burglar outfit, holding a huge duffel bag. \n");
                    Console.WriteLine("1. Talk to him. 2. Fight him. \n");
                    do
                    {
                        inside_decision3_1_walk = Console.ReadLine();
                        if (inside_decision3_1_walk != "1" && inside_decision3_1_walk != "2")
                        {
                            Console.WriteLine("INVALID RESPONSE");
                            Console.ReadKey();
                            Console.Clear();
                        }
                    }
                    while (inside_decision3_1_walk != "1" && inside_decision3_1_walk != "2");
                    Console.Clear();
                    if (inside_decision3_1_walk == "1")
                    {
                        string? inside_decision3_1_walk_dialogue;
                        do
                        {
                            Console.WriteLine("1. 'Who are you?' 2. 'Get out now!' 3. 'Freeze! THE POLICE ARE ON THE WAY!'");
                            inside_decision3_1_walk_dialogue = Console.ReadLine();
                            if (inside_decision3_1_walk_dialogue != "1" && inside_decision3_1_walk_dialogue != "2" && inside_decision3_1_walk_dialogue != "3")
                            {
                                Console.WriteLine("INVALID RESPONSE");
                                Console.ReadKey();
                                Console.Clear();
                            }
                        }
                        while(inside_decision3_1_walk_dialogue != "1" && inside_decision3_1_walk_dialogue != "2" && inside_decision3_1_walk_dialogue != "3");
                        Console.Clear();

                        Console.WriteLine("He looks you dead in the eye for a couple seconds, and then pulls a knife out of his bag and launches himself at you.\n");
                        Console.WriteLine("Press any key to dodge (dex)\n");
                        Console.ReadKey();
                        int rollDex = rnd.Next(1, 21);
                        int rollDexandBonus = rollDex + dexbonus;
                        Console.WriteLine("You rolled a total of: " + rollDexandBonus + " (" + rollDex + " + " + dexbonus + ")");
                        Console.ReadKey();
                        Console.Clear();
                        if (rollDex == 20 && rollDexandBonus >= 20)
                        {
                            Console.WriteLine("You completely dodge the bandit, as he ends up shoving his head into the drywall");
                            banditHealth = banditHealth - 5;
                            Console.ReadKey();
                            Console.Clear();
                            Console.WriteLine("You here the muffled screams of the stuck bandit.\n");
                            Console.WriteLine("1. Call the police  2. Attack the stuck bandit.");
                            string? s;
                            do 
                            {
                                s = Console.ReadLine();
                                if (s != "1" && s != "2")
                                {
                                    Console.WriteLine("INVALID RESPONSE");
                                    Console.ReadKey();
                                    Console.Clear();
                                }
                                Console.Clear();
                            }
                            while(s != "1" && s != "2");
                            if (s == "1")
                            {
                                Console.WriteLine(name + "grabs their cell phone and tries to call 911");
                                Console.ReadKey();
                                Console.Clear();
                                policecall(name, s);
                            }
                        }
                        else if (rollDexandBonus <= 20 && rollDexandBonus >= 13)
                        {
                                                   
                            Console.WriteLine("You successfully dodge the bandit, as he goes flying to the ground.\n");
                            burglarfight(currentHealth, maxHealth, inventory, advantage, staggered);
 
                        }
                        else if (rollDexandBonus <= 12 && rollDexandBonus >= 5)
                        {
                            Console.WriteLine("As he leaps past you, the man nicks you in the shoulder.\n");
                            currentHealth = currentHealth - 6;
                            Console.WriteLine("HP: " + currentHealth + " / " + maxHealth);
                            advantage = false;
                            burglarfight(currentHealth, maxHealth, inventory, advantage, staggered);
                            
                        }
                        else if (rollDexandBonus <= 4 && rollDex > 1)
                        {
                            Console.WriteLine("The burglar shanks your stomach, and causes excruciating pain");
                            currentHealth = currentHealth - 9;
                            Console.WriteLine("HP: " + currentHealth + " / " + maxHealth);
                            advantage = false;
                            burglarfight(currentHealth, maxHealth, inventory, advantage, staggered);
                        }
                        else if (rollDex == 1)
                        {
                            Console.WriteLine("The burglar shanks your stomach, and causes excruciating pain");
                            currentHealth -= 14;
                            Console.WriteLine("HP: " + currentHealth + " / " + maxHealth);
                            advantage = false;
                            staggered = true;
                            burglarfight(currentHealth, maxHealth, inventory, advantage, staggered);
                        }
                   
                    }
                }
                
            }
            else if (decision3 == "2")
            {
                
            }
            return decision3;
        }   
    
        static void policecall(string name, string something)
        {
            Console.ReadKey();
            Console.WriteLine("911, what's your emergency?");
            Console.WriteLine(name + ": Hey uh I found this burglar in my house, \n so I kind of beat the shit out of him.");
        }
        static void burglarfight(int currentHealth, int maxHealth0, string[] inventory, bool advantage, bool staggered)
        {
            
        }
    }

}

