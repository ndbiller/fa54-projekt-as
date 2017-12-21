using System;
using System.Windows.Forms;
using System.Windows.Forms.Custom;
using TeamManager.Models.ResourceData;
using TeamManager.Presenters;
using TeamManager.Utilities;
using TeamManager.Views.Enums;
using TeamManager.Views.Interfaces;
using TeamManager.Views.Loader;
using TeamManager.Views.Windows.Dialogs;

namespace TeamManager.Views.Windows
{
    /// <summary>
    /// The <see cref="MainWindow"/> where the GUI starts which will display the teams and players and various of other options.
    /// </summary>
    public partial class MainWindow : CustomForm, IMainView
    {        
        /// <summary> The presenter of the <see cref="MainWindow"/> where all the logic happens. </summary>
        private readonly MainPresenter _presenter;

        #region --- View Interface Items ---

        /// <summary> Gets or sets the the selected index of <see cref="lbxTeams"/> ListBox. </summary>
        public int TeamSelectedIndex
        {
            get => lbxTeams.SelectedIndex;
            set => lbxTeams.SelectedIndex = value;
        }

        /// <summary> Gets or sets the the selected index of <see cref="lbxPlayers"/> ListBox. </summary>
        public int PlayerSelectedIndex
        {
            get => lbxPlayers.SelectedIndex;
            set => lbxPlayers.SelectedIndex = value;
        }

        /// <summary> Gets or sets the text in the <see cref="tbxSearch"/> TextBox. </summary>
        public string SearchText
        {
            get => tbxSearch.Text;
            set => tbxSearch.Text = value;
        }

        /// <summary> Gets the items from the <see cref="lbxTeams"/> ListBox. </summary>
        public ListBox.ObjectCollection TeamsListBox => lbxTeams.Items;

        /// <summary> Gets the items from the <see cref="lbxPlayers"/> ListBox. </summary>
        public ListBox.ObjectCollection PlayersListBox => lbxPlayers.Items;

        #endregion --- View Interface Items ---




        /// <summary> 
        /// <see cref="MainWindow"/> constructor will pass it's own instance to the presenter and initialize the 
        /// teams into the <see cref="lbxTeams"/> ListBox. 
        /// </summary>
        public MainWindow()
        {
            Loaders.StartLoader(LoaderType.Loader);

            InitializeComponent();
            _presenter = new MainPresenter(this);
            _presenter.BindTeamsData();

            Loaders.StopLoader(Handle);
        }


        /// <summary>
        /// The event to execute every time <see cref="tbxSearch"/> TextBox text will change and run search query to the database
        /// to filter for Teams or Player.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbxSearch_TextChanged(object sender, EventArgs e)
        {
            _presenter.Search(tbxSearch.Text, tbxSearch.TextSearch, rbnTeams.Checked);
        }

        /// <summary>
        /// Sets the focus to the <see cref="tbxSearch"/> TextBox every time a <see cref="rbnTeams"/> RadioButton checked changed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rbnTeams_CheckedChanged(object sender, EventArgs e)
        {
            tbxSearch.Text = string.Empty;
            tbxSearch.Focus();
        }

        /// <summary>
        /// Everytime the user selected a different team in the <see cref="lbxTeams"/> ListBox, it will initialize the team players
        /// of the selected team.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lbxTeams_SelectedIndexChanged(object sender, EventArgs e)
        {
            _presenter.BindPlayersData();
        }

        /// <summary>
        /// Deletes the selected team and move all its players into Unsigned Players.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTDelete_Click(object sender, EventArgs e)
        {
            _presenter.DeleteTeam();
        }

        /// <summary>
        /// Deletes the selected player from the team and moves to Unsigned Players.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPDelete_Click(object sender, EventArgs e)
        {
            _presenter.DeletePlayer();
        }



        #region --- Show Dialogs ---


        /// <summary>
        /// Displays the <see cref="UnsignedPlayersWindow"/> where it shows all players that aren't assigned to a team.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUnsignedPlayers_Click(object sender, EventArgs e)
        {
            new UnsignedPlayersWindow().ShowDialog();
        }

        /// <summary>
        /// Displays the <see cref="AllPlayersWindow"/>.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnShowAllPlayers_Click(object sender, EventArgs e)
        {
            new AllPlayersWindow().ShowDialog();
        }


        /// <summary>
        /// Displays the <see cref="EditWindow"/> to create a new team.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTCreate_Click(object sender, EventArgs e)
        {
            new EditWindow(EditMode.TeamCreate, null, null).ShowDialog();
        }

        /// <summary>
        /// Displays the <see cref="EditWindow"/> to create new player for the selected team.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPCreate_Click(object sender, EventArgs e)
        {
            Team team = _presenter.GetSelectedTeam();
            if (team == null) return;

            new EditWindow(EditMode.PlayerCreate, team, null).ShowDialog();
        }

        /// <summary>
        /// Displays the <see cref="EditWindow"/> to edit the selected team.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTEdit_Click(object sender, EventArgs e)
        {
            Team team = _presenter.GetSelectedTeam();
            if (team == null) return;

            new EditWindow(EditMode.TeamEdit, team, null).ShowDialog();
        }

        /// <summary>
        /// Displays the <see cref="EditWindow"/> to edit the selected player of a team.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPEdit_Click(object sender, EventArgs e)
        {
            Tuple<Team, Player> teamAndPlayer = _presenter.GetSelectedTeamAndPlayer();
            if (teamAndPlayer == null || teamAndPlayer.ContainsNull()) return;

            new EditWindow(EditMode.PlayerEdit, teamAndPlayer.Item1, teamAndPlayer.Item2).ShowDialog();
        }

        #endregion --- Show Dialogs ---

    }
}
