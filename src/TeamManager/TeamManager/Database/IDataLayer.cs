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
        bool UpdateTeam(string id, string name);
        Task<bool> UpdateTeamAsync(string id, string name);
        bool DeleteTeam(string id);

        List<Player> Players();
        List<Player> ShowPlayers(string teamId);
        bool CreatePlayer(string name, string teamId);
        Player ReadPlayer(string id);
        bool UpdatePlayer(string id, string name);
        Task<bool> UpdatePlayerAsync(string id, string name);
        bool UpdatePlayer(string id, string teamId, string name);
        Task<bool> UpdatePlayerAsync(string id, string teamId, string name);
        bool DeletePlayer(string id);
        bool ChangePlayerTeam(string playerId, string teamId);
    }
}
