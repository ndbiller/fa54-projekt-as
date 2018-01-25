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
    /// The <see cref="EditPresenter"/> which will couple together with the <see cref="Views.Windows.Dialogs.EditWindow"/> 
    /// and update its view.
    /// </summary>
    public class EditPresenter : BasePresenter
    {
        /// <summary> The view interface of the <see cref="Views.Windows.Dialogs.EditWindow"/> which used to update the ui. </summary>
        private readonly IEditView _view;

        /// <summary> Logger instance of the class <see cref="EditPresenter"/>. </summary>
        private static readonly ILog Log = Logger.GetLogger();



        
        /// <summary> 
        /// The <see cref="EditPresenter"/> constructor will receive the <see cref="IEditView"/> interface from the 
        /// <see cref="Views.Windows.Dialogs.EditWindow"/> and couple together with the view.
        /// </summary>
        /// <param name="view"></param>
        public EditPresenter(IEditView view)
        {
            _view = view;
        }



        /// <summary>
        /// Gets <see cref="Team"/>s collection from the <see cref="Models.Strategy.IStrategy"/> 
        /// and initialize them to the view ComboBox.
        /// It also changes the TeamSelectedIndex when a <see cref="Player"/> <see cref="Team"/> is provided.
        /// </summary>
        public void BindTeamsData()
        {
            Log.Info("Binding teams data into the ComboBox.");
            _view.TeamsComboBox.Clear();
            List<Team> teams = BusinessLogic.GetAllTeams();
            if (teams.IsNullOrEmpty()) return;

            teams.ForEach(team => _view.TeamsComboBox.Add(team));

            for (int i = 0; i < teams.Count; i++)
            {
                if (_view.Team == null || teams[i].Id != _view.Team.Id) continue;
                _view.TeamSelectedIndex = i;
                break;
            }
        }

        /// <summary>
        /// Creates a new <see cref="Team"/> by using the <see cref="Models.Strategy.IStrategy"/> interface.
        /// </summary>
        public void CreateTeam()
        {
            Log.Info("Creating new team.");
            BusinessLogic.AddNewTeam(_view.NameText);
        }

        /// <summary>
        /// Edits a <see cref="Team"/> by using the <see cref="Models.Strategy.IStrategy"/> interface 
        /// and passing the team id with the new name.
        /// </summary>
        public void EditTeam()
        {
            if (_view.Team.Name == _view.NameText) return;

            Log.Info("Changing team name.");
            BusinessLogic.ChangeTeamName(_view.Team.Id, _view.NameText);
        }

        /// <summary>
        /// Edits a <see cref="Player"/> by using the <see cref="Models.Strategy.IStrategy"/> interface 
        /// and passing the player id with the new name or different team.
        /// </summary>
        public void EditPlayer()
        {
            Log.Info("Editing player.");
            if (_view.Player.Name != _view.NameText)
                BusinessLogic.ChangePlayerName(_view.Player.Id, _view.NameText);

            if (_view.TeamsComboBox.Count == 0 || _view.TeamSelectedIndex == -1) return;

            Team team = _view.TeamsComboBox[_view.TeamSelectedIndex].ToTeam();
            if (team == null) return;

            if (team.Id == _view.Team.Id) return;

            BusinessLogic.ChangePlayerTeam(_view.Player.Id, team.Id);
        }

        /// <summary>
        /// Creates a new <see cref="Player"/> and checks to see if teams not selected(-1) then simply add it, otherwise, 
        /// assign the new player to the selected <see cref="Team"/>.
        /// </summary>
        public void CreatePlayer()
        {
            Log.Info("Creating new player.");
            int tSelIndex = _view.TeamSelectedIndex;

            if (tSelIndex == -1) // -1 means nothing selected.
            {
                BusinessLogic.AddNewPlayer(_view.NameText);
            }
            else
            {
                Team team = _view.TeamsComboBox[tSelIndex].ToTeam();
                if (team != null)
                    BusinessLogic.AddNewPlayer(_view.NameText, team.Id);
            }
        }

        /// <summary>
        /// Assigns the <see cref="Player"/> to a <see cref="Team"/>.
        /// </summary>
        public void AssignToTeam()
        {
            int tSelIndex = _view.TeamSelectedIndex;
            if (tSelIndex == -1) return;

            Team team = _view.TeamsComboBox[tSelIndex].ToTeam();
            Log.Info($"Assigning player to {team.Name} team.");
            BusinessLogic.ChangePlayerTeam(_view.Player.Id, team.Id);
        }

        /// <summary>
        /// Invokes the <see cref="BasePresenter.ChildClosed"/> event to let all the other presenters know.
        /// </summary>
        public override void WindowClosed()
        {
            OnChildClosed(this, new PresenterArgs(WindowType.Edit));
        }

    }
}
