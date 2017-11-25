using System.Collections.Generic;
using TeamManager.Models.ResourceData;

namespace TeamManager.Models.TechnicalConcept
{
    public interface ITechnicalConcept
    {
        List<Team> GetAllTeams();
        Team GetPlayerTeam(string teamId);
        bool AddNewTeam(string teamName);
        bool ChangeTeamName(string teamId, string teamNewName);
        bool RemoveTeam(string teamId);

        List<Player> GetAllPlayers();
        List<Player> GetTeamPlayers(string teamId);
        bool AddNewPlayer(string playerName);
        bool AddNewPlayer(string playerName, string teamId);
        bool ChangePlayerName(string playerId, string playerNewName);
        bool RemovePlayer(string playerId);
        bool ChangePlayerTeam(string playerId, string teamId);
    }
}
