using System;
using System.Windows.Forms;
using System.Windows.Forms.Custom;
using TeamManager.Models.ResourceData;
using TeamManager.Presenters;
using TeamManager.Views.Enums;
using TeamManager.Views.Interfaces;

namespace TeamManager.Views.Windows.Dialogs
{
    /// <summary>
    /// The <see cref="EditWindow"/> is pretty re-useable in many cases where we can specify what we want to edit depending on the <see cref="EditMode"/>
    /// that is required when creating an instance of this window.
    /// </summary>
    public partial class EditWindow : CustomForm, IEditView
    {
        /// <summary> The presenter of the <see cref="EditWindow"/> where all the logic happens. </summary>
        private readonly EditPresenter _presenter;

        /// <summary> The <see cref="_currentView"/> will get initialized on the constructor so we know how to treat the data. i.e when saving.</summary>
        private EditMode _currentView;

        #region --- View Interface Items ---

        /// <summary> Gets or sets the the selected index of <see cref="cbxTeams"/> ComboBox. </summary>
        public int TeamSelectedIndex
        {
            get => cbxTeams.SelectedIndex;
            set => cbxTeams.SelectedIndex = value;
        }

        /// <summary> Gets text of the <see cref="tbxName"/> TextBox text to edit Team or Player name. </summary>
        public string NameText => tbxName.Text;

        /// <summary> Gets the <see cref="Team"/> that has been passed from the parent window. </summary>
        public Team Team { get; }

        /// <summary> Gets the <see cref="Player"/> that has been passed from the parent window. </summary>
        public Player Player { get; }

        /// <summary> Gets the items from the <see cref="cbxTeams"/> ComboBox. </summary>
        public ComboBox.ObjectCollection TeamsComboBox => cbxTeams.Items;

        #endregion --- View Interface Items ---




        /// <summary> 
        /// <see cref="EditWindow"/> constructor will pass it's own instance to the presenter and modify it's own view depending on 
        /// the <see cref="EditMode"/> that has been passed to it by the parent window in the <see cref="InitializeComponentExtend"/>.
        /// </summary>
        public EditWindow(EditMode editMode, Team team, Player player)
        {
            Team = team;
            Player = player;
            InitializeComponent();
            _presenter = new EditPresenter(this);

            InitializeComponentExtend(editMode);
        }



        /// <summary>
        /// <see cref="InitializeComponentExtend"/> will modify the view depending on the <see cref="EditMode"/> that's passed from the
        /// parent window to the constructor.
        /// </summary>
        /// <param name="editMode"></param>
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
                    _presenter.BindTeamsData();
                    break;

                case EditMode.PlayerCreate:
                    _currentView = EditMode.PlayerCreate;
                    Text = "Player Create";
                    _presenter.BindTeamsData();
                    break;

                case EditMode.PlayerAssignToTeam:
                    _currentView = EditMode.PlayerAssignToTeam;
                    tbxName.ReadOnly = true;
                    tbxName.Enabled = false;
                    Text = "Assign Player to Team";
                    tbxName.Text = Player.Name;
                    _presenter.BindTeamsData();
                    break;
            }
        }

        /// <summary>
        /// The event of what happens when the Save button is clicked.
        /// The save behavior is dependeding on the <see cref="_currentView"/> of the <see cref="EditMode"/> that got
        /// initialized on the constructor.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
                        new UnsignedPlayersWindow().ShowDialog();
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

        /// <summary>
        /// Terminates the <see cref="EditWindow"/> without modifying anything.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// When this window is closed, which considered as Dialog or ChildForm, the presenter will invoke the
        /// event that will tell the parent window to update it's data since we finished editing in this case.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EditWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            _presenter.WindowClosed();
        }

    }
}
