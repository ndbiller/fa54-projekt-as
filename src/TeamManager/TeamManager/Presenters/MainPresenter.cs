using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using log4net;
using TeamManager.Models.ResourceData;
using TeamManager.Presenters.Events;
using TeamManager.Utilities;
using TeamManager.Views.Interfaces;

namespace TeamManager.Presenters
{
    public class MainPresenter : BasePresenter
    {
        private static readonly ILog Log = Logger.GetLogger();

        /// <summary>
        /// Main view object that will be accessed to update the ui.
        /// </summary>
        private readonly IMainView _view;

        /// <summary>
        /// Since the PlayersListBox depend on the TeamsListBox, we want in certain situations to temporary 
        /// disable SelectedIndexChanged event from binding the players data to avoid indexing errors.
        /// </summary>
        private bool _allowPlayersDataBinding = true;

        /// <summary>
        /// Filtering variables when using the search functionality.
        /// </summary>
        private string _teamFilterText;
        private string _playerFilterText;
        private bool _filterTeams;
        private bool _filterPlayers;



        public MainPresenter(IMainView view)
        {
            _view = view;
            _view.TeamsListBox.Clear();
            _view.PlayersListBox.Clear();

            ChildClosed += Form_ChildClose;
        }


        /// <summary>
        /// Filtering functionality in relationship together with TeamsListBox and PlayersListBox.
        /// PlayersListBox depends on TeamsListBox.
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
                    Concept.ChangePlayerTeam(teamPlayers[i].Id, "0");

            Concept.RemoveTeam(team.Id);

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

        public void DeletePlayer()
        {
            if (_view.PlayersListBox.Count == 0) return;

            Player player = _view.PlayersListBox[_view.PlayerSelectedIndex].ToPlayer();
            if (player == null) return;

            Log.Debug($"Removing {player.Name} player with Id: {player.Id} and moving to unsigned team.");
            Concept.ChangePlayerTeam(player.Id, "0");

            int playerSelIndex = _view.PlayerSelectedIndex;
            _view.PlayersListBox.RemoveAt(playerSelIndex);

            // Last index -> Go step back.
            if (_view.PlayersListBox.Count == playerSelIndex)
                playerSelIndex--;

            _view.PlayerSelectedIndex = playerSelIndex;
        }

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

        public Tuple<Team, Player> GetSelectedTeamAndPlayer()
        {
            if (_view.PlayersListBox.Count == 0 || _view.PlayerSelectedIndex == -1) return null;

            Team team = _view.TeamsListBox[_view.TeamSelectedIndex].ToTeam();
            if (team == null) return null;

            Player player = _view.PlayersListBox[_view.PlayerSelectedIndex].ToPlayer();
            if (player == null) return null;

            return new Tuple<Team, Player>(team, player);
        }

        public Team GetSelectedTeam()
        {
            if (_view.TeamsListBox.Count == 0) return null;
            return _view.TeamsListBox[_view.TeamSelectedIndex].ToTeam();
        }

        /// <summary>
        /// Use that instead of the concept type to get all teams as it will differentiate between the 
        /// filtered method or the clean to avoid duplicated code.
        /// </summary>
        /// <returns></returns>
        public List<Team> Teams()
        {
            Log.Info("Requesting TechnicalConcept for Teams.");

            return _filterTeams
                ? Concept.GetAllTeams(_teamFilterText, true)
                : Concept.GetAllTeams();
        }

        /// <summary>
        /// Use that instead of the concept type to get all players as it will differentiate between the 
        /// filtered method or the clean to avoid duplicated code.
        /// </summary>
        /// <returns></returns>
        public List<Player> Players()
        {
            Log.Info("Requesting TechnicalConcept for Players.");

            return _filterPlayers
                ? Concept.GetAllPlayers(_playerFilterText, true)
                : Concept.GetAllPlayers();
        }

        /// <summary>
        /// Use that instead of the concept type to get all team players as it will differentiate between the 
        /// filtered method or the clean to avoid duplicated code.
        /// </summary>
        /// <returns></returns>
        public List<Player> TeamPlayers(string teamId)
        {
            Log.Info("Requesting TechnicalConcept for Team Players.");

            return _filterPlayers
                ? Concept.GetTeamPlayers(teamId, _playerFilterText, true)
                : Concept.GetTeamPlayers(teamId);
        }


        private void Form_ChildClose(object sender, PresenterArgs args)
        {
            int tSelIndex = _view.TeamSelectedIndex;
            int pSelIndex = _view.PlayerSelectedIndex;
            int oldTeamsCount = _view.TeamsListBox.Count;
            List<Team> teams = BindTeamsData();
            // Saftey check if child form removed or created team.
            if (teams.InternalCount() != oldTeamsCount) return;

            _view.TeamSelectedIndex = tSelIndex;

            if (_view.PlayersListBox.Count == pSelIndex)
                pSelIndex--;

            _view.PlayerSelectedIndex = pSelIndex;
        }

        public override void FormClosed() { }

    }
}
