using System;
using System.Collections.Generic;
using System.Linq;
using log4net;
using TeamManager.Models.ResourceData;
using TeamManager.Presenters.Events;
using TeamManager.Utilities;
using TeamManager.Views.Interfaces;

namespace TeamManager.Presenters
{
    /// <summary>
    /// The <see cref="MainPresenter"/> which will couple together with the <see cref="Views.Windows.MainWindow"/> and update its view.
    /// </summary>
    public class MainPresenter : BasePresenter
    {
        /// <summary> The view interface of the <see cref="Views.Windows.MainWindow"/> which used to update the ui. </summary>
        private readonly IMainView _view;

        /// <summary> Logger instance of the class <see cref="MainPresenter"/>. </summary>
        private static readonly ILog Log = Logger.GetLogger();

        /// <summary> Flag to temporarily disable SelectedIndexChanged event from updating the view to avoid indexing errors. </summary>
        private bool _allowPlayersDataBinding = true;


        /// <summary> <see cref="Search"/> filter text to search for <see cref="Team"/>s. </summary>
        private string _teamFilterText;

        /// <summary> <see cref="Search"/> filter text to search for <see cref="Player"/>s. </summary>
        private string _playerFilterText;

        /// <summary> <see cref="Search"/> filter flag to search for <see cref="Team"/>s. </summary>
        private bool _filterTeams;

        /// <summary> <see cref="Search"/> filter flag to search for <see cref="Player"/>s. </summary>
        private bool _filterPlayers;




        /// <summary> 
        /// The <see cref="MainPresenter"/> constructor will receive the <see cref="IMainView"/> interface from the 
        /// <see cref="Views.Windows.MainWindow"/> and couple together with the view.
        /// It'll also register a listener to the <see cref="BasePresenter.ChildClosed"/> event in order to update the view data whenever a child window closes.
        /// </summary>
        /// <param name="view"></param>
        public MainPresenter(IMainView view)
        {
            _view = view;
            _view.TeamsListBox.Clear();
            _view.PlayersListBox.Clear();

            ChildClosed += Window_ChildClose;
        }


        /// <summary>
        /// Filtering functionality in relationship together with <see cref="IMainView.TeamsListBox"/> and <see cref="IMainView.PlayersListBox"/>.
        /// <see cref="IMainView.PlayersListBox"/> depends on <see cref="IMainView.TeamsListBox"/>.
        /// </summary>
        /// <param name="tbxText">The text that the user type in the textbox.</param>
        /// <param name="tbxSearchText">The text that defined in the designer to show(Search).</param>
        /// <param name="searchInTeams">To search in teams? If false it will search in players.</param>
        public void Search(string tbxText, string tbxSearchText, bool searchInTeams)
        {
            if (tbxText == tbxSearchText || string.IsNullOrEmpty(tbxText))
            {
                Log.Info("Resetting search results.");
                if (searchInTeams)
                {
                    _filterTeams = false;
                    _filterPlayers = false;
                    _teamFilterText = string.Empty;
                    _playerFilterText = string.Empty;
                    BindTeamsData();
                }
                else
                {
                    _filterPlayers = false;
                    _playerFilterText = string.Empty;
                    BindPlayersData();
                }

                return;
            }

            SearchApplyFilter(tbxText, searchInTeams);
        }

        /// <summary>
        /// Gets the filtered data from the <see cref="Models.Strategy.IStrategy"/> and updates the view.
        /// </summary>
        /// <param name="tbxText"></param>
        /// <param name="searchInTeams"></param>
        private void SearchApplyFilter(string tbxText, bool searchInTeams)
        {
            if (searchInTeams)
            {
                Log.Info("Searching in teams...");
                _filterTeams = true;
                _filterPlayers = false;
                _teamFilterText = tbxText;

                _view.TeamsListBox.Clear();
                List<Team> teams = Teams();
                if (teams.IsNullOrEmpty()) return;

                teams.ForEach(team => _view.TeamsListBox.Add(team));
                _view.TeamSelectedIndex = 0;
            }
            else // search in players.
            {
                Log.Info("Searching in players...");
                _filterPlayers = true;
                _playerFilterText = tbxText;

                _view.PlayersListBox.Clear();
                List<Team> teams = _view.TeamsListBox.Cast<Team>().ToList();
                if (teams.IsNullOrEmpty()) return;

                List<Player> teamPlayers = TeamPlayers(teams[_view.TeamSelectedIndex].Id);
                if (teamPlayers.IsNullOrEmpty()) return;

                teamPlayers.ForEach(player => _view.PlayersListBox.Add(player));
                _view.PlayerSelectedIndex = 0;
            }
        }

