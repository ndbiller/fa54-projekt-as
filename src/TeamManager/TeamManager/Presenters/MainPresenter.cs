using System;
using System.Collections.Generic;
using System.Windows.Forms.Custom;
using TeamManager.Models.ResourceData;
using TeamManager.Views.Interfaces;

namespace TeamManager.Presenters
{
    public class MainPresenter : BasePresenter
    {
        private IMainView view;



        public MainPresenter(IMainView view)
        {
            this.view = view;
        }



        public void Search(CustomTextBoxSearch tbxSearch, bool searchInTeams)
        {
            throw new NotImplementedException();
        }

        public void DeleteTeam()
        {
            throw new NotImplementedException();
        }

        public void DeletePlayer()
        {
            throw new NotImplementedException();
        }

        public List<Team> BindTeamsData()
        {
            throw new NotImplementedException();
        }

        public List<Player> BindPlayersData()
        {
            throw new NotImplementedException();
        }

    }
}
