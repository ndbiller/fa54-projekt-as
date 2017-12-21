using System;
using System.Collections.Generic;
using System.Linq;
using log4net;
using TeamManager.Models.ResourceData;
using TeamManager.Utilities;
using TeamManager.Views.Interfaces;

namespace TeamManager.Presenters
{
    /// <summary>
    /// The <see cref="ConsolePresenter"/> will be used differently in comparsion to other presenters.
    /// In here it's not neccessary to expose properties by the interface as it shares the same window. 
    /// the console will be using to output info directly as it's not depends on the gui.
    /// </summary>
    public class ConsolePresenter : BasePresenter
    {
        /// <summary> The view interface of the <see cref="Views.Windows.MainTui"/> which used to update the ui. </summary>
        private readonly IConsoleView _view;

        /// <summary> Logger instance of the class <see cref="ConsolePresenter"/>. </summary>
        private static readonly ILog Log = Logger.GetLogger();




        /// <summary> 
        /// The <see cref="ConsolePresenter"/> constructor will receive the <see cref="IConsoleView"/> interface from the 
        /// <see cref="Views.Windows.MainTui"/> and couple together with the view.
        /// </summary>
        /// <param name="view"></param>
        public ConsolePresenter(IConsoleView view)
        {
            _view = view;
        }



        /// <summary>
        /// Gets a collection of <see cref="Team"/>s from the <see cref="Models.TechnicalConcept.ITechnicalConcept"/> 
        /// and displays them to the view when the teams collection not empty.
        /// </summary>
        /// <returns><see cref="List&lt;Team&gt;"/></returns>
        public List<Team> AllTeams()
        {
            Log.Info("Displaying all teams to console.");
            List<Team> teams = Concept.GetAllTeams();
            if (teams.IsNullOrEmpty())
            {
                Console.WriteLine("Currently there is no teams to display.\n" +
                                  "If you would like to add new team, use the create team option.");
                return null;
            }
            for (int i = 0; i < teams.Count; i++)
            {
                Team team = teams[i];
                Console.WriteLine($"[{i + 1,3}] - {team.Name}");
            }

            return teams;
        }

        /// <summary>
        /// Gets a collection of <see cref="Player"/>s from the <see cref="Models.TechnicalConcept.ITechnicalConcept"/> 
        /// and displays them to the view when the players collection not empty.
        /// </summary>
        /// <returns><see cref="List&lt;Player&gt;"/></returns>
        public List<Player> AllPlayers()
        {
            Log.Info("Displaying all players to console.");
            List<Player> players = Concept.GetAllPlayers();
            for (int i = 0; i < players.Count; i++)
            {
                Player player = players[i];
                Console.WriteLine($"[{i + 1,3}] - {player.Name}");
            }

            return players;
        }

        /// <summary>
        /// Creates a new <see cref="Team"/> with the giving team name.
        /// </summary>
        public void CreateNewTeam()
        {
            Log.Info("Creating new team.");
            Console.WriteLine("\nEnter the name of the new Team:");
            Console.Write("Team Name: ");
            string teamName = Console.ReadLine();
            if (!string.IsNullOrEmpty(teamName) && Concept.AddNewTeam(teamName))
                Console.WriteLine($"Successfully created \"{teamName}\" as a new team!");
            else
                Console.WriteLine($"Failed to create \"{teamName}\" as a new team...");
        }

        /// Creates a new <see cref="Player"/> with the giving player name.
        public void CreateNewPlayer()
        {
            Log.Info("Creating new player.");
            Console.WriteLine("\nEnter the name of the new player:");
            Console.Write("Player Name: ");
            string playerName = Console.ReadLine();
            if (!string.IsNullOrEmpty(playerName) && Concept.AddNewPlayer(playerName))
                Console.WriteLine($"Successfully created \"{playerName}\" as a new player!");
            else
                Console.WriteLine($"Failed to create \"{playerName}\" as a new player...");
        }

