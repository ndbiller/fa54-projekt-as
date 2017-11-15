using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamManager.Database;

namespace TeamManager.Models.TechnicalConcept
{
    public interface ITechnicalConcept
    {

        Team ATeam { get; set; }
        Player APlayer { get; set; }
        
        List<string> GetAllTeams();
        string AddNewTeam(string teamName);
        string ChangeTeamName(string teamId, string NewTeamName);
        string RemoveTeam(string teamId);

        List<string> GetAllPlayer();
        List<string> GetTeamPlayers(string teamId);
        string AddNewPlayer(string playerName);
        string ChangePlayerName(string playerId);
        string RemovePlayer(string playerId);
        string TransferPlayer(string playerId, string teamId);
    }
}
