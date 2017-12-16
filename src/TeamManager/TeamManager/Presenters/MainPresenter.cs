using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.Custom;
using TeamManager.Models.ResourceData;
using TeamManager.Presenters.Events;
using TeamManager.Views.Interfaces;

namespace TeamManager.Presenters
{
    public class MainPresenter : BasePresenter
    {
        /// <summary>
        /// Main view object that will be accessed to update the ui.
        /// </summary>
        private readonly IMainView view;

        /// <summary>
        /// Since the PlayersListBox depend on the TeamsListBox, we want in certain situations to temporary 
        /// disable SelectedIndexChanged event from binding the players data to avoid indexing errors.
        /// </summary>
        private bool allowPlayersDataBinding = true;

        /// <summary>
        /// Filtering variables when using the search functionality.
        /// </summary>
        private string teamFilterText;
        private string playerFilterText;
        private bool filterTeams;
        private bool filterPlayers;



        public MainPresenter(IMainView view)
        {
            this.view = view;
            this.view.TeamsListBox.Clear();
            this.view.PlayersListBox.Clear();

            ChildClosed += Form_ChildClose;
        }


        /// <summary>
        /// Filtering functionality in relationship together with TeamsListBox and PlayersListBox.
        /// PlayersListBox depends on TeamsListBox.
        /// </summary>
        /// <param name="tbxText">The text that the user type in the textbox.</param>
        /// <param name="tbxSearchText">The text that defined in the designer to show(Search).</param>
        /// <param name="searchInTeams">To search in teams or players flag.</param>
        public void Search(string tbxText, string tbxSearchText, bool searchInTeams)
        {
            if (tbxText == tbxSearchText || string.IsNullOrEmpty(tbxText))
            {
                if (searchInTeams)
                {
                    filterTeams = false;
                    filterPlayers = false;
                    teamFilterText = string.Empty;
                    playerFilterText = string.Empty;
                    BindTeamsData();
                }
                else
                {
                    filterPlayers = false;
                    playerFilterText = string.Empty;
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
                filterTeams = true;
                filterPlayers = false;
                teamFilterText = tbxText;

                view.TeamsListBox.Clear();
                List<Team> teams = Teams();
                if (teams.Count == 0) return;

                teams.ForEach(team => view.TeamsListBox.Add(team));
                view.TeamSelectedIndex = 0;
            }
            else // search in players.
            {
                filterPlayers = true;
                playerFilterText = tbxText;

                view.PlayersListBox.Clear();
                List<Team> teams = view.TeamsListBox.Cast<Team>().ToList();
                if (teams.Count == 0) return;

                List<Player> teamPlayers = TeamPlayers(teams[view.TeamSelectedIndex].Id);
                if (teamPlayers.Count == 0) return;

                teamPlayers.ForEach(player => view.PlayersListBox.Add(player));
                view.PlayerSelectedIndex = 0;
            }
        }

        public void DeleteTeam()
        {
            List<Team> teams = Teams();
            if (teams.Count == 0) return;

            int teamSelIndex = view.TeamSelectedIndex;
            List<Player> teamPlayers = TeamPlayers(teams[teamSelIndex].Id);

            // Change all players of the deleted team to Unsigned Team("0").
            if (teamPlayers.Count > 0)
                for (int i = teamPlayers.Count - 1; i >= 0; i--)
                    concept.ChangePlayerTeam(teamPlayers[i].Id, "0");

            concept.RemoveTeam(teams[teamSelIndex].Id);

            allowPlayersDataBinding = false;
            view.TeamsListBox.RemoveAt(teamSelIndex);

            if (teams.Count == teamSelIndex + 1)
                teamSelIndex--;

            allowPlayersDataBinding = true;

            view.TeamSelectedIndex = teamSelIndex;
        }

        public void DeletePlayer()
        {
            List<Team> teams = Teams();
            if (teams.Count == 0) return;

            int teamSelIndex = view.TeamSelectedIndex;
            List<Player> teamPlayers = TeamPlayers(teams[teamSelIndex].Id);
            if (teamPlayers.Count == 0) return;

            int playerSelIndex = view.PlayerSelectedIndex;
            concept.ChangePlayerTeam(teamPlayers[playerSelIndex].Id, "0");
            view.PlayersListBox.RemoveAt(playerSelIndex);

            // Last index -> Go step back.
            if (teamPlayers.Count == playerSelIndex + 1)
                playerSelIndex--;

            view.PlayerSelectedIndex = playerSelIndex;
        }

        public List<Team> BindTeamsData()
        {
            view.TeamsListBox.Clear();
            List<Team> teams = Teams();
            if (teams.Count == 0) return null;

            foreach (Team team in teams)
                view.TeamsListBox.Add(team);

            view.TeamSelectedIndex = 0;

            return teams;
        }

        public List<Player> BindPlayersData()
        {
            if (!allowPlayersDataBinding) return null;

            view.PlayersListBox.Clear();
            List<Team> teams = view.TeamsListBox.Cast<Team>().ToList();
            if (teams.Count == 0) return null;

            int teamSelIndex = view.TeamSelectedIndex;
            List<Player> teamPlayers = TeamPlayers(teams[teamSelIndex].Id);
            if (teamPlayers.Count == 0) return null;

            foreach (Player player in teamPlayers)
                view.PlayersListBox.Add(player);

            view.PlayerSelectedIndex = 0;

            return teamPlayers;
        }

        /// <summary>
        /// Use that instead of the concept type to get all teams as it will differentiate between the 
        /// filtered method or the clean to avoid duplicated code.
        /// </summary>
        /// <returns></returns>
        public List<Team> Teams()
        {
            return filterTeams
                ? concept.GetAllTeams(teamFilterText, true)
                : concept.GetAllTeams();
        }

        /// <summary>
        /// Use that instead of the concept type to get all players as it will differentiate between the 
        /// filtered method or the clean to avoid duplicated code.
        /// </summary>
        /// <returns></returns>
        public List<Player> Players()
        {
            return filterPlayers
                ? concept.GetAllPlayers(playerFilterText, true)
                : concept.GetAllPlayers();
        }

        /// <summary>
        /// Use that instead of the concept type to get all team players as it will differentiate between the 
        /// filtered method or the clean to avoid duplicated code.
        /// </summary>
        /// <returns></returns>
        public List<Player> TeamPlayers(string teamId)
        {
            return filterPlayers
                ? concept.GetTeamPlayers(teamId, playerFilterText, true)
                : concept.GetTeamPlayers(teamId);
        }

        public Tuple<Team, Player> GetSelectedPlayerAndTeam()
        {
            List<Team> teams = Teams();
            if (teams.Count == 0) return null;

            int teamSelIndex = view.TeamSelectedIndex;
            List<Player> teamPlayers = TeamPlayers(teams[teamSelIndex].Id);
            if (teamPlayers.Count == 0) return null;

            int playerSelIndex = view.PlayerSelectedIndex;
            Player player = teamPlayers[playerSelIndex];
            Team team = teams[teamSelIndex];

            return new Tuple<Team, Player>(team, player);
        }

        public Team GetSelectedTeam()
        {
            return view.TeamsListBox[view.TeamSelectedIndex] as Team;
        }

        private void Form_ChildClose(object sender, PresenterArgs args)
        {
            int tSelIndex = view.TeamSelectedIndex;
            int pSelIndex = view.PlayerSelectedIndex;
            int oldTeamsCount = view.TeamsListBox.Count;
            List<Team> teams = BindTeamsData();
            // Saftey check if child form removed or created team.
            if (teams.Count != oldTeamsCount) return;

            view.TeamSelectedIndex = tSelIndex;

            if (view.PlayersListBox.Count == pSelIndex)
                pSelIndex--;

            view.PlayerSelectedIndex = pSelIndex;
        }

        public override void FormClosed()
        {
            // MainPresenter should do nothing.
        }

    }
}
