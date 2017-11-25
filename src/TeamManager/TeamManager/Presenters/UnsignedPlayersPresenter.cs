using System;
using TeamManager.Presenters.Events;
using TeamManager.Views.Enums;
using TeamManager.Views.Interfaces;

namespace TeamManager.Presenters
{
    public class UnsignedPlayersPresenter : BasePresenter
    {
        private IUnsignedPlayersView view;



        public UnsignedPlayersPresenter(IUnsignedPlayersView view)
        {
            this.view = view;
            view.PlayersListBox.Clear();

            ChildClosed += Form_ChildClose;
        }



        public void DeletePlayer()
        {
            throw new NotImplementedException();
        }

        public void BindPlayersData()
        {
            throw new NotImplementedException();
        }

        void Form_ChildClose(object sender, PresenterArgs args)
        {
            throw new NotImplementedException();
        }

        public override void FormClosed()
        {
            OnChildClosed(this, new PresenterArgs(FormType.UnsignedPlayers));
        }
    }
}
