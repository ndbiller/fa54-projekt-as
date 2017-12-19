using System;
using System.Windows.Forms;
using System.Windows.Forms.Custom;
using TeamManager.Models.ResourceData;
using TeamManager.Presenters;
using TeamManager.Views.Enums;
using TeamManager.Views.Interfaces;

namespace TeamManager.Views.Forms.Dialogs
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


        private readonly EditPresenter _presenter;
        private EditMode _currentView;



        public EditForm(EditMode editMode, Team team, Player player)
        {
            Team = team;
            Player = player;
            InitializeComponent();
            _presenter = new EditPresenter(this);

            InitializeComponentExtend(editMode);
        }


        private void InitializeComponentExtend(EditMode editMode)
        {
            switch (editMode)
            {
                case EditMode.TeamCreate:
                    _currentView = EditMode.TeamCreate;
                    lbTeam.Hide();
                    cbxTeams.Hide();
                    Text = "Team Create";
                    break;

                case EditMode.TeamEdit:
                    _currentView = EditMode.TeamEdit;
                    lbTeam.Hide();
                    cbxTeams.Hide();
                    Text = "Team Edit";
                    tbxName.Text = Team.Name;
                    break;

                case EditMode.PlayerEdit:
                    _currentView = EditMode.PlayerEdit;
                    Text = "Player Edit";
                    tbxName.Text = Player.Name;
                    _presenter.InitializeTeams();
                    break;

                case EditMode.PlayerCreate:
                    _currentView = EditMode.PlayerCreate;
                    Text = "Player Create";
                    _presenter.InitializeTeams();
                    break;

                case EditMode.PlayerAssignToTeam:
                    _currentView = EditMode.PlayerAssignToTeam;
                    tbxName.ReadOnly = true;
                    tbxName.Enabled = false;
                    Text = "Assign Player to Team";
                    tbxName.Text = Player.Name;
                    _presenter.InitializeTeams();
                    break;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (tbxName.Text == string.Empty) return;

            switch (_currentView)
            {
                case EditMode.TeamCreate:
                    _presenter.CreateTeam();
                    DialogResult answer = MessageBox.Show("Would you like to assign unsigned players to your new created team?", 
                        "Suggestion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (answer == DialogResult.Yes)
                        new UnsignedPlayersForm().ShowDialog();
                    break;

                case EditMode.TeamEdit:
                    _presenter.EditTeam();
                    break;

                case EditMode.PlayerEdit:
                    _presenter.EditPlayer();
                    break;

                case EditMode.PlayerCreate:
                    _presenter.CreatePlayer();
                    break;

                case EditMode.PlayerAssignToTeam:
                    if (TeamSelectedIndex != -1)
                        _presenter.AssignToTeam();
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
            _presenter.FormClosed();
        }

    }
}
