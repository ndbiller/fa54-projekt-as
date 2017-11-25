using System;
using System.Collections.Generic;
using System.Linq;
using TeamManager.Models.ResourceData;
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

        public Player GetPlayer()
        {
            List<Player> players = concept.GetAllPlayers().Where(p => p.TeamId == "0").ToList();
            if (players.Count == 0) return null;

            return players[view.PlayerSelectedIndex];
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
