using System;
using System.Windows.Forms;
using System.Windows.Forms.Custom;
using TeamManager.Models.ResourceData;
using TeamManager.Presenters;
using TeamManager.Views.Enums;
using TeamManager.Views.Interfaces;

namespace TeamManager.Views.Forms.ChildForms
{
    public partial class EditForm : CustomForm, IEditView
    {

        #region --- View Interface Items ---

        public int TeamSelectedIndex
        {
            get => cbxTeams.SelectedIndex;
            set => cbxTeams.SelectedIndex = value;
        }
        public string NameText => tbxName.Text;
        public Team Team { get; }
        public Player Player { get; }
        public ComboBox.ObjectCollection TeamsComboBox => cbxTeams.Items;

        #endregion --- View Interface Items ---


        private EditPresenter presenter;
        private EditMode currentView;



        public EditForm(EditMode editMode, Team team, Player player)
        {
            Team = team;
            Player = player;
            InitializeComponent();
            presenter = new EditPresenter(this);

            InitializeComponentExtend(editMode);
        }


        private void InitializeComponentExtend(EditMode editMode)
        {
            switch (editMode)
            {
                case EditMode.TeamCreate:
                    currentView = EditMode.TeamCreate;
                    lbTeam.Hide();
                    cbxTeams.Hide();
                    Text = "Team Create";
                    break;

                case EditMode.TeamEdit:
                    currentView = EditMode.TeamEdit;
                    lbTeam.Hide();
                    cbxTeams.Hide();
                    Text = "Team Edit";
                    tbxName.Text = Team.Name;
                    break;

                case EditMode.PlayerEdit:
                    currentView = EditMode.PlayerEdit;
                    Text = "Player Edit";
                    tbxName.Text = Player.Name;
                    presenter.InitializeTeams();
                    break;

                case EditMode.PlayerCreate:
                    currentView = EditMode.PlayerCreate;
                    Text = "Player Create";
                    presenter.InitializeTeams();
                    break;

                case EditMode.PlayerAssignToTeam:
                    currentView = EditMode.PlayerAssignToTeam;
                    tbxName.ReadOnly = true;
                    tbxName.Enabled = false;
                    Text = "Assign Player to Team";
                    tbxName.Text = Player.Name;
                    presenter.InitializeTeams();
                    break;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (tbxName.Text == string.Empty) return;

            switch (currentView)
            {
                case EditMode.TeamCreate:
                    presenter.CreateTeam();
                    new UnsignedPlayersForm().ShowDialog();
                    break;

                case EditMode.TeamEdit:
                    presenter.EditTeam();
                    break;

                case EditMode.PlayerEdit:
                    presenter.EditPlayer();
                    break;

                case EditMode.PlayerCreate:
                    presenter.CreatePlayer();
                    break;

                case EditMode.PlayerAssignToTeam:
                    presenter.AssignToTeam();
                    break;
            }

            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void EditForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            presenter.FormClosed();
        }

    }
}
