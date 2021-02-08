using System;
using System.Threading;
using EscapeFromOrdwood.Project.Interfaces;
using EscapeFromOrdwood.Project.Models;

namespace Project.EscapeFromOrdwood
{
    public class GameService : IGameService
    {
        private bool running = true;
        public Room CurrentRoom { get; set; }
        public Player CurrentPlayer { get; set; }

        //Initializes the game, creates rooms, their exits, and add items to rooms
        public void Setup()
        {
            

            #region Rooms
            Room dungeon = new Room("The Dungeon", "You sit in a cold damp cell, it is very dimly lit and you can hear an ocean of whispers and screams that has become a part of your madness, you must escape this place. The only exit is the door to your cell which has a small lock.\nYou notice a small hairpin wedged into the wall, you see the words \"Death is L\" scribbled beside it.", "You sit in a cold damp cell, it is very dimly lit and you can hear an ocean of whispers and screams that has become a part of your madness, you must escape this place. The only exit is the door to your cell which has a small lock.");
            Room smallHallway = new Room("A Small Hallway", "", "A thin hallway that seems to get smaller the further you walk, this isnt the time to get claustrophobic. You can barely make out 2 doors in the darkness, one to the west and one to the south");
            Room crypt = new Room("The Crypt", "", $"A glow escapes this room through its open doorways. The masonry between every stone emanates an unnatural yellow radiance. Glancing quickly about the room, you note that each stone bears the carving of someone's name.\nYou notice the door you unlocked to the north as well as a large glowing door to the east");
            Room puzzleRoomOne = new Room("A Puzzle Room", "Unlike the flagstone common throughout the dungeon, this room is walled and floored with black marble veined with white. The ceiling is similarly marbled, but the thick pillars that hold it up are white.\nA brown stain drips down one side of a nearby pillar. In the corner of the room you see a slender and small lizard type creature whispering to himself clutching something that gives off a yellow glow, when he realizes you are there he snaps his upperbody towards you and begins \n\n\"H-h-hello warmblood, you wantsss the shiny? You must s-s-sssolve my riddle first\"", "Unlike the flagstone common throughout the dungeon, this room is walled and floored with black marble veined with white. The ceiling is similarly marbled, but the thick pillars that hold it up are white.\nA brown stain drips down one side of a nearby pillar.");
            Room bedChamber = new Room("The BedChamber", "As you enter, the room comes alive with light and music. A sourceless, warm glow suffuses the chamber, and a harp you cannot see plays soothing sounds. Unfortunately, the rest of the chamber isn't so inviting.\nThe floor is strewn with the smashed remains of rotting furniture. It looks like the room once held a bed, a desk, a chest, and a chair. You can see a fine looking sword amongst the tattered furniture. You notice a menacing door to the east that appears to be covered in blood, and a seemingly normal door to the north.", "As you enter, the room comes alive with light and music. A sourceless, warm glow suffuses the chamber, and a harp you cannot see plays soothing sounds. Unfortunately, the rest of the chamber isn't so inviting.\nThe floor is strewn with the smashed remains of rotting furniture. It looks like the room once held a bed, a desk, a chest, and a chair. You notice a menacing door to the east that appears to be covered in blood, and a seemingly normal door to the north.");
            Room puzzleRoomTwo = new Room("Puzzle Room two", "The manacles set into the walls of this room give you the distinct impression that it was used as a prison and torture chamber, although you can see no evidence of torture devices.\nOne particularly large set of manacles -- big enough for an ogre -- have been broken open. As you step further into the room, you hear from above another riddle.", "The manacles set into the walls of this room give you the distinct impression that it was used as a prison and torture chamber, although you can see no evidence of torture devices.\nOne particularly large set of manacles -- big enough for an ogre -- have been broken open. You notice unlocked doors to the east and south");
            Room puzzleRoomThree = new Room("Puzzle Room three", "This is it! The final room, you hear from above another riddle, if you are to solve this you will surely receive the key for the large gate that is directly ahead of you.", "You are in a large chamber with flagstone covering every service, it is well lit with torches lining the walls however it seems that no one has stepped foot in here for some time. You see a very Large gate with light escaping through the cracks.");
            Room outside = new Room("Outside", "", "");
            #endregion

            #region Items
            Item hairpin = new Item("Hairpin", "A small metal hairpin that could be fashioned into a lockpick", dungeon, smallHallway, "You bend the metal in a way and tinker with the lock for sometime before you hear a click, you quickly bolt out of your cell. You see hundreds of gaunt faces watching you from other cells as you sprint towards the stairs leading up. You grab the handle to the door out of the dungeon and luckily it is unlocked, you open the door and step through.");
            Item yellowKey = new Item("Yellow-Key", "A large key that gives off a nearly blinding yellow glow", crypt, bedChamber, "You start to move the shining yellow key towards the door. The key starts to become hotter and hotter as you move it towards the door, there is a flash of light that temporarily blinds you.\nWhen your vision returns you notice that the door has completely dissapeared leaving just a moldy doorway.\nAs you step through the doorway the wall seems to come alive and closes the doorway in stone behind you, as if there never was a door.");
            Item bloodKey = new Item("Blood-Key", "A large key that drips an endless supply of a red liquid that can only be blood. The blood seems to fade into nothing when hitting the ground. What sort of magic is this?", bedChamber, puzzleRoomThree, "You insert the key into the bloody door and then take a step back as the door liquifies and washes over the interior of the room, you use your blood soaked feet to step into the next room" );
            Item gateKey = new Item("Gate-Key", "A large key ordained with all manner of jewels", puzzleRoomThree, outside, "You fit the key into the large gate and the door is unlocked, you carefully open the door to see a drawbridge leading over an empty moat. You sprint through and make your escape from this wicked place.");
            // Item sword = new Item("Sword", "A large, thin, jagged blade made of crystal is held by a grip wrapped in elegant, dark brown sting ray leather. With a single, sharp edge this weapon is the perfect choice for slicing and dicing", 20.0);
            #endregion

            #region Add Items to Rooms
            dungeon.Items.Add(hairpin);
            // bedChamber.Items.Add(sword);
            #endregion

            #region Room Exits
            smallHallway.Exits.Add("west", puzzleRoomOne);
            smallHallway.Exits.Add("south", crypt);
            puzzleRoomOne.Exits.Add("east", smallHallway);
            crypt.Exits.Add("north", smallHallway);
            bedChamber.Exits.Add("north", puzzleRoomTwo);
            puzzleRoomTwo.Exits.Add("south", bedChamber);
            puzzleRoomThree.Exits.Add("west", bedChamber);

            #endregion
            
            #region Riddles
            Riddle riddleOne = new Riddle("\"Feed me and I will live, give me a drink and I will die.\"", "\"What is not alive but grows, does not breaths but needs air.\"", "fire", "As soon as you finish uttering the words, the strange lizard morphs into a common lizard and scurries away, a glowing yellow key falls onto the ground and you add it to your inventory", yellowKey, false);
            Riddle riddleTwo = new Riddle("\"What has hands but no arms and a face but no eyes?\"", "\"Without fingers, I point, without arms, I strike, without feet, I run.\"", "clock", "As you shout the answer a bloody key falls from the ceiling, you scramble to catch it and add it to your inventory.", bloodKey, false);
            Riddle riddleThree = new Riddle("\"What word in the English language does the following: the first two letters signify a male, the first three letters signify a female, the first four letters signify a great, while the entire world signifies a great woman. What is the word?\"", "\"What word in the English language does the following: the first two letters signify a male, the first three letters signify a female, the first four letters signify a great, while the entire world signifies a great woman. What is the word?\"", "heroine", "You got the Gate Key!!", gateKey, false);
            #endregion

            #region Adding Riddles to Rooms
            puzzleRoomOne.Riddle = riddleOne;
            puzzleRoomTwo.Riddle = riddleTwo;
            puzzleRoomThree.Riddle = riddleThree;
            #endregion

            CurrentRoom = dungeon;
        }

