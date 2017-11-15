using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamManager.Models.ResourceData;
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

#if !MONGO_DB
        public void BindTeamsData()
        {
            // TODO: Get all teams from database and bind data to the view.
            // Example:
            List<Team> teams = GetAllTeamsFromDatabase();
            mainView.ListBoxTeams = teams.Select(t => t.Name).ToList();
        }
#endif

        public void BindPlayersData()
        {
            // TODO: Get all players from database and bind data to the view.
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
