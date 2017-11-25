using System;
using System.Collections.Generic;
using TeamManager.Models.ResourceData;
using TeamManager.Presenters.Events;
using TeamManager.Views.Enums;
using TeamManager.Views.Interfaces;

namespace TeamManager.Presenters
{
    public class EditPresenter : BasePresenter
    {
        private readonly IEditView view;



        public EditPresenter(IEditView view)
        {
            this.view = view;
        }



        public void InitializeTeams()
        {
            view.TeamsComboBox.Clear();
            List<Team> teams = concept.GetAllTeams();
            if (teams.Count == 0) return;

            teams.ForEach(t => view.TeamsComboBox.Add(t.Name));

            for (int i = 0; i < teams.Count; i++)
            {
                if (view.Team != null && teams[i].Id == view.Team.Id)
                {
                    view.TeamSelectedIndex = i;
                    break;
                }
            }
        }

        public void CreateTeam()
        {
            concept.AddNewTeam(view.NameText);
        }

        public void EditTeam()
        {
            concept.ChangeTeamName(view.Team.Id, view.NameText);
        }

        public void EditPlayer()
        {
            if (view.Player.Name != view.NameText)
                concept.ChangePlayerName(view.Player.Id, view.NameText);

            List<Team> teams = concept.GetAllTeams();
            if (teams.Count == 0) return;

            Team team = teams[view.TeamSelectedIndex];
            if (team.Id == view.Team.Id) return;

            concept.ChangePlayerTeam(view.Player.Id, team.Id);
        }

        public void CreatePlayer()
        {
            int tSelIndex = view.TeamSelectedIndex;

            if (tSelIndex == -1) // -1 means nothing selected.
            {
                concept.AddNewPlayer(view.NameText);
            }
            else
            {
                List<Team> teams = concept.GetAllTeams();
                concept.AddNewPlayer(view.NameText, teams[tSelIndex].Id);
            }
        }

        public void AssignToTeam()
        {
            int tSelIndex = view.TeamSelectedIndex;
            if (tSelIndex == -1) return;

            List<Team> teams = concept.GetAllTeams();
            concept.ChangePlayerTeam(view.Player.Id, teams[tSelIndex].Id);
        }

        public override void FormClosed()
        {
            OnChildClosed(this, new PresenterArgs(FormType.Edit));
        }

    }
}
