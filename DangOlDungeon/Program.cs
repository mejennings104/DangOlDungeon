using DungeonLibrary;
using MonsterLibrary;
using System.Media;

namespace DangOlDungeon
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($@" 
                 <<<<<-=-=-= SpaceDungeon =-=-=->>>>>


    .    * .    . *.    * .    . *    .    * .    . *.    * .    . *
       * .  * .  .          |-----------| .  .  * .  .    .  * .  .    * .
                .  *   .  . |===========|  .  * .   . .  *  .   .      . *
           |            ____|,---------.|___--~\__--. * .  .   * .   .  .    * .
    #---,'''''`-_   `  /    |`---------'|    `       \    ,--~~  __-/~~--'_______
       | ~~~~~~~~~|---~---/=| __________|=\---~-----~-----| .--~~  |  .__ |  ____|
     -[|.-- ===|#####|-| |@@@@|+-+@@@| |]=###|/-++++-[| ||||___+_.  | `===='-.
     -[| '==~' |#####|-| |@@@@|+-+@@@| |]=###|\-++++-[| ||||~~~+~'  | ,====.-'
       | _________ | ---u-- -\=| ~~~~~~~~~~~|=/ ---u---- - u---- -| '--__ |'~~||
        \       /= -   `    |,---------.|  .    ` . *`    `--__  ~~-\__--.~~~~~'
--- =:===\     /    .  . *  |`---------'| .     .    .       .  ~~--_/~~--'
     -- <:\___/ --   .      |===========|     *  .   .   *   *  .   .   * 
                  .  .. *   |-----------|   .   .   *     .   .   * 
  *  .   .   *   *  .   .   |___________| * .  .  .   * .   .  .    * .  * .  
         __  .   .   .    *    *    .   .      *    .        *    .    .
 .  .    \ \_____      * .    .     .     .    . *.    * .    . *  .
      ###[==_____>    .        *    .    *       .        *    .    *
         /_/ _   * .    .    .    * .    . .    * .    .    .   *
    .       \ \_____  .    * .    . *.    * .    .     .    * .    . *.    
         ###[==_____>    * .  * .  .   .   .  .   .   .  .     .  * .
 .          /_/    *   *  .   .   *     .   .   *     *  .   . *     . ");
            #region MusicPlayer
            SoundPlayer musicPlayer = new SoundPlayer();
            musicPlayer.SoundLocation = AppDomain.CurrentDomain.BaseDirectory + "spacedungeon.wav";
            musicPlayer.PlayLooping();//will repeat when finished. .Play() plays once and stops.
            #endregion


            int score = 0;
            int invGold = 20;
            

            Weapon sword = new Weapon(8, 1, "Long Sword", 10, false, WeaponType.LaserSword);
            //Weapon gun = new Weapon(6, 4, "Laser Gun", 10, false, WeaponType.LaserGun);

            Console.WriteLine("No one can hear you scream in space.\n\n");

            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("Press 'Enter' to Continue.");
            Console.ResetColor();


            Console.ReadLine();
            Console.Clear();


            Console.WriteLine("\n\nHey, you're finally awake! We need your help! What's your name?\n");
            string userName = Console.ReadLine();

            #region Race Selection
            //customize Race and Name based on user input.
            var races = Enum.GetValues(typeof(Race));
            int index = 1;

            Console.WriteLine("\nWhat alien space race are you?");
            foreach (var race in races)
            {
                Console.WriteLine($"{index}) {race}");
                index++;
            }
            
            //if you have 9 items or less, you can use a Console.ReadKey(). Any more, and you'll need to use a ReadLine().
            int userInput = int.Parse(Console.ReadLine()) - 1;//Subtracting to make it zero-based
            Race userRace = (Race)userInput;
            Console.WriteLine(userRace);

            #endregion

            //var weapons = Enum.GetValues(typeof(WeaponType));
            

            //Console.WriteLine("\n...and what weapon would you like?");
            //foreach (var weapon in weapons)
            //{
            //    Console.WriteLine($"{index}) {weapon}");
            //    index++;
            //}

            //int weaponInput = int.Parse(Console.ReadLine());
            //WeaponType userWeapon = (WeaponType)weaponInput;
            //Console.WriteLine(userWeapon);

            Player player = new Player(userName, 80, 5, 1000, 1000, userRace, sword);

            Console.Clear();

            Console.WriteLine("Well, " + userName + ", to fill you in on the situation, you're a prisoner aboard a space dungeon.\n" +
                "You got knocked out when space monsters started boarding our ship.They took over the flight deck\n" +
                "So you must head there and regain control of the ship. I must warn you, the \n" +
                "enemies only get stronger the closer you get so be sure to visit the\n" +
                "vending machine between fights. Good luck.\n\n");

            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("Press 'Enter' to Continue.");
            Console.ResetColor();

            Console.ReadLine();
            Console.Clear();

            bool exit = false; //bool for outer loop. Exit game when true.
            do
            {
                Console.WriteLine("\nPlease select an option: \n" +
                    "N) Next Room\n" +
                    "V) Vending Machine\n" +
                    "E) Exit\n\n");
                string userChoice1 = Console.ReadKey(true).Key.ToString();
                Console.Clear();

                bool exitMenu = false;
                switch (userChoice1)
                {

                    case "N":
                        do
                        {
                            //generate a room
                            string room = GetRoom();
                            Console.WriteLine(room);

                            Monster monster = Monster.GetMonster(score);
                            Console.WriteLine("\nYou've encountered " + monster.Name + "!");

                            bool reload = false;

                            do
                            {


                                Console.WriteLine("Choose an action: \n" +
                                    "A) Attack \n" +
                                    "R) Run Away\n" +
                                    "M) Monster Info\n" +
                                    "X) Exit\n\n\n\n\n\n " +
                                    "Player Info: \n " +
                                    player + "\n" +
                                    "Monsters Defeated: " + score);
                                string userChoice = Console.ReadKey(true).Key.ToString();
                                Console.Clear();

                                switch (userChoice)
                                {
                                    case "A":
                                        Console.BackgroundColor = ConsoleColor.White;
                                        Console.ForegroundColor = ConsoleColor.Black;
                                        Console.WriteLine("Attack!\n");
                                        Console.ResetColor();

                                        Combat.DoBattle(player, monster);
                                        if (monster.Life <= 0)
                                        {
                                            //Monster is Dead

                                            score++;
                                            invGold += 10;
                                            Console.ForegroundColor = ConsoleColor.Green;
                                            Console.WriteLine("------------------------------------------");
                                            Console.WriteLine($"\nYou killed {monster.Name}!\n" +
                                                $"You got +10 gold!");
                                            Console.WriteLine("------------------------------------------");
                                            Console.ResetColor();

                                            exitMenu = true;
                                        }
                                        if (player.Life <= 0)
                                        {
                                            Console.WriteLine("YOU DIED");
                                            exitMenu = true;
                                            exit = true;
                                        }
                                        if (score == 7)
                                        {
                                            Console.WriteLine("Congratulations! You've defeated all Monsters and saved all the passengers\n" +
                                                "aboard the spaceship!\n\n\n");
                                        
                                            exitMenu = true;
                                            exit = true;
                                        }
                                        break;
                                    case "R":
                                        Console.WriteLine("You ran away!");
                                        Console.WriteLine($"{monster.Name} attacked you as you fleed!");
                                        Combat.DoAttack(monster, player);
                                        reload = true;
                                        break;
                                    case "M":
                                        Console.WriteLine(monster);
                                        break;
                                    case "X":
                                    case "Escape":
                                        Console.WriteLine("Thanks for playing!");
                                        exitMenu = true;
                                        exit = true;
                                        break;
                                    default:
                                        Console.WriteLine("Please try again.");
                                        break;
                                }
                            } while (!exit && !exitMenu &&!reload);
                        } while (!exit && !exitMenu);
                        break;
                    case "V":
                        bool reloadVend = false;
                        do
                        {
                            int v1 = 20;
                            int v2 = 30;
                            int v3 = 40;
                            Console.WriteLine($"What would you like to do?\n" +
                                "1) 20 Gold: Heal +30hp\n" +
                                "2) 30 Gold: Damage increased +10\n" +
                                "3) 40 Gold: Block increased +10\n" +
                                "4) Go Back\n\n" +
                                "You have " + invGold + " Gold\n" +
                                "You have " + player.Life + "Health");


                            string vendChoice = Console.ReadLine();
                            Console.Clear();

                            if (vendChoice == "1" && invGold >= v1)
                            {

                                invGold -= 20;
                                player.Life += 30;
                                Console.WriteLine("You healed yourself");

                                reloadVend = true;
                            }
                            if (vendChoice == "2" && invGold >= v2)
                            {
                                invGold -= 30;

                                sword.MinDamage += 10;
                                sword.MaxDamage += 10;
                                Console.WriteLine("Damage has been increased!");
                            }
                            if (vendChoice == "3" && invGold >= v3)
                            {
                                player.Block += 10;
                                Console.WriteLine("Your block has been increased!");
                            }
                            else if (vendChoice == "4")
                            {
                                reloadVend = true;
                            }
                        } while (!reloadVend);

                        break;
                    case "E":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Please Try again...");
                        break;
                }
            } while (!exit);
            Console.WriteLine("You defeated " + score + " monster" + (score == 1 ? "." : "s."));
            Console.WriteLine("\n\nThanks for playing!\n\n\n\n" +
                "Music and console app created by Matthew Jennings\n\n" +
                "Press any key to exit...");
            Console.ReadKey();

        }

        private static string GetRoom()
        {
            string[] rooms =
            {
                "There's space debris all over this room",
                "You're in the hallway",
                "You're in the space hangar",
                "Why is there blood everywhere?",
                "You found a spacedungeon cell",
                "There's sticky stuff everywhere!"

            };
            return rooms[new Random().Next(rooms.Length)];

        }

    }
}