        /// <summary>
        /// Gets the selected <see cref="Team"/> from the view ListBox and move all their players into unsigned team(id = 0)
        /// and deletes the selected <see cref="Team"/>.
        /// </summary>
        public void DeleteTeam()
        {
            if (_view.TeamsListBox.Count == 0) return;

            Team team = _view.TeamsListBox[_view.TeamSelectedIndex].ToTeam();
            if (team == null) return;

            Log.Debug($"Deleting {team.Name} Team with Id: {team.Id}");
            List<Player> teamPlayers = _view.PlayersListBox.Cast<Player>().ToList();

            // Change all players of the deleted team to Unsigned Team("0").
            if (teamPlayers.Count > 0)
                for (int i = teamPlayers.Count - 1; i >= 0; i--)
                    BusinessLogic.ChangePlayerTeam(teamPlayers[i].Id, "0");

            BusinessLogic.RemoveTeam(team.Id);

            _allowPlayersDataBinding = false;
            int teamSelIndex = _view.TeamSelectedIndex;
            _view.TeamsListBox.RemoveAt(teamSelIndex);

            if (_view.TeamsListBox.Count == teamSelIndex)
                teamSelIndex--;

            _allowPlayersDataBinding = true;

            if (teamSelIndex == -1)
                _view.PlayersListBox.Clear();
            else
                _view.TeamSelectedIndex = teamSelIndex;
        }

        /// <summary>
        /// Gets the selected <see cref="Player"/> from the view ListBox and removes it from the current <see cref="Team"/>
        /// to unsigned players team(id = 0).
        /// </summary>
        public void DeletePlayer()
        {
            if (_view.PlayersListBox.Count == 0) return;

            Player player = _view.PlayersListBox[_view.PlayerSelectedIndex].ToPlayer();
            if (player == null) return;

            Log.Debug($"Removing {player.Name} player with Id: {player.Id} and moving to unsigned team.");
            BusinessLogic.ChangePlayerTeam(player.Id, "0");

            int playerSelIndex = _view.PlayerSelectedIndex;
            _view.PlayersListBox.RemoveAt(playerSelIndex);

            // Last index -> Go step back.
            if (_view.PlayersListBox.Count == playerSelIndex)
                playerSelIndex--;
            
            _view.PlayerSelectedIndex = playerSelIndex;
        }

        /// <summary>
        /// Gets <see cref="Team"/>s collection from the <see cref="Models.Strategy.IStrategy"/> and initialize them to the view.
        /// It also changes the TeamSelectedIndex in order to invoke the SelectedIndexChanged in the view 
        /// which will call also to <see cref="BindPlayersData"/> to initialize team players into the view.
        /// </summary>
        /// <returns><see cref="List&lt;Team&gt;"/></returns>
        public List<Team> BindTeamsData()
        {
            _view.TeamsListBox.Clear();
            List<Team> teams = Teams();
            if (teams.IsNullOrEmpty())
            {
                Log.Warn("No teams available or failed to retrieve teams from the database.");
                return null;
            }

            Log.Info("Binding teams data to listbox.");
            teams.ForEach(team => _view.TeamsListBox.Add(team));
            _view.TeamSelectedIndex = 0;

            return teams;
        }

        /// <summary>
        /// Gets the selected team <see cref="Player"/>s collection from the <see cref="Models.Strategy.IStrategy"/> 
        /// and initialize them to the view. 
        /// This method gets invoked every time the SelectedIndexChanged of the teams ListBox in the view gets invoked.
        /// </summary>
        /// <returns><see cref="List&lt;Player&gt;"/></returns>
        public List<Player> BindPlayersData()
        {
            if (!_allowPlayersDataBinding || _view.TeamsListBox.Count == 0) return null;

            Log.Info("Binding players data to listbox.");
            _view.PlayersListBox.Clear();

            Team team = _view.TeamsListBox[_view.TeamSelectedIndex].ToTeam();
            if (team == null) return null;

            List<Player> teamPlayers = TeamPlayers(team.Id);
            if (teamPlayers.IsNullOrEmpty()) return null;

            teamPlayers.ForEach(player => _view.PlayersListBox.Add(player));
            _view.PlayerSelectedIndex = 0;

            return teamPlayers;
        }

