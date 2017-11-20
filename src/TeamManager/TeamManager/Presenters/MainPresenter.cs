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
#if !MONGO_DB
            // TODO: Get all teams from database and bind data to the view.
            // Example:
            List<Team> teams = GetAllTeamsFromDatabase();
            mainView.ListBoxTeams = teams.Select(t => t.Name).ToList();
#endif
        }


        public void BindPlayersData()
        {
            // TODO: Get all players from database and bind data to the view with the selected Index of the teams.
        }

#if !MONGO_DB
        // TODO: Remove me after finish.
        // Just a temp example to demonstrate retrieving data from the db.
        private List<Team> GetAllTeamsFromDatabase()
        {
            return new List<Team>
            {
                new Team{Id = 1, Name = "England"},
                new Team{Id = 2, Name = "Arsenal"},
                new Team{Id = 3, Name = "Chelsea"},
                new Team{Id = 4, Name = "Manchester United"},
                new Team{Id = 5, Name = "Scotland"},
                new Team{Id = 6, Name = "Wales"}
            };

        }
#endif
    }
}
