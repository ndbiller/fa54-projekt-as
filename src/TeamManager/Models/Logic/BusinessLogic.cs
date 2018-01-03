using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamManager.Database;
using TeamManager.Models.ResourceData;

namespace TeamManager.Models.Logic
{
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
            return SortBehaviour.Sort(DbLayer.Players());
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
            return SortBehaviour.Sort(DbLayer.Teams()?.Where(t => t.Id != "0"));
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
            return SortBehaviour.Sort(DbLayer.ShowPlayers(teamId));
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