        /// <summary>
        /// Edits the <see cref="Team.Name"/> of the selected <see cref="Team"/> index.
        /// </summary>
        public void EditTeam()
        {
            Log.Info("Editing Team.");
            Console.WriteLine("\nSelect Team by using the index number:");
            List<Team> teams = AllTeams();
            if (teams.IsNullOrEmpty()) return;

            int teamIndex = GetUserInput();
            if (teamIndex <= 0)
            {
                InvalidInput();
                return;
            }

            Team team = teams[--teamIndex];
            Console.Write("Team New Name: ");
            string newName = Console.ReadLine();

            if (!string.IsNullOrEmpty(newName) && Concept.ChangeTeamName(team.Id, newName))
                Console.WriteLine($"Successfully changed team name from \"{team.Name}\" to \"{newName}\"!");
            else
                Console.WriteLine("Failed to change team name...");
        }

        /// <summary>
        /// Edits the <see cref="Player.Name"/> or <see cref="Player.TeamId"/> of the selected <see cref="Player"/> index.
        /// </summary>
        public void EditPlayer()
        {
            Log.Info("Editing player.");
            Console.WriteLine("\nSelect a player by using the index number:");
            List<Player> players = AllPlayers();
            int playerIndex = GetUserInput();
            if (playerIndex <= 0)
            {
                InvalidInput();
                return;
            }

            Player player = players[--playerIndex];

            Console.WriteLine("What would you like to edit?");
            Console.WriteLine("\t[1] - Name");
            Console.WriteLine("\t[2] - Change Team");
            int inputIndex = GetUserInput();
            if (inputIndex != 1 && inputIndex != 2)
            {
                InvalidInput();
                return;
            }

            if (inputIndex == 1) // Edit Name
            {
                Console.WriteLine("Write the new name for the selected player: ");
                Console.Write("Player New Name: ");
                string playerNewName = Console.ReadLine();
                if (!string.IsNullOrEmpty(playerNewName) && Concept.ChangePlayerName(player.Id, playerNewName))
                    Console.WriteLine($"Successfully changed player name from \"{player.Name}\" to \"{playerNewName}\"!");
                else
                    Console.WriteLine("Failed to change player name...");
            }
            else // Edit Team
            {
                Console.WriteLine("Select the team by the index that you would like to assign the player to: ");
                List<Team> teams = AllTeams();
                if (teams.IsNullOrEmpty()) return;

                string playerTeamName = teams.Find(t => t.Id == player.TeamId)?.Name;
                if (string.IsNullOrEmpty(playerTeamName)) playerTeamName = "Unsigned Team";

                Console.WriteLine($"Current Player Team: \"{playerTeamName}\"");
                int teamIndex = GetUserInput();
                if (teamIndex <= 0)
                {
                    InvalidInput();
                    return;
                }

                Team team = teams[--teamIndex];
                Console.WriteLine(Concept.ChangePlayerTeam(player.Id, team.Id)
                    ? $"Successfully changed player team from \"{playerTeamName}\" to \"{team.Name}\"!"
                    : "Failed to change player team...");
            }

        }

        /// <summary>
        /// Deletes the selected <see cref="Team"/> and move all their <see cref="Player"/>s to unsigned team(id = 0).
        /// </summary>
        public void DeleteTeam()
        {
            Log.Info("Deleting team.");
            Console.WriteLine("\nSelect a team by using the index number:");
            List<Team> teams = AllTeams();
            if (teams.IsNullOrEmpty()) return;

            int teamIndex = GetUserInput();
            if (teamIndex <= 0)
            {
                InvalidInput();
                return;
            }

            Team team = teams[--teamIndex];

            if (!ValidateUserInput($"Are you sure you want to delete {team.Name} from teams? (Y/N)"))
                return;

            // Set all players team id to 0 that contains the team id before we removing team.
            List<Player> players = Concept.GetAllPlayers();
            foreach (Player player in players)
                if (player.TeamId == team.Id)
                    Concept.ChangePlayerTeam(player.Id, "0");

            Console.WriteLine(Concept.RemoveTeam(team.Id)
                ? $"Successfully removed {team.Name} from teams!"
                : $"Failed to remove {team.Name} from teams...");
        }

        /// Deletes the selected <see cref="Player"/>.
        public void DeletePlayer()
        {
            Log.Info("Deleting player.");
            Console.WriteLine("\nSelect a player by using the index number:");
            List<Player> players = AllPlayers();
            int playerIndex = GetUserInput();
            if (playerIndex <= 0)
            {
                InvalidInput();
                return;
            }

            Player player = players[--playerIndex];

            if (!ValidateUserInput($"Are you sure you want to delete {player.Name} from players? (Y/N)"))
                return;

            Console.WriteLine(Concept.RemovePlayer(player.Id)
                ? $"Successfully removed {player.Name} from players!"
                : $"Failed to remove {player.Name} from players...");
        }

