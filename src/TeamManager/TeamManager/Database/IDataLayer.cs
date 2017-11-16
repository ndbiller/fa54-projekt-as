using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
        bool CreatePlayer(string name, string id);
        Player ReadPlayer(string id);
        Task<bool> UpdatePlayerAsync(string id, string name);
        bool DeletePlayer(string id);
    }
}
