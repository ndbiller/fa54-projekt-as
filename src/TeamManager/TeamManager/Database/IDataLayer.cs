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
        bool DeleteTeam(string id);

        List<Player> Players();
        List<Player> ShowPlayers(string teamId);
        bool CreatePlayer(string name, string teamId);
        Player ReadPlayer(string id);
        bool UpdatePlayer(string id, string name);
        bool UpdatePlayer(string id, string teamId, string name);
        bool DeletePlayer(string id);
        bool ChangePlayerTeam(string playerId, string teamId);



        #region --- Async Methods ---

        Task<List<Team>> TeamsAsync();
        Task<bool> CreateTeamAsync(string name);
        Task<Team> ReadTeamAsync(string id);
        Task<bool> UpdateTeamAsync(string id, string name);
        Task<bool> DeleteTeamAsync(string id);

        Task<List<Player>> PlayersAsync();
        Task<List<Player>> ShowPlayersAsync(string teamId);
        Task<bool> CreatePlayerAsync(string name, string teamId);
        Task<Player> ReadPlayerAsync(string id);
        Task<bool> UpdatePlayerAsync(string id, string name);
        Task<bool> UpdatePlayerAsync(string id, string teamId, string name);
        Task<bool> DeletePlayerAsync(string id);
        Task<bool> ChangePlayerTeamAsync(string playerId, string teamId);

        #endregion --- Async Methods ---

    }
}