        //Restarts the game 
        public void Reset()
        {

        }

        //Setup and Starts the Game loop
        public void StartGame()
        {
            Console.Clear();
            Console.WriteLine(@"                                                       )                                   ");
            Console.WriteLine(@"                              (                     ( /(       (                      (     ");
            Console.WriteLine(@" (             )         (    )\ ) (          )     )\()) (    )\ ) (  (              )\ )  ");
            Console.WriteLine(@" )\  (   (  ( /( `  )   ))\  (()/( )(   (    (     ((_)\  )(  (()/( )\))(   (    (   (()/(  ");
            Console.WriteLine(@"((_) )\  )\ )(_))/(/(  /((_)  /(_)|()\  )\   )\  '   ((_)(()\  ((_)|(_)()\  )\   )\   ((_)) ");
            Console.WriteLine(@"| __((_)((_|(_)_((_)_\(_))   (_) _|((_)((_)_((_))   / _ \ ((_) _| |_(()((_)((_) ((_)  _| |  ");
            Console.WriteLine(@"| _|(_-< _|/ _` | '_ \) -_)   |  _| '_/ _ \ '  \() | (_) | '_/ _` |\ V  V / _ \/ _ \/ _` |  ");
            Console.WriteLine(@"|___/__|__|\__,_| .__/\___|   |_| |_| \___/_|_|_|   \___/|_| \__,_| \_/\_/\___/\___/\__,_|  ");
            Console.WriteLine(@"                |_|                                                                         ");
            Console.WriteLine();
            Console.WriteLine("Welcome to the darkest and most unforgiving place in all of Calridia, the Dungeon of Orwood");
            Thread.Sleep(5000);
            Console.Clear();
            Console.WriteLine("What shall I call you?");
            string input = Console.ReadLine();
            CurrentPlayer = new Player(input);
            Console.Clear();
            Console.WriteLine($"Hello {CurrentPlayer.PlayerName} and I wish you the best of luck");
            Console.WriteLine();
            Help();
            GetUserInput();
        }

