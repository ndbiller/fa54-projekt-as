using System.Collections.Generic;
using System.Linq;
using TeamManager.Database;
using TeamManager.Models.ResourceData;

namespace TeamManager.Models.TechnicalConcept
{
    /// <summary>
    /// The <see cref="TechnicalConcept1"/> implementation will retrieve the data from the 
    /// <see cref="TechnicalConceptBase.DbLayer"/> in ascending order.
    /// The constructor that gets the <see cref="DatabaseType"/> will pass forward to the base constructor
    /// in order to initialize the <see cref="IDataLayer"/> which is used as the <see cref="TechnicalConceptBase.DbLayer"/>.
    /// For more details, please see <see cref="ITechnicalConcept"/> documentation.
    /// </summary>
    public class TechnicalConcept1 : TechnicalConceptBase, ITechnicalConcept
    {
        public TechnicalConcept1(DatabaseType dbType) : base(dbType) { }


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
            return DbLayer.Players()?.OrderBy(p => p.Name).ToList();
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
            return DbLayer.Teams()?
                .Where(t => t.Id != "0")
                .OrderBy(t => t.Name)
                .ToList();
        }

        public List<Team> GetAllTeams(string filterText, bool ignoreCase)
        {
            return GetAllTeams()?
                .Where(
                    t => t.Id != "0"
                         && t.Name.ToLower().Contains(ignoreCase ? filterText.ToLower() : filterText)
                ).ToList();
        }

        public List<Player> GetTeamPlayers(string teamId)
        {
            return DbLayer.ShowPlayers(teamId)?.OrderBy(p => p.Name).ToList();
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
