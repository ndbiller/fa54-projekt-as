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
        private readonly IUnsignedPlayersView view;



        public UnsignedPlayersPresenter(IUnsignedPlayersView view)
        {
            this.view = view;
            view.PlayersListBox.Clear();

            ChildClosed += Form_ChildClose;
        }



        public void DeletePlayer()
        {
            List<Player> players = concept.GetAllPlayers().Where(p => p.TeamId == "0").ToList();
            if (players.Count == 0) return;

            int playerSelIndex = view.PlayerSelectedIndex;
            concept.RemovePlayer(players[playerSelIndex].Id);
            view.PlayersListBox.RemoveAt(playerSelIndex);
            if (players.Count == playerSelIndex + 1)
                playerSelIndex--;

            view.PlayerSelectedIndex = playerSelIndex;
        }

        public void BindPlayersData()
        {
            view.PlayersListBox.Clear();
            List<Player> players = concept.GetAllPlayers().Where(p => p.TeamId == "0").ToList();
            if (players.Count == 0) return;

            foreach (string player in players.Select(p => p.Name))
                view.PlayersListBox.Add(player);

            view.PlayerSelectedIndex = 0;
        }

        public Player GetPlayer()
        {
            List<Player> players = concept.GetAllPlayers().Where(p => p.TeamId == "0").ToList();
            if (players.Count == 0) return null;

            return players[view.PlayerSelectedIndex];
        }

        void Form_ChildClose(object sender, PresenterArgs args)
        {
            int pSelIndex = view.PlayerSelectedIndex;
            BindPlayersData();

            if (view.PlayersListBox.Count == pSelIndex)
                pSelIndex--;

            view.PlayerSelectedIndex = pSelIndex;
        }

        public override void FormClosed()
        {
            OnChildClosed(this, new PresenterArgs(FormType.UnsignedPlayers));
        }

    }
}
