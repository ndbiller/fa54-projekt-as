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
    /// <summary>
    /// The <see cref="AllPlayersPresenter"/> which will couple together with the <see cref="Views.Windows.Dialogs.AllPlayersWindow"/> 
    /// and update its view.
    /// </summary>
    public class AllPlayersPresenter : BasePresenter
    {
        /// <summary> The view interface of the <see cref="Views.Windows.Dialogs.AllPlayersWindow"/> which used to update the ui. </summary>
        private readonly IAllPlayersView _view;

        /// <summary> Logger instance of the class <see cref="AllPlayersPresenter"/>. </summary>
        private static readonly ILog Log = Logger.GetLogger();

        /// <summary> Flag to temporarily disable SelectedIndexChanged event from updating the view to avoid indexing errors. </summary>
        private bool _allowPlayersDataBinding = true;




        /// <summary> 
        /// The <see cref="AllPlayersPresenter"/> constructor will receive the <see cref="IAllPlayersView"/> interface from the 
        /// <see cref="Views.Windows.Dialogs.AllPlayersWindow"/> and couple together with the view.
        /// It'll also register a listener to the <see cref="BasePresenter.ChildClosed"/> event in order to update the view data 
        /// whenever a child window closes.
        /// </summary>
        /// <param name="view"></param>
        public AllPlayersPresenter(IAllPlayersView view)
        {
            _view = view;
            _view.PlayersListBox.Clear();

            ChildClosed += Window_ChildClose;
        }



        /// <summary>
        /// Deletes the selected <see cref="Player"/> and updates the view.
        /// </summary>
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

        /// <summary>
        /// Gets all <see cref="Player"/>s using the <see cref="Models.TechnicalConcept.ITechnicalConcept"/> 
        /// and initializes them to the view.
        /// </summary>
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

        /// <summary>
        /// Gets the selected <see cref="Player"/> <see cref="Team"/> and updates the Player name and his Team name to the view.
        /// </summary>
        public void UpdateView()
        {
            if (!_allowPlayersDataBinding) return;

            Log.Info("Updating player data view.");
            Player player = _view.PlayersListBox[_view.PlayerSelectedIndex].ToPlayer();
            Team team = Concept.GetPlayerTeam(player.TeamId);

            _view.PlayerNameText = player.Name;
            _view.TeamNameText = team.Name;
        }

        /// <summary>
        /// Gets the selected <see cref="Player"/> and from the <see cref="Models.TechnicalConcept.ITechnicalConcept"/> 
        /// the <see cref="Team"/> of the player in order to pass to the <see cref="Views.Windows.Dialogs.EditWindow"/>.
        /// </summary>
        /// <returns><see cref="Tuple&lt;Team, Player&gt;"/></returns>
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

        /// <summary>
        /// Re-bindes players data to the view from the <see cref="Models.TechnicalConcept.ITechnicalConcept"/> when a child window closes.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void Window_ChildClose(object sender, PresenterArgs args)
        {
            int pSelIndex = _view.PlayerSelectedIndex;
            BindPlayersData();

            if (_view.PlayersListBox.Count != 1)
                _view.PlayerSelectedIndex = pSelIndex;
        }

        /// <summary>
        /// Invokes the <see cref="BasePresenter.ChildClosed"/> event to let all the other presenters know.
        /// </summary>
        public override void WindowClosed()
        {
            OnChildClosed(this, new PresenterArgs(WindowType.AllPlayers));
        }

    }
}
