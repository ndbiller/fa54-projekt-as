using System.Collections.Generic;
using System.Linq;
using TeamManager.Database;
using TeamManager.Models.ResourceData;
using TeamManager.Models.Strategy;

namespace TeamManager.Models.Logic
{
    /// <summary>
    /// For more information refer to the comment in <see cref="IBusinessLogic"/> interface.
    /// </summary>
    public class BusinessLogic : BusinessLogicBase, IBusinessLogic
    {
        public BusinessLogic(DatabaseType dbType, SortType sortType) : base(dbType, sortType) { }


        public bool AddNewPlayer(string playerName)
        {
            return DbLayer.CreatePlayer(playerName, "0");
        }

        public bool AddNewPlayer(string playerName, string teamId)
        {
            return DbLayer.CreatePlayer(playerName, teamId);
        }

        public Team GetPlayerTeam(string teamId)
        {
            return DbLayer.ReadTeam(teamId);
        }

        public bool AddNewTeam(string teamName)
        {
            return DbLayer.CreateTeam(teamName);
        }

        public bool ChangePlayerName(string playerId, string playerNewName)
        {
            return DbLayer.UpdatePlayer(playerId, playerNewName);
        }

        public bool ChangeTeamName(string teamId, string teamNewName)
        {
            return DbLayer.UpdateTeam(teamId, teamNewName);
        }

        public List<Player> GetAllPlayers()
        {
            List<Player> players = DbLayer.Players();
            return SortStrategy.Sort(players);
        }

        public List<Player> GetAllPlayers(string filterText, bool ignoreCase)
        {
            return GetAllPlayers()?
                .Where(
                    p => p.Name.ToLower().Contains(ignoreCase ? filterText.ToLower() : filterText)
                ).ToList();
        }

        public List<Team> GetAllTeams()
        {
            IEnumerable<Team> teams = DbLayer.Teams()?.Where(t => t.Id != "0");
            return SortStrategy.Sort(teams);
        }

        public List<Team> GetAllTeams(string filterText, bool ignoreCase)
        {
            return GetAllTeams()?
                .Where(t =>
                    t.Name.ToLower().Contains(ignoreCase ? filterText.ToLower() : filterText)
                ).ToList();
        }

        public List<Player> GetTeamPlayers(string teamId)
        {
            List<Player> teamPlayers = DbLayer.ShowPlayers(teamId);
            return SortStrategy.Sort(teamPlayers);
        }

        public List<Player> GetTeamPlayers(string teamId, string filterText, bool ignoreCase)
        {
            return GetTeamPlayers(teamId)?
                .Where(
                    t => t.Name.ToLower().Contains(ignoreCase ? filterText.ToLower() : filterText)
                ).ToList();
        }

        public bool RemovePlayer(string playerId)
        {
            return DbLayer.DeletePlayer(playerId);
        }

        public bool RemoveTeam(string teamId)
        {
            return DbLayer.DeleteTeam(teamId);
        }

        public bool ChangePlayerTeam(string playerId, string teamId)
        {
            return DbLayer.ChangePlayerTeam(playerId, teamId);
        }
    }
}
