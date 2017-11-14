using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamManager.Database;

namespace TeamManager.TechnicalConcept
{
    public interface ITechnicalConcept
    {
        IDbManager ADbManager { get; set; }

        Team ATeam { get; set; }
        Player APlayer { get; set; }
        
        List<String> GetAllTeams();
        String AddNewTeam(String teamName);
        String ChangeTeamName(String teamId, String NewTeamName);
        String RemoveTeam(String teamId);

        List<String> GetAllPlayer();
        List<String> GetTeamPlayers(String teamId);
        String AddNewPlayer(String playerName);
        String ChangePlayerName(String playerId);
        String RemovePlayer(String playerId);
        String TransferPlayer(String playerId, String teamId);
    }
}
