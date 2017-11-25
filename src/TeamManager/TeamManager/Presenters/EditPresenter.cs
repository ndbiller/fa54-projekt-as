using System;
using System.Collections.Generic;
using TeamManager.Models.ResourceData;
using TeamManager.Views.Interfaces;

namespace TeamManager.Presenters
{
    public class EditPresenter : BasePresenter
    {
        private IEditView view;



        public EditPresenter(IEditView view)
        {
            this.view = view;
        }



        public void InitializeTeams()
        {
            throw new NotImplementedException();
        }

        public void CreateTeam()
        {
            throw new NotImplementedException();
        }

        public void EditTeam()
        {
            throw new NotImplementedException();
        }

        public void EditPlayer()
        {
            throw new NotImplementedException();
        }

        public void CreatePlayer()
        {
            throw new NotImplementedException();
        }

        public void AssignToTeam()
        {
            throw new NotImplementedException();
        }
    }
}
