using System;
using System.Collections.Generic;
using log4net;
using TeamManager.Models.ResourceData;
using TeamManager.Presenters.Events;
using TeamManager.Utilities;
using TeamManager.Views.Enums;
using TeamManager.Views.Interfaces;

namespace TeamManager.Presenters
{
    public class AllPlayersPresenter : BasePresenter
    {
        /// <summary> Logger instance of the class <see cref="AllPlayersPresenter"/> </summary>
        private static readonly ILog Log = Logger.GetLogger();

        private readonly IAllPlayersView _view;

        private bool _allowPlayersDataBinding = true;



        public AllPlayersPresenter(IAllPlayersView view)
        {
            _view = view;
            _view.PlayersListBox.Clear();

            ChildClosed += Window_ChildClose;
        }



        public void DeletePlayer()
        {
            int pSelIndex = _view.PlayerSelectedIndex;
            if (pSelIndex == -1) return;

            Log.Info("Deleting player.");
            _allowPlayersDataBinding = false;

            Player player = _view.PlayersListBox[pSelIndex].ToPlayer();
            if (player == null) return;

            Concept.RemovePlayer(player.Id);
            _view.PlayersListBox.RemoveAt(pSelIndex);
            if (_view.PlayersListBox.Count == pSelIndex)
                pSelIndex--;

            _allowPlayersDataBinding = true;

            if (_view.PlayersListBox.Count == 0)
            {
                _view.PlayerNameText = string.Empty;
                _view.TeamNameText = string.Empty;
            }

            _view.PlayerSelectedIndex = pSelIndex;
        }

        public void BindPlayersData()
        {
            Log.Info("Binding players data to listbox.");
            _allowPlayersDataBinding = false;
            _view.PlayersListBox.Clear();
            List<Player> players = Concept.GetAllPlayers();
            if (players.IsNullOrEmpty()) return;

            players.ForEach(player => _view.PlayersListBox.Add(player));
            _allowPlayersDataBinding = true;
            _view.PlayerSelectedIndex = 0;
        }

        public void UpdateView()
        {
            if (!_allowPlayersDataBinding) return;

            Log.Info("Updating player data view.");
            Player player = _view.PlayersListBox[_view.PlayerSelectedIndex].ToPlayer();
            Team team = Concept.GetPlayerTeam(player.TeamId);

            _view.PlayerNameText = player.Name;
            _view.TeamNameText = team.Name;
        }

        public Tuple<Team, Player> GetTeamAndPlayer()
        {
            int pSelIndex = _view.PlayerSelectedIndex;
            if (_view.PlayersListBox.Count == 0 || pSelIndex == -1) return null;

            Player player = _view.PlayersListBox[pSelIndex].ToPlayer();
            if (player == null) return null;

            Team team = Concept.GetPlayerTeam(player.TeamId);
            if (team == null) return new Tuple<Team, Player>(null, player);

            return new Tuple<Team, Player>(team, player);
        }

        private void Window_ChildClose(object sender, PresenterArgs args)
        {
            int pSelIndex = _view.PlayerSelectedIndex;
            BindPlayersData();

            if (_view.PlayersListBox.Count != 1)
                _view.PlayerSelectedIndex = pSelIndex;
        }

        public override void WindowClosed()
        {
            OnChildClosed(this, new PresenterArgs(WindowType.AllPlayers));
        }

    }
}
