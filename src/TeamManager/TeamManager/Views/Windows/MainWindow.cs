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
    public partial class MainWindow : CustomForm, IMainView
    {

        #region --- View Interface Items ---

        public int TeamSelectedIndex
        {
            get => lbxTeams.SelectedIndex;
            set => lbxTeams.SelectedIndex = value;
        }

        public int PlayerSelectedIndex
        {
            get => lbxPlayers.SelectedIndex;
            set => lbxPlayers.SelectedIndex = value;
        }

        public string SearchText
        {
            get => tbxSearch.Text;
            set => tbxSearch.Text = value;
        }

        public ListBox.ObjectCollection TeamsListBox => lbxTeams.Items;

        public ListBox.ObjectCollection PlayersListBox => lbxPlayers.Items;

        #endregion --- View Interface Items ---


        private readonly MainPresenter _presenter;



        public MainWindow()
        {
            Loaders.StartLoader(LoaderType.Loader, 0);

            InitializeComponent();
            _presenter = new MainPresenter(this);
            _presenter.BindTeamsData();

            Loaders.StopLoader(Handle);
        }


        private void tbxSearch_TextChanged(object sender, EventArgs e)
        {
            _presenter.Search(tbxSearch.Text, tbxSearch.TextSearch, rbnTeams.Checked);
        }

        private void rbnTeams_CheckedChanged(object sender, EventArgs e)
        {
            tbxSearch.Text = string.Empty;
            tbxSearch.Focus();
        }

        private void lbxTeams_SelectedIndexChanged(object sender, EventArgs e)
        {
            _presenter.BindPlayersData();
        }

        private void btnTDelete_Click(object sender, EventArgs e)
        {
            _presenter.DeleteTeam();
        }

        private void btnPDelete_Click(object sender, EventArgs e)
        {
            _presenter.DeletePlayer();
        }



        #region --- Show Dialogs ---

        private void btnUnsignedPlayers_Click(object sender, EventArgs e)
        {
            new UnsignedPlayersWindow().ShowDialog();
        }

        private void btnShowAllPlayers_Click(object sender, EventArgs e)
        {
            new AllPlayersWindow().ShowDialog();
        }

        private void btnTCreate_Click(object sender, EventArgs e)
        {
            new EditWindow(EditMode.TeamCreate, null, null).ShowDialog();
        }

        private void btnPCreate_Click(object sender, EventArgs e)
        {
            Team team = _presenter.GetSelectedTeam();
            if (team == null) return;

            new EditWindow(EditMode.PlayerCreate, team, null).ShowDialog();
        }

        private void btnTEdit_Click(object sender, EventArgs e)
        {
            Team team = _presenter.GetSelectedTeam();
            if (team == null) return;

            new EditWindow(EditMode.TeamEdit, team, null).ShowDialog();
        }

        private void btnPEdit_Click(object sender, EventArgs e)
        {
            Tuple<Team, Player> teamAndPlayer = _presenter.GetSelectedTeamAndPlayer();
            if (teamAndPlayer == null || teamAndPlayer.ContainsNull()) return;

            new EditWindow(EditMode.PlayerEdit, teamAndPlayer.Item1, teamAndPlayer.Item2).ShowDialog();
        }

        #endregion --- Show Dialogs ---

    }
}
