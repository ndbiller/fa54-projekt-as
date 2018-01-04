using System.Collections.Generic;
using System.Linq;
using log4net;
using TeamManager.Models.ResourceData;
using TeamManager.Presenters.Events;
using TeamManager.Utilities;
using TeamManager.Views.Enums;
using TeamManager.Views.Interfaces;

namespace TeamManager.Presenters
{
    /// <summary>
    /// The <see cref="UnsignedPlayersPresenter"/> which will couple together with the 
    /// <see cref="Views.Windows.Dialogs.UnsignedPlayersWindow"/> and update its view.
    /// </summary>
    public class UnsignedPlayersPresenter : BasePresenter
    {
        /// <summary> The view interface of the <see cref="Views.Windows.Dialogs.UnsignedPlayersWindow"/> which used to update the ui. </summary>
        private readonly IUnsignedPlayersView _view;

        /// <summary> Logger instance of the class <see cref="UnsignedPlayersPresenter"/>. </summary>
        private static readonly ILog Log = Logger.GetLogger();




        /// <summary> 
        /// The <see cref="UnsignedPlayersPresenter"/> constructor will receive the <see cref="IUnsignedPlayersView"/> interface from the 
        /// <see cref="Views.Windows.Dialogs.UnsignedPlayersWindow"/> and couple together with the view.
        /// It'll also register a listener to the <see cref="BasePresenter.ChildClosed"/> event in order to update the view data whenever a child window closes.
        /// </summary>
        /// <param name="view"></param>
        public UnsignedPlayersPresenter(IUnsignedPlayersView view)
        {
            _view = view;
            view.PlayersListBox.Clear();

            ChildClosed += Window_ChildClose;
        }



        /// <summary>
        /// Gets all players from the <see cref="BasePresenter.Strategy"/> that are not assign to a team and
        /// Initializes the ListBox to the view.
        /// </summary>
        public void BindPlayersData()
        {
            Log.Info("Binding players data to listbox.");
            _view.PlayersListBox.Clear();
            List<Player> players = Strategy.GetAllPlayers()?.Where(p => p.TeamId == "0").ToList();
            if (players.IsNullOrEmpty()) return;

            players?.ForEach(player => _view.PlayersListBox.Add(player));
            _view.PlayerSelectedIndex = 0;
        }

        /// <summary>
        /// Gets the selected <see cref="Player"/> from the view and deletes him with the player id.
        /// </summary>
        public void DeletePlayer()
        {
            if (_view.PlayerSelectedIndex == -1) return;

            Log.Info("Deleting player.");
            int pSelIndex = _view.PlayerSelectedIndex;
            Player player = _view.PlayersListBox[pSelIndex].ToPlayer();
            if (player == null) return; 

            Strategy.RemovePlayer(player.Id);
            _view.PlayersListBox.RemoveAt(pSelIndex);
            if (_view.PlayersListBox.Count == pSelIndex)
                pSelIndex--;

            _view.PlayerSelectedIndex = pSelIndex;
        }

        /// <summary>
        /// Gets the selected <see cref="Player"/> from the view.
        /// </summary>
        /// <returns>Selected <see cref="Player"/></returns>
        public Player GetPlayer()
        {
            int pSelIndex = _view.PlayerSelectedIndex;
            if (pSelIndex == -1) return null;

            return _view.PlayersListBox[pSelIndex].ToPlayer();
        }

        /// <summary>
        /// Re-bindes players data to the view from the <see cref="Models.Strategy.IStrategy"/> when a child window closes.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void Window_ChildClose(object sender, PresenterArgs args)
        {
            int pSelIndex = _view.PlayerSelectedIndex;
            BindPlayersData();

            if (_view.PlayersListBox.Count == pSelIndex)
                pSelIndex--;

            _view.PlayerSelectedIndex = pSelIndex;
        }

        /// <summary>
        /// Invokes the <see cref="BasePresenter.ChildClosed"/> event to let all the other presenters know.
        /// </summary>
        public override void WindowClosed()
        {
            OnChildClosed(this, new PresenterArgs(WindowType.UnsignedPlayers));
        }

    }
}
