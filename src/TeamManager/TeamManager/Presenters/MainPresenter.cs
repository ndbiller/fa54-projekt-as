using System.Collections.Generic;
using System.Windows.Forms.Custom;
using TeamManager.Views.Interfaces;

namespace TeamManager.Presenters
{
    public class MainPresenter : BasePresenter
    {
        private IMainView mainView;

        public MainPresenter(IMainView mainView)
        {
            this.mainView = mainView;
        }

        public void DeletePlayer()
        {
            // TODO: Implement delete player.

            BindPlayersData();
        }

        public void DeleteTeam()
        {
            // TODO: Implement delete team.

            BindTeamsData();
            BindPlayersData();
        }

        public void Search(CustomTextBoxSearch tbxSearch, bool searchInTeams)
        {
            if (tbxSearch.TextS == tbxSearch.TextSearch)
            {
                tbxSearch.Focus();
                return;
            }

            BindTeamsData();
            BindPlayersData();

            // TODO: Implement wildcard with regex.
            if (searchInTeams)
            {
                List<string> teams = mainView.ListBoxTeams;
                mainView.ListBoxTeams = teams.FindAll(t => t.ToLower().Contains(tbxSearch.TextS.ToLower()));
            }
            else // search in players.
            {
                List<string> players = mainView.ListBoxPlayers;
                mainView.ListBoxPlayers = players.FindAll(t => t.ToLower().Contains(tbxSearch.TextS.ToLower()));
            }

        }


        public void BindTeamsData()
        {
            // TODO: Get all teams from database and bind data to the view.

        }

        public void BindPlayersData()
        {
            // TODO: Get all players from database and bind data to the view with the selected Index of the teams.
        }

    }
}
