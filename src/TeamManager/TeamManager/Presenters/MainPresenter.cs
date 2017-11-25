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



        public MainPresenter(IMainView view)
        {
            this.view = view;
            this.view.TeamsListBox.Clear();
            this.view.PlayersListBox.Clear();

            ChildClosed += Form_ChildClose;
        }



        public void Search(CustomTextBoxSearch tbxSearch, bool searchInTeams)
        {
            throw new NotImplementedException();
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