        /// <summary>
        /// Displays all the <see cref="Player"/>s that are not assign to a <see cref="Team"/>.
        /// </summary>
        public void ShowUnsignedPlayers()
        {
            Log.Info("Displaying all unsigned players.");
            List<Player> unsignedPlayers = Concept.GetAllPlayers().Where(p => p.TeamId == "0").ToList();
            for (int i = 0; i < unsignedPlayers.Count; i++)
            {
                Player player = unsignedPlayers[i];
                Console.WriteLine($"[{i + 1,3}] - {player.Name}");
            }
        }

        /// <summary>
        /// Displays all the <see cref="Player"/>s of the selected <see cref="Team"/>.
        /// </summary>
        public void ShowTeamPlayers()
        {
            Log.Info("Displaying all players of a team.");
            Console.WriteLine("\nSelect a team to show players by using the index number:");
            List<Team> teams = AllTeams();
            if (teams.IsNullOrEmpty()) return;

            int teamIndex = GetUserInput();
            if (teamIndex <= 0)
            {
                InvalidInput();
                return;
            }

            Team team = teams[--teamIndex];

            List<Player> players = Concept.GetTeamPlayers(team.Id);
            Console.WriteLine($"\n-- Team Players of \"{team.Name}\" --");
            if (players.IsNullOrEmpty())
            {
                Console.WriteLine("Unfortunately no team players for this team.\n" +
                                  "You can always assign players to teams by the edit player option.");
                return;
            }

            for (int i = 0; i < players.Count; i++)
            {
                Player player = players[i];
                Console.WriteLine($"[{i + 1,3}] - {player.Name}");
            }
        }

        /// <summary>
        /// Validate user input before closing the tui.
        /// </summary>
        public void Close()
        {
            if (ValidateUserInput("Are you sure you want to exit? (Y/N)"))
                Environment.Exit(0);
        }

        /// <summary>
        /// Displays the menu to the view.
        /// </summary>
        public void PrintMenu()
        {
            Console.Clear();
            Console.WriteLine("         TEAM-MANAGER-SYSTEM            \n" +
                              "========================================\n" +
                              "    Show Teams            \t(a)         \n" +
                              "    New Team              \t(b)         \n" +
                              "    Edit Team             \t(c)         \n" +
                              "    Delete Team           \t(d)         \n" +
                              "========================================\n" +
                              "    Show Players          \t(e)         \n" +
                              "    New Player            \t(f)         \n" +
                              "    Edit Player           \t(g)         \n" +
                              "    Delete Player         \t(h)         \n" +
                              "========================================\n" +
                              "    Show Unsigned Players \t(i)         \n" +
                              "    Show Team Players     \t(j)         \n" +
                              "    Close                 \t(x)         \n");
        }

        /// <summary>
        /// Gets user input.
        /// Mainly used when we want to get the selected index of the displayed options.
        /// </summary>
        /// <returns></returns>
        private int GetUserInput()
        {
            Console.Write("\nInput: ");
            int input;
            int.TryParse(Console.ReadLine(), out input);
            Console.WriteLine(Environment.NewLine);
            return input;
        }

        /// <summary>
        /// Validates user input before proccessing an action whether to continue or not.
        /// </summary>
        /// <param name="message">The question that will display to the user.</param>
        /// <returns><see cref="bool"/></returns>
        private bool ValidateUserInput(string message)
        {
            string answer;
            do
            {
                Console.WriteLine(message);
                Console.Write("Input: ");
                answer = Console.ReadLine()?.ToLower();
                if (answer?.StartsWith("n") == true) return false;
            } while (!answer?.StartsWith("y") == true);

            return true;
        }

        /// <summary>
        /// Displays invalid input to the view.
        /// </summary>
        private void InvalidInput() => Console.WriteLine("Invalid input. Please try again...");

        /// <summary> The <see cref="ConsolePresenter"/> not necessarly needs to invoke. </summary>
        public override void WindowClosed() { }

    }
}
