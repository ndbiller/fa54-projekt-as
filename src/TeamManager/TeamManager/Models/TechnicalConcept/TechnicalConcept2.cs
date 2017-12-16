using System;
using System.Collections.Generic;
using System.Linq;
using TeamManager.Database;
using TeamManager.Models.ResourceData;

namespace TeamManager.Models.TechnicalConcept
{
    public class TechnicalConcept2 : TechnicalConceptBase, ITechnicalConcept
    {
        public TechnicalConcept2(DatabaseType dbType) : base(dbType) { }

        public bool AddNewPlayer(string playerName)
        {
            return dbLayer.CreatePlayer(playerName, "0");
        }

        public bool AddNewPlayer(string playerName, string teamId)
        {
            return dbLayer.CreatePlayer(playerName, teamId);
        }

        public Team GetPlayerTeam(string teamId)
        {
            return dbLayer.ReadTeam(teamId);
        }

        public bool AddNewTeam(string teamName)
        {
            return dbLayer.CreateTeam(teamName);
        }

        public bool ChangePlayerName(string playerId, string playerNewName)
        {
            return dbLayer.UpdatePlayerAsync(playerId, playerNewName).Result;
        }

        public bool ChangeTeamName(string teamId, string teamNewName)
        {
            return dbLayer.UpdateTeamAsync(teamId, teamNewName).Result;
        }

        public List<Player> GetAllPlayers()
        {
            return dbLayer.Players().OrderByDescending(p => p.Name).ToList();
        }

        public List<Player> GetAllPlayers(string filterText, bool ignoreCase)
        {
            return GetAllPlayers()
                .Where(
                    p => p.Name.ToLower().Contains(ignoreCase ? filterText.ToLower() : filterText)
                ).ToList();
        }

        public List<Team> GetAllTeams()
        {
            return dbLayer.Teams()
                .Where(t => t.Id != "0")
                .OrderByDescending(t => t.Name)
                .ToList();
        }

        public List<Team> GetAllTeams(string filterText, bool ignoreCase)
        {
            return GetAllTeams()
                .Where(
                    t => t.Id != "0"
                         && t.Name.ToLower().Contains(ignoreCase ? filterText.ToLower() : filterText)
                ).ToList();
        }

        public List<Player> GetTeamPlayers(string teamId)
        {
            return dbLayer.ShowPlayers(teamId).OrderByDescending(p => p.Name).ToList();
        }

        public List<Player> GetTeamPlayers(string teamId, string filterText, bool ignoreCase)
        {
            return GetTeamPlayers(teamId)
                .Where(
                    t => t.Name.ToLower().Contains(ignoreCase ? filterText.ToLower() : filterText)
                ).ToList();
        }

        public bool RemovePlayer(string playerId)
        {
            return dbLayer.DeletePlayer(playerId);
        }

        public bool RemoveTeam(string teamId)
        {
            return dbLayer.DeleteTeam(teamId);
        }

        public bool ChangePlayerTeam(string playerId, string teamId)
        {
            return dbLayer.ChangePlayerTeam(playerId, teamId);
        }
    }
}
