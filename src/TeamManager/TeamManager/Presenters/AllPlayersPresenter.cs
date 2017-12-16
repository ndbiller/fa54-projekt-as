using System;
using System.Collections.Generic;
using TeamManager.Models.ResourceData;
using TeamManager.Presenters.Events;
using TeamManager.Utilities;
using TeamManager.Views.Enums;
using TeamManager.Views.Interfaces;

namespace TeamManager.Presenters
{
    public class AllPlayersPresenter : BasePresenter
    {
        private readonly IAllPlayersView _view;
        private bool _allowPlayersDataBinding = true;



        public AllPlayersPresenter(IAllPlayersView view)
        {
            _view = view;
            _view.PlayersListBox.Clear();

            ChildClosed += Form_ChildClose;
        }



        public void DeletePlayer()
        {
            _allowPlayersDataBinding = false;
            List<Player> players = Concept.GetAllPlayers();
            if (players.Count == 0)
            {
                _view.PlayerNameText = string.Empty;
                _view.TeamNameText = string.Empty;
                return;
            }

            int playerSelIndex = _view.PlayerSelectedIndex;
            Concept.RemovePlayer(players[playerSelIndex].Id);
            _view.PlayersListBox.RemoveAt(playerSelIndex);
            if (players.Count == playerSelIndex + 1)
                playerSelIndex--;

            _allowPlayersDataBinding = true;
            _view.PlayerSelectedIndex = playerSelIndex;
        }

        public void BindPlayersData()
        {
            _allowPlayersDataBinding = false;
            _view.PlayersListBox.Clear();
            List<Player> players = Concept.GetAllPlayers();
            if (players.Count == 0) return;

            players.ForEach(player => _view.PlayersListBox.Add(player));
            _allowPlayersDataBinding = true;
            _view.PlayerSelectedIndex = 0;
        }

        public void UpdateView()
        {
            if (!_allowPlayersDataBinding) return;

            Player player = _view.PlayersListBox[_view.PlayerSelectedIndex].ToPlayer();
            Team team = Concept.GetPlayerTeam(player.TeamId);

            _view.PlayerNameText = player.Name;
            _view.TeamNameText = team.Name;
        }

        public Tuple<Team, Player> GetTeamAndPlayer()
        {
            if (_view.PlayersListBox.Count == 0 || _view.PlayerSelectedIndex == -1) return null;

            Player player = _view.PlayersListBox[_view.PlayerSelectedIndex].ToPlayer();
            if (player == null) return null;

            Team team = Concept.GetPlayerTeam(player.TeamId);
            if (team == null) return new Tuple<Team, Player>(null, player);

            return new Tuple<Team, Player>(team, player);
        }

        void Form_ChildClose(object sender, PresenterArgs args)
        {
            int pSelIndex = _view.PlayerSelectedIndex;
            BindPlayersData();

            _view.PlayerSelectedIndex = pSelIndex;
        }

        public override void FormClosed()
        {
            OnChildClosed(this, new PresenterArgs(FormType.AllPlayers));
        }

    }
}
