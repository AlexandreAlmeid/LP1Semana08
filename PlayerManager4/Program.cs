using System;
using System.Collections.Generic;

namespace PlayerManager4 // >>> Change to PlayerManager2 for exercise 4 <<< //
{
    /// <summary>
    /// The player listing program.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// The list of all players.
        /// </summary>
        private List<Player> playerList;

        /// <summary>
        /// Program begins here.
        /// </summary>
        private static void Main()
        {
            // Create a new instance of the player listing program
            Program prog = new Program();
            // Start the program instance
            prog.Start();
        }

        /// <summary>
        /// Creates a new instance of the player listing program.
        /// </summary>
        private Program()
        {
            // Initialize the player list with two players using collection
            // initialization syntax
            playerList = new List<Player>() {
                new Player("Best player ever", 100),
                new Player("An even better player", 500)
            };
        }

        /// <summary>
        /// Start the player listing program instance
        /// </summary>
        private void Start()
        {
            // We keep the user's option here
            string option;

            Console.WriteLine("Order");
            Console.WriteLine("1 - By Score.");
            Console.WriteLine("2 - By Name (Ascend).");
            Console.WriteLine("3 - By Name (Descend).");
            string opt = Console.ReadLine();
            int op = int.Parse(opt);
            // Main program loop
            do
            {
                // Show menu and get user option
                ShowMenu();
                option = Console.ReadLine();
                Console.Write("\n\n");

                switch (op)
                {
                    case 1:
                        playerList.Sort();
                        break;
                    case 2:
                        IComparer<Player> comp1 = new CompareByName(true);
                        playerList.Sort(comp1);
                        break;
                    case 3:
                        IComparer<Player> comp2 = new CompareByName(false);
                        playerList.Sort(comp2);
                        break;
                    default:
                        break;

                }

                // Determine the option specified by the user and act on it
                switch (option)
                {
                    case "1":
                        InsertPlayer();
                        break;
                    case "2":
                        ListPlayers(playerList);
                        break;
                    case "3":
                        ListPlayersWithScoreGreaterThan();
                        break;
                    case "4":
                        Console.WriteLine("Bye!");
                        break;
                    default:
                        Console.Error.WriteLine("\n>>> Unknown option! <<<\n");
                        break;
                }

                // Wait for user to press a key...
                Console.Write("\nPress enter to continue...");
                Console.ReadLine();
                Console.WriteLine("\n");

                // Loop keeps going until players choses to quit (option 4)
            } while (option != "4");
        }

        /// <summary>
        /// Shows the main menu.
        /// </summary>
        private void ShowMenu()
        {
            Console.WriteLine("Menu");
            Console.WriteLine("1 - Insert new player in players list.");
            Console.WriteLine("2 - List all the players.");
            Console.WriteLine("3 - List players with a score greater than a minimum value.");
            Console.WriteLine("4 - Exit program.");
        }

        /// <summary>
        /// Inserts a new player in the player list.
        /// </summary>
        private void InsertPlayer()
        {
            Console.Write("Player Name: ");
            string name = Console.ReadLine();
            Console.Write("Player Score: ");
            string score = Console.ReadLine();
            int scr = int.Parse(score);
            playerList.Add(new Player(name,scr));
        }

        /// <summary>
        /// Show all players in a list of players. This method can be static
        /// because it doesn't depend on anything associated with an instance
        /// of the program. Namely, the list of players is given as a parameter
        /// to this method.
        /// </summary>
        /// <param name="playersToList">
        /// An enumerable object of players to show.
        /// </param>
        private static void ListPlayers(IEnumerable<Player> playersToList)
        {
            foreach (Player player in playersToList)
            {
                Console.WriteLine($"Player Name: {player.Name} | Score: {player.Score}");
            }
        }

        /// <summary>
        /// Show all players with a score higher than a user-specified value.
        /// </summary>
        private void ListPlayersWithScoreGreaterThan()
        {
            Console.Write("Minimum Score: ");
            string score = Console.ReadLine();
            int scr = int.Parse(score);
            foreach (Player p in GetPlayersWithScoreGreaterThan(scr))
            {
                Console.WriteLine($"Player Name: {p.Name} | Score: {p.Score}");
            }
            
        }

        /// <summary>
        /// Get players with a score higher than a given value.
        /// </summary>
        /// <param name="minScore">Minimum score players should have.</param>
        /// <returns>
        /// An enumerable of players with a score higher than the given value.
        /// </returns>
        private IEnumerable<Player> GetPlayersWithScoreGreaterThan(int minScore)
        {
            foreach (Player player in playerList)
            {
                if (player.Score > minScore)
                {
                    yield return player;
                }
            }
        }
    }
}