        //Gets the user input and calls the appropriate command
        public void GetUserInput()
        {
            while (running)
            {   

                if (CurrentRoom.Name == "Outside")
                {

                    Console.Clear();
                    Console.WriteLine("██╗░░░██╗░█████╗░██╗░░░██╗  ░██╗░░░░░░░██╗██╗███╗░░██╗");
                    Console.WriteLine("╚██╗░██╔╝██╔══██╗██║░░░██║  ░██║░░██╗░░██║██║████╗░██║");
                    Console.WriteLine("░╚████╔╝░██║░░██║██║░░░██║  ░╚██╗████╗██╔╝██║██╔██╗██║");
                    Console.WriteLine("░░╚██╔╝░░██║░░██║██║░░░██║  ░░████╔═████║░██║██║╚████║");
                    Console.WriteLine("░░░██║░░░╚█████╔╝╚██████╔╝  ░░╚██╔╝░╚██╔╝░██║██║░╚███║");
                    Console.WriteLine("░░░╚═╝░░░░╚════╝░░╚═════╝░  ░░░╚═╝░░░╚═╝░░╚═╝╚═╝░░╚══╝");
                    Console.WriteLine();
                    Console.WriteLine("Press any key to exit the game");
                    Console.ReadKey();
                    Environment.Exit(0);

                }

                Look();
                Console.WriteLine();
                Console.WriteLine("What do you do? ");
                var input = Console.ReadLine().ToLower();
                string[] inputs = input.Split(" ");
                string option = "";
                if (inputs.Length > 1)
                {
                    option = inputs[1];
                    input = inputs[0];
                }

                switch (input)
                {
                    case "help" :
                        Help();
                        break;
                    case "quit" :
                        Quit();
                        break;
                    case "inventory" :
                        Inventory();
                        break;
                    case "go" :
                        Go(option);
                        break;
                    case "take" :
                        TakeItem(option);
                        break;
                    case "use" :
                        UseItem(option);
                        break;
                    case "look" :
                        Look();
                        break;
                    default :
                        Console.WriteLine("You did not enter a valid command (please check your spelling)");
                        Thread.Sleep(2000);
                        break;
                }
            }


        }

        #region Console Commands

        //Stops the application
        public void Quit()
        {
            Console.Clear();
            Console.WriteLine("Are you sure you would like to quit? (y/n)");
            var input = Console.ReadLine().ToLower();
            if (input == "y")
            {
                running = false;
                Environment.Exit(0);
            }
            else if (input != "y" && input != "n") 
            {
                Console.WriteLine("Invalid entry, please enter either y or n");
                Quit();
            }
        }

        //Should display a list of commands to the console
        public void Help()
        {
            Console.WriteLine(".-------------------------------------Please find the list of Commands available to you below-----------------------------------------------.");
            Console.WriteLine("|-------------------------------------------------------------------------------------------------------------------------------------------|");
            Console.WriteLine("| Go <direction>  .......................... attempt to traverse through an exit in the specified direction of north, south, east, or west  |");
            Console.WriteLine("| Use <ItemName>  .......................... Use the specified item in your inventory                                                       |");
            Console.WriteLine("| Take <ItemName> .......................... Attempt to take an item from the room and place it in your inventory                           |");
            Console.WriteLine("| Look            .......................... Displays the description of the room again                                                     |");
            Console.WriteLine("| Inventory       .......................... Displays your current Inventory                                                                |");
            Console.WriteLine("| Help            .......................... Displays this list of available commands and actions                                           |");
            Console.WriteLine("| Quit            .......................... Ends your current game                                                                         |");
            Console.WriteLine("`-------------------------------------------------------------------------------------------------------------------------------------------`");
            Console.WriteLine("Press any Key to Continue");
            Console.ReadKey();
        }

