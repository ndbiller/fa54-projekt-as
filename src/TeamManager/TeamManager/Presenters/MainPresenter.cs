using System;
using System.Collections.Generic;
using System.Windows.Forms.Custom;
using TeamManager.Models.ResourceData;
using TeamManager.Presenters.Events;
using TeamManager.Views.Interfaces;

namespace TeamManager.Presenters
{
    public class MainPresenter : BasePresenter
    {
        private IMainView view;

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



        public void Search(CustomTextBoxSearch tbxSearch, bool searchInTeams)
        {
            if (tbxSearch.TextS == tbxSearch.TextSearch)
            {
                filterTeams = false;
                filterPlayers = false;
                teamFilterText = string.Empty;
                playerFilterText = string.Empty;
                BindTeamsData();
                return;
            }

            if (searchInTeams)
            {
                filterTeams = true;
                filterPlayers = false;
                teamFilterText = tbxSearch.TextS;

                view.TeamsListBox.Clear();
                List<Team> teams = Teams();
                if (teams.Count == 0) return;

                teams.ForEach(t => view.TeamsListBox.Add(t.Name));
                view.TeamSelectedIndex = 0;
            }
            else // search in players.
            {
                filterPlayers = true;
                playerFilterText = tbxSearch.TextS;

                view.PlayersListBox.Clear();
                List<Team> teams = Teams();
                if (teams.Count == 0) return;

                List<Player> teamPlayers = TeamPlayers(teams[view.TeamSelectedIndex].Id);
                if (teamPlayers.Count == 0) return;

                teamPlayers.ForEach(p => view.PlayersListBox.Add(p.Name));
                view.PlayerSelectedIndex = 0;
            }

        }

        public void DeleteTeam()
        {
            throw new NotImplementedException();
        }

        public void DeletePlayer()
        {
            throw new NotImplementedException();
        }

        public List<Team> BindTeamsData()
        {
            throw new NotImplementedException();
        }

        public List<Player> BindPlayersData()
        {
            throw new NotImplementedException();
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
            List<Team> teams = concept.GetAllTeams();
            if (teams.Count == 0) return new Tuple<Team, Player>(null, null);

            int teamSelIndex = view.TeamSelectedIndex;
            List<Player> teamPlayers = concept.GetTeamPlayers(teams[teamSelIndex].Id);
            if (teamPlayers.Count == 0) return new Tuple<Team, Player>(null, null);

            int playerSelIndex = view.PlayerSelectedIndex;
            Player player = teamPlayers[playerSelIndex];
            Team team = teams[teamSelIndex];

            return new Tuple<Team, Player>(team, player);
        }

        public Team GetSelectedTeam()
        {
            List<Team> teams = concept.GetAllTeams();
            if (teams.Count == 0) return null;

            return teams[view.TeamSelectedIndex];
        }

        private void Form_ChildClose(object sender, PresenterArgs args)
        {
            throw new NotImplementedException();
        }

        public override void FormClosed()
        {
            // MainPresenter should do nothing.
        }

    }
}
