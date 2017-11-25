using System;
using TeamManager.Views.Interfaces;

namespace TeamManager.Presenters
{
    public class AllPlayersPresenter : BasePresenter
    {
        private IAllPlayersView view;



        public AllPlayersPresenter(IAllPlayersView view)
        {
            this.view = view;
        }
        


        public void DeletePlayer()
        {
            throw new NotImplementedException();
        }

        public void BindPlayersData()
        {
            throw new NotImplementedException();
        }

        public void UpdateView()
        {
            throw new NotImplementedException();
        }

    }
}
