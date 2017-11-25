using System;
using System.Collections.Generic;
using TeamManager.Models.ResourceData;
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

        public Tuple<Team, Player> GetPlayerAndTeam()
        {
            List<Player> players = concept.GetAllPlayers();
            if (players.Count == 0) return new Tuple<Team, Player>(null, null);

            int playerSelIndex = view.PlayerSelectedIndex;
            Player player = players[playerSelIndex];
            Team team = concept.GetPlayerTeam(player.TeamId);

            return new Tuple<Team, Player>(team, player);
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
