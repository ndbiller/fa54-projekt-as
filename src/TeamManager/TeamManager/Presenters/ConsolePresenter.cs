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
            for (var i = 0; i < teams.Count; i++)
            {
                Team team = teams[i];
                Console.WriteLine($"[{i + 1,3}] - {team.Name}");
            }

            return teams;
        }

        public List<Player> AllPlayers()
        {
            List<Player> players = concept.GetAllPlayers();
            for (var i = 0; i < players.Count; i++)
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
            throw new NotImplementedException();
        }

        public void EditPlayer()
        {
            throw new NotImplementedException();
        }

        public void DeleteTeam()
        {
            throw new NotImplementedException();
        }

        public void DeletePlayer()
        {
            throw new NotImplementedException();
        }

        public void ShowUnsignedPlayers()
        {
            List<Player> unsignedPlayers = concept.GetAllPlayers().Where(p => p.TeamId == "0").ToList();
            for (var i = 0; i < unsignedPlayers.Count; i++)
            {
                Player player = unsignedPlayers[i];
                Console.WriteLine($"[{i + 1,3}] - {player.Name}");
            }
        }

        public void Close()
        {
            Console.WriteLine("Are you sure you want to exit? (Y/N)");
            Console.Write("Input: ");
            string readLine = Console.ReadLine();
            if (readLine != null && readLine.ToLower().StartsWith("y"))
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
                              "    Close                 \t(j)         \n");
        }
    }
}
