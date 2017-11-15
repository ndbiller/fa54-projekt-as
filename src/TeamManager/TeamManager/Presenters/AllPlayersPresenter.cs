using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamManager.Views.Interfaces;

namespace TeamManager.Presenters
{
    public class AllPlayersPresenter : BasePresenter
    {
        private IAllPlayersView allPlayersView;

        public AllPlayersPresenter(IAllPlayersView allPlayersView)
        {
            this.allPlayersView = allPlayersView;
        }

        public void BindPlayersData()
        {
            // TODO: Get all players from database and bind data to the view.
        }

        public void UpdateView(string playerName)
        {
            // TODO: Get the team name of a player from the database.
            allPlayersView.PlayerNameText = playerName;
            allPlayersView.TeamNameText = "0xFFFFFF";
        }
    }
}