        //Validate CurrentRoom.Exits contains the desired direction
        //if it does change the CurrentRoom
        public void Go(string direction)
        {
            if (CurrentRoom.Exits.ContainsKey(direction))
            {
                Console.WriteLine($"You are able to safely make it through the door and into {CurrentRoom.Exits[direction].Name}");
                CurrentRoom = (Room)CurrentRoom.Exits[direction];
                Console.WriteLine("Press any Key to Continue");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine($"You were unable to find a way out of {CurrentRoom.Name} in this direction");
                Console.WriteLine("Press any Key to Continue");
                Console.ReadKey();
            }
        }

        //When taking an item be sure the item is in the current room 
        //before adding it to the player inventory, Also don't forget to 
        //remove the item from the room it was picked up in
        public void TakeItem(string itemName)
        {
            Item item = (Item)CurrentRoom.Items.Find(i => i.Name.ToLower() == itemName);

            if (item != null)
            {
                Console.WriteLine($"You succesfully added the {itemName} to your inventory");
                CurrentPlayer.Inventory.Add(item);
                CurrentRoom.Items.Remove(item);
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("You were not able to take the item from this room or it doesnt exist ");
                Console.WriteLine();
                Console.WriteLine("Press any Key to Continue");
                Console.ReadKey();
            }
        }

        //No need to Pass a room since Items can only be used in the CurrentRoom
        //Make sure you validate the item is in the room or player inventory before
        //being able to use the item
        public void UseItem(string itemName)
        {   
            Item item = (Item)CurrentPlayer.Inventory.Find(i => i.Name.ToLower() == itemName);

            if (item != null && CurrentRoom.Name == item.RoomEvent.Name)
            {
                Console.WriteLine();
                Console.WriteLine(item.RoomEventDescription);
                Console.WriteLine();
                Console.WriteLine("Press any key to continue");
                Console.ReadKey();
                CurrentPlayer.Inventory.Remove(item);
                CurrentRoom = item.RoomUnlocked;
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("You do not have this item (or check your spelling)");
                Console.WriteLine();
                Console.WriteLine("Press any key to continue");
                Console.ReadKey();
            }
        }

        //Print the list of items in the players inventory to the console
        public void Inventory()
        {
            if (CurrentPlayer.Inventory.Count > 0)
            {
                Console.Clear();
                foreach (var item in CurrentPlayer.Inventory)
                {
                    Console.WriteLine($"{item.Name}\t\t{item.Description}");
                }
                Console.WriteLine();
                Console.WriteLine("Press any key to continue");
                Console.ReadKey();
            }
            else
            {   
                Console.Clear();
                Console.WriteLine("You currently do not have any items");
                Console.WriteLine("Press any key to continue");
                Console.ReadKey();
            }
        }

        //Display the CurrentRoom Description, Exits, and Items
        public void Look()
        {
                bool isRiddleSolved = true;

                if (CurrentRoom.Riddle != null)
                {
                    isRiddleSolved = CurrentRoom.Riddle.IsCompleted;
                }

                CurrentRoom.Print(CurrentRoom.Items.Count == 0, isRiddleSolved);
                if (CurrentRoom.Riddle != null)
                {
                    if (!CurrentRoom.Riddle.IsCompleted)
                    {   
                        Riddles();
                    }
                    
                }
        }
        // A method to handle the riddle rooms and rewards
        public void Riddles()
        {
            bool isSolved = false;
            bool firstClue = true;
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
            Console.Clear();

            while (!isSolved)
            {   
                if (firstClue)
                {
                    Console.WriteLine(CurrentRoom.Riddle.FirstClue);
                }
                else
                {
                    Console.WriteLine(CurrentRoom.Riddle.SecondClue);
                }
                Console.WriteLine();
                Console.WriteLine("Please enter your answer (or type clue to view the other clue): ");
                String input = Console.ReadLine();
                if (input.ToLower() == CurrentRoom.Riddle.Answer.ToLower())
                {
                    Console.WriteLine();
                    Console.WriteLine(CurrentRoom.Riddle.CorrectAnswerEventText);
                    isSolved = true;
                }
                else if (input.ToLower() == "clue")
                {
                    firstClue = !firstClue;
                    Console.Clear();
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("I am sorry but that is incorrect, please try again");
                    Thread.Sleep(1000);
                    Console.Clear();
                }
            }

            CurrentRoom.Riddle.IsCompleted = true;
            CurrentPlayer.Inventory.Add(CurrentRoom.Riddle.Reward);

        }

        #endregion
    }
}