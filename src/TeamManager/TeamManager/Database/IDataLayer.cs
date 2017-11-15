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
        void ConnectDB(string connectionString);

        List<Team> Teams();
        bool CreateTeam(string name);
        Team ReadTeam(string id);
        bool UpdateTeam(string id);
        bool DeleteTeam(string id);

        List<Player> Players();
        Player ShowPlayer(string id);
        bool CreatePlayer(string name);
        Player ReadPlayer(string id);
        bool UpdatePlayer(string id);
        bool DeletePlayer(string id);
    }
}