        /// <summary>
        /// Gets the selected <see cref="Team"/> and <see cref="Player"/> so the view can pass to the <see cref="Views.Windows.Dialogs.EditWindow"/>
        /// in order to edit the selected <see cref="Player"/>.
        /// </summary>
        /// <returns><see cref="Tuple&lt;Team, Player&gt;"/></returns>
        public Tuple<Team, Player> GetSelectedTeamAndPlayer()
        {
            if (_view.PlayersListBox.Count == 0 || _view.PlayerSelectedIndex == -1) return null;

            Team team = _view.TeamsListBox[_view.TeamSelectedIndex].ToTeam();
            if (team == null) return null;

            Player player = _view.PlayersListBox[_view.PlayerSelectedIndex].ToPlayer();
            if (player == null) return null;

            return new Tuple<Team, Player>(team, player);
        }

        /// <summary>
        /// Gets the selected <see cref="Team"/> so the view can pass to the <see cref="Views.Windows.Dialogs.EditWindow"/>
        /// in order to create or edit the selected <see cref="Player"/> or <see cref="Team"/>.
        /// </summary>
        /// <returns><see cref="Team"/></returns>
        public Team GetSelectedTeam()
        {
            if (_view.TeamsListBox.Count == 0) return null;
            return _view.TeamsListBox[_view.TeamSelectedIndex].ToTeam();
        }

        /// <summary>
        /// Gets a collection of <see cref="Team"/>s from the <see cref="Models.Strategy.IStrategy"/> 
        /// and checks whether to apply filter or not.
        /// </summary>
        /// <returns><see cref="List&lt;Team&gt;"/></returns>
        public List<Team> Teams()
        {
            Log.Info("Requesting Strategy for Teams.");

            return _filterTeams
                ? BusinessLogic.GetAllTeams(_teamFilterText, true)
                : BusinessLogic.GetAllTeams();
        }

        /// <summary>
        /// Gets a collection of <see cref="Player"/>s from the <see cref="Models.Strategy.IStrategy"/> 
        /// and checks whether to apply filter or not.
        /// </summary>
        /// <returns><see cref="List&lt;Player&gt;"/></returns>
        public List<Player> Players()
        {
            Log.Info("Requesting Strategy for Players.");

            return _filterPlayers
                ? BusinessLogic.GetAllPlayers(_playerFilterText, true)
                : BusinessLogic.GetAllPlayers();
        }

        /// <summary>
        /// Gets a collection of <see cref="Team"/> <see cref="Player"/>s from the <see cref="Models.Strategy.IStrategy"/> 
        /// and checks whether to apply filter or not.
        /// </summary>
        /// <returns><see cref="List&lt;Player&gt;"/></returns>
        public List<Player> TeamPlayers(string teamId)
        {
            Log.Info("Requesting Strategy for Team Players.");

            return _filterPlayers
                ? BusinessLogic.GetTeamPlayers(teamId, _playerFilterText, true)
                : BusinessLogic.GetTeamPlayers(teamId);
        }

        /// <summary>
        /// Re-bindes teams and players data to the view from the <see cref="Models.Strategy.IStrategy"/> 
        /// when a child window closes.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void Window_ChildClose(object sender, PresenterArgs args)
        {
            int tSelIndex = _view.TeamSelectedIndex;
            int pSelIndex = _view.PlayerSelectedIndex;
            int oldTeamsCount = _view.TeamsListBox.Count;
            List<Team> teams = BindTeamsData();
            // Saftey check if child window removed or created team.
            if (teams.InternalCount() != oldTeamsCount) return;

            _view.TeamSelectedIndex = tSelIndex;

            if (_view.PlayersListBox.Count == pSelIndex)
                pSelIndex--;

            _view.PlayerSelectedIndex = pSelIndex;
        }

        /// <summary> The <see cref="MainPresenter"/> not necessarly needs to invoke. </summary>
        public override void WindowClosed() { }

    }
}
