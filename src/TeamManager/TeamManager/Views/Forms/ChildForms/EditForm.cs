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
        private ViewType currentView;



        public EditForm(ViewType viewType)
        {
            InitializeComponent();
            InitializeComponentExtend(viewType);
            presenter = new EditPresenter(this);
        }




        private void InitializeComponentExtend(ViewType viewType)
        {
            switch (viewType)
            {
                case ViewType.TeamCreate:
                    currentView = ViewType.TeamCreate;
                    lbTeam.Hide();
                    cbxTeams.Hide();
                    Text = "Team Create";
                    break;

                case ViewType.TeamEdit:
                    currentView = ViewType.TeamEdit;
                    lbTeam.Hide();
                    cbxTeams.Hide();
                    Text = "Team Edit";
                    break;

                case ViewType.PlayerEdit:
                    currentView = ViewType.PlayerEdit;
                    Text = "Player Edit";
                    // TODO: Display player name in textbox and teams list.

                    break;

                case ViewType.PlayerCreate:
                    currentView = ViewType.PlayerCreate;
                    Text = "Player Create";
                    // TODO: Display teams list.

                    break;

                case ViewType.PlayerAssignToTeam:
                    currentView = ViewType.PlayerAssignToTeam;
                    tbxName.ReadOnly = true;
                    tbxName.Enabled = false;
                    Text = "Assign Player to Team";
                    // TODO: Display player name and teams list.

                    break;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (tbxName.Text == string.Empty) return;

            switch (currentView)
            {
                case ViewType.TeamCreate:
                    presenter.CreateTeam();
                    new UnsignedPlayersForm().ShowDialog();
                    break;

                case ViewType.TeamEdit:
                    presenter.EditTeam();
                    break;

                case ViewType.PlayerEdit:
                    presenter.EditPlayer();
                    break;

                case ViewType.PlayerCreate:
                    presenter.CreatePlayer();
                    break;

                case ViewType.PlayerAssignToTeam:
                    presenter.AssignToTeam();
                    break;
            }

            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

    }
}
