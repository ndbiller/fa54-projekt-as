using System;
using System.Collections.Generic;
using System.Linq;
using TeamManager.Models.ResourceData;

namespace TeamManager.Presenters
{
    /// <summary>
    /// The console presenter will be used differently in comparsion to UI presenters.
    /// In here we will implement methods without a view coupling, that the console 
    /// will be using directly in order to try sticking to the MVP pattern.
    /// </summary>
    public class ConsolePresenter : BasePresenter
    {
        public List<Team> AllTeams()
        {
            List<Team> teams = concept.GetAllTeams();
            if (teams.Count == 0)
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

        public List<Player> AllPlayers()
        {
            List<Player> players = concept.GetAllPlayers();
            for (int i = 0; i < players.Count; i++)
            {
                Player player = players[i];
                Console.WriteLine($"[{i + 1,3}] - {player.Name}");
            }

            return players;
        }

        public void CreateNewTeam()
        {
            Console.WriteLine("\nEnter the name of the new Team:");
            Console.Write("Team Name: ");
            string teamName = Console.ReadLine();
            if (!string.IsNullOrEmpty(teamName) && concept.AddNewTeam(teamName))
                Console.WriteLine($"Successfully created \"{teamName}\" as a new team!");
            else
                Console.WriteLine($"Failed to create \"{teamName}\" as a new team...");
        }

        public void CreateNewPlayer()
        {
            Console.WriteLine("\nEnter the name of the new player:");
            Console.Write("Player Name: ");
            string playerName = Console.ReadLine();
            if (!string.IsNullOrEmpty(playerName) && concept.AddNewPlayer(playerName))
                Console.WriteLine($"Successfully created \"{playerName}\" as a new player!");
            else
                Console.WriteLine($"Failed to create \"{playerName}\" as a new player...");
        }

        public void EditTeam()
        {
            Console.WriteLine("\nSelect Team by using the index number:");
            List<Team> teams = AllTeams();
            if (teams.Count == 0) return;

            int teamIndex = GetUserInput();
            if (teamIndex <= 0)
            {
                InvalidInput();
                return;
            }

            Team team = teams[--teamIndex];
            Console.Write("Team New Name: ");
            string newName = Console.ReadLine();

            if (!string.IsNullOrEmpty(newName) && concept.ChangeTeamName(team.Id, newName))
                Console.WriteLine($"Successfully changed team name from \"{team.Name}\" to \"{newName}\"!");
            else
                Console.WriteLine("Failed to change team name...");
        }

        public void EditPlayer()
        {
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
                if (!string.IsNullOrEmpty(playerNewName) && concept.ChangePlayerName(player.Id, playerNewName))
                    Console.WriteLine($"Successfully changed player name from \"{player.Name}\" to \"{playerNewName}\"!");
                else
                    Console.WriteLine("Failed to change player name...");
            }
            else // Edit Team
            {
                Console.WriteLine("Select the team by the index that you would like to assign the player to: ");
                List<Team> teams = AllTeams();
                if (teams.Count == 0) return;

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
                if (concept.ChangePlayerTeam(player.Id, team.Id))
                    Console.WriteLine($"Successfully changed player team from \"{playerTeamName}\" to \"{team.Name}\"!");
                else
                    Console.WriteLine("Failed to change player team...");
            }

        }

        public void DeleteTeam()
        {
            Console.WriteLine("\nSelect a team by using the index number:");
            List<Team> teams = AllTeams();
            if (teams.Count == 0) return;

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
            List<Player> players = concept.GetAllPlayers();
            foreach (Player player in players)
                if (player.TeamId == team.Id)
                    concept.ChangePlayerTeam(player.Id, "0");

            if (concept.RemoveTeam(team.Id))
                Console.WriteLine($"Successfully removed {team.Name} from teams!");
            else
                Console.WriteLine($"Failed to remove {team.Name} from teams...");
        }

        public void DeletePlayer()
        {
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

            if (concept.RemovePlayer(player.Id))
                Console.WriteLine($"Successfully removed {player.Name} from players!");
            else
                Console.WriteLine($"Failed to remove {player.Name} from players...");
        }

        public void ShowUnsignedPlayers()
        {
            List<Player> unsignedPlayers = concept.GetAllPlayers().Where(p => p.TeamId == "0").ToList();
            for (int i = 0; i < unsignedPlayers.Count; i++)
            {
                Player player = unsignedPlayers[i];
                Console.WriteLine($"[{i + 1,3}] - {player.Name}");
            }
        }

        public void ShowTeamPlayers()
        {
            Console.WriteLine("\nSelect a team to show players by using the index number:");
            List<Team> teams = AllTeams();
            if (teams.Count == 0) return;

            int teamIndex = GetUserInput();
            if (teamIndex <= 0)
            {
                InvalidInput();
                return;
            }

            Team team = teams[--teamIndex];

            List<Player> players = concept.GetTeamPlayers(team.Id);
            Console.WriteLine($"\n-- Team Players of \"{team.Name}\" --");
            if (players.Count == 0)
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

        public void Close()
        {
            if (ValidateUserInput("Are you sure you want to exit? (Y/N)"))
                Environment.Exit(0);
        }

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

        private static int GetUserInput()
        {
            Console.Write("\nInput: ");
            int input;
            int.TryParse(Console.ReadLine(), out input);
            Console.WriteLine(Environment.NewLine);
            return input;
        }

        private static bool ValidateUserInput(string message)
        {
            string answer;
            do
            {
                Console.WriteLine(message);
                Console.Write("Input: ");
                answer = Console.ReadLine()?.ToLower();
                if (answer != null && answer.StartsWith("n")) return false;
            } while (answer != null && !answer.StartsWith("y"));

            return true;
        }

        private static void InvalidInput()
        {
            Console.WriteLine("Invalid input. Please try again...");
        }

        public override void FormClosed()
        {
            // Console should do nothing
        }

    }
}
