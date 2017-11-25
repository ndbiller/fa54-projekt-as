using System;
using TeamManager.Views.Interfaces;

namespace TeamManager.Presenters
{
    public class UnsignedPlayersPresenter : BasePresenter
    {
        private IUnsignedPlayersView view;



        public UnsignedPlayersPresenter(IUnsignedPlayersView view)
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

    }
}
