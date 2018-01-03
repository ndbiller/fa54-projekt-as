using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamManager.Database;
using TeamManager.Models.ResourceData;

namespace TeamManager.Models.Logic
{
    public class BusinessLogicMt : BusinessLogicBase, IBusinessLogic
    {
        public BusinessLogicMt(DatabaseType dbType, SortType sortType) : base(dbType, sortType) { }


        public bool AddNewPlayer(string playerName)
        {
            return DbLayer.CreatePlayerAsync(playerName, "0").Result;
        }

        public bool AddNewPlayer(string playerName, string teamId)
        {
            return DbLayer.CreatePlayerAsync(playerName, teamId).Result;
        }

        public Team GetPlayerTeam(string teamId)
        {
            return DbLayer.ReadTeamAsync(teamId).Result;
        }

        public bool AddNewTeam(string teamName)
        {
            return DbLayer.CreateTeamAsync(teamName).Result;
        }

        public bool ChangePlayerName(string playerId, string playerNewName)
        {
            return DbLayer.UpdatePlayerAsync(playerId, playerNewName).Result;
        }

        public bool ChangeTeamName(string teamId, string teamNewName)
        {
            return DbLayer.UpdateTeamAsync(teamId, teamNewName).Result;
        }

        public List<Player> GetAllPlayers()
        {
            return SortBehaviour.Sort(DbLayer.PlayersAsync().Result);
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
            return SortBehaviour.Sort(DbLayer.TeamsAsync().Result?.Where(t => t.Id != "0"));
        }

        public List<Team> GetAllTeams(string filterText, bool ignoreCase)
        {
            return GetAllTeams()?
                .Where(t => t.Name.ToLower().Contains(ignoreCase ? filterText.ToLower() : filterText)
                ).ToList();
        }

        public List<Player> GetTeamPlayers(string teamId)
        {
            return SortBehaviour.Sort(DbLayer.ShowPlayersAsync(teamId).Result);
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
            return DbLayer.DeletePlayerAsync(playerId).Result;
        }

        public bool RemoveTeam(string teamId)
        {
            return DbLayer.DeleteTeamAsync(teamId).Result;
        }

        public bool ChangePlayerTeam(string playerId, string teamId)
        {
            return DbLayer.ChangePlayerTeamAsync(playerId, teamId).Result;
        }

    }
}
