using System;
using System.Collections.Generic;
using System.Linq;
using TeamManager.Models.ResourceData;
using TeamManager.Presenters.Events;
using TeamManager.Views.Enums;
using TeamManager.Views.Interfaces;

namespace TeamManager.Presenters
{
    public class AllPlayersPresenter : BasePresenter
    {
        private readonly IAllPlayersView view;
        private bool allowPlayersDataBinding = true;



        public AllPlayersPresenter(IAllPlayersView view)
        {
            this.view = view;
            this.view.PlayersListBox.Clear();

            ChildClosed += Form_ChildClose;
        }



        public void DeletePlayer()
        {
            allowPlayersDataBinding = false;
            List<Player> players = concept.GetAllPlayers();
            if (players.Count == 0)
            {
                view.PlayerNameText = string.Empty;
                view.TeamNameText = string.Empty;
                return;
            }

            int playerSelIndex = view.PlayerSelectedIndex;
            concept.RemovePlayer(players[playerSelIndex].Id);
            view.PlayersListBox.RemoveAt(playerSelIndex);
            if (players.Count == playerSelIndex + 1)
                playerSelIndex--;

            allowPlayersDataBinding = true;
            view.PlayerSelectedIndex = playerSelIndex;
        }

        public void BindPlayersData()
        {
            allowPlayersDataBinding = false;
            view.PlayersListBox.Clear();
            List<Player> players = concept.GetAllPlayers();
            if (players.Count == 0) return;

            foreach (string player in players.Select(p => p.Name))
                view.PlayersListBox.Add(player);

            allowPlayersDataBinding = true;
            view.PlayerSelectedIndex = 0;
        }

        public void UpdateView()
        {
            if (!allowPlayersDataBinding) return;

            List<Player> players = concept.GetAllPlayers();
            int playerSelIndex = view.PlayerSelectedIndex;
            if (players.Count == 0) return;

            Player player = players[playerSelIndex];
            Team team = concept.GetPlayerTeam(player.TeamId);

            view.PlayerNameText = player.Name;
            view.TeamNameText = team.Name;
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
            int pSelIndex = view.PlayerSelectedIndex;
            BindPlayersData();

            view.PlayerSelectedIndex = pSelIndex;
        }

        public override void FormClosed()
        {
            OnChildClosed(this, new PresenterArgs(FormType.AllPlayers));
        }

    }
}
