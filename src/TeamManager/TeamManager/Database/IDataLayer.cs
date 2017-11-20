using System.Collections.Generic;
using System.Threading.Tasks;
using TeamManager.Models.ResourceData;

namespace TeamManager.Database
{
    public interface IDataLayer
    {
        void ConnectDB();

        List<Team> Teams();
        bool CreateTeam(string name);
        Team ReadTeam(string id);
        Task<bool> UpdateTeamAsync(string id, string name);
        bool DeleteTeam(string id);

        List<Player> Players();
        List<Player> ShowPlayers(string teamId);
        bool CreatePlayer(string name, string teamId);
        Player ReadPlayer(string id);
        Task<bool> UpdatePlayerAsync(string id, string name);
        Task<bool> UpdatePlayerAsync(string id, string teamId, string name);
        bool DeletePlayer(string id);
        bool ChangePlayerTeam(string playerId, string teamId);
    }
}
