using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamManager.Main.ServeData;

namespace TeamManager.Main
{
    public class TeamManager
    {
        private TeamsMgr teamsMgr;
        private PlayersMgr playersMgr;


        public TeamManager()
        {
            teamsMgr = new TeamsMgr();
            playersMgr = new PlayersMgr();
        }
    }
}
