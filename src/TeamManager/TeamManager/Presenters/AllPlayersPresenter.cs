using System;
using TeamManager.Presenters.Events;
using TeamManager.Views.Enums;
using TeamManager.Views.Interfaces;

namespace TeamManager.Presenters
{
    public class AllPlayersPresenter : BasePresenter
    {
        private IAllPlayersView view;



        public AllPlayersPresenter(IAllPlayersView view)
        {
            this.view = view;
            this.view.PlayersListBox.Clear();

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

        public void UpdateView()
        {
            throw new NotImplementedException();
        }

        void Form_ChildClose(object sender, PresenterArgs args)
        {
            throw new NotImplementedException();
        }

        public override void FormClosed()
        {
            OnChildClosed(this, new PresenterArgs(FormType.AllPlayers));
        }

    }
}
