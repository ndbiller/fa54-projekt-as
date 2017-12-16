using System.Collections.Generic;
using TeamManager.Models.ResourceData;
using TeamManager.Presenters.Events;
using TeamManager.Utilities;
using TeamManager.Views.Enums;
using TeamManager.Views.Interfaces;

namespace TeamManager.Presenters
{
    public class EditPresenter : BasePresenter
    {
        private readonly IEditView _view;



        public EditPresenter(IEditView view)
        {
            _view = view;
        }



        public void InitializeTeams()
        {
            _view.TeamsComboBox.Clear();
            List<Team> teams = Concept.GetAllTeams();
            if (teams.Count == 0) return;

            teams.ForEach(team => _view.TeamsComboBox.Add(team));

            for (int i = 0; i < teams.Count; i++)
            {
                if (_view.Team == null || teams[i].Id != _view.Team.Id) continue;
                _view.TeamSelectedIndex = i;
                break;
            }
        }

        public void CreateTeam()
        {
            Concept.AddNewTeam(_view.NameText);
        }

        public void EditTeam()
        {
            Concept.ChangeTeamName(_view.Team.Id, _view.NameText);
        }

        public void EditPlayer()
        {
            if (_view.Player.Name != _view.NameText)
                Concept.ChangePlayerName(_view.Player.Id, _view.NameText);

            if (_view.TeamsComboBox.Count == 0 || _view.TeamSelectedIndex == -1) return;

            Team team = _view.TeamsComboBox[_view.TeamSelectedIndex].ToTeam();
            if (team == null) return;

            if (team.Id == _view.Team.Id) return;

            Concept.ChangePlayerTeam(_view.Player.Id, team.Id);
        }

        public void CreatePlayer()
        {
            int tSelIndex = _view.TeamSelectedIndex;

            if (tSelIndex == -1) // -1 means nothing selected.
            {
                Concept.AddNewPlayer(_view.NameText);
            }
            else
            {
                Team team = _view.TeamsComboBox[tSelIndex].ToTeam();
                if (team != null)
                    Concept.AddNewPlayer(_view.NameText, team.Id);
            }
        }

        public void AssignToTeam()
        {
            int tSelIndex = _view.TeamSelectedIndex;
            if (tSelIndex == -1) return;

            Team team = _view.TeamsComboBox[tSelIndex].ToTeam();
            Concept.ChangePlayerTeam(_view.Player.Id, team.Id);
        }

        public override void FormClosed()
        {
            OnChildClosed(this, new PresenterArgs(FormType.Edit));
        }

    }
}
