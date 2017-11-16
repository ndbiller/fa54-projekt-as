using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamManager.Database;
using TeamManager.Models.ResourceData;

namespace TeamManager.Models.TechnicalConcept
{
    public interface ITechnicalConcept
    {       
        List<Team> GetAllTeams();
        bool AddNewTeam(string teamName);
        bool ChangeTeamName(string teamId, string NewTeamName);
        bool RemoveTeam(string teamId);

        List<Player> GetAllPlayer();
        List<Player> GetTeamPlayers(string teamId);
        bool AddNewPlayer(string playerName);
        bool ChangePlayerName(string playerId);
        bool RemovePlayer(string playerId);
        bool TransferPlayer(string playerId, string teamId);
    }
}
