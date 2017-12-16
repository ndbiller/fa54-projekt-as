using System;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.Custom;
using TeamManager.Models.ResourceData;
using TeamManager.Presenters;
using TeamManager.Views.Enums;
using TeamManager.Views.Forms.ChildForms;
using TeamManager.Views.Interfaces;
using TeamManager.Views.Loader;

namespace TeamManager.Views.Forms
{
    public partial class MainForm : CustomForm, IMainView
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


        private MainPresenter presenter;



        public MainForm()
        {
            Loaders.StartLoader(LoaderType.Loader, 0);

            InitializeComponent();
            presenter = new MainPresenter(this);
            presenter.BindTeamsData();

            Loaders.StopLoader(Handle);
        }


        private void tbxSearch_TextChanged(object sender, EventArgs e)
        {
            presenter.Search(tbxSearch.Text, tbxSearch.TextSearch, rbnTeams.Checked);
        }

        private void rbnTeams_CheckedChanged(object sender, EventArgs e)
        {
            tbxSearch.Text = string.Empty;
            tbxSearch.Focus();
        }

        private void lbxTeams_SelectedIndexChanged(object sender, EventArgs e)
        {
            presenter.BindPlayersData();
        }

        private void btnTDelete_Click(object sender, EventArgs e)
        {
            presenter.DeleteTeam();
        }

        private void btnPDelete_Click(object sender, EventArgs e)
        {
            presenter.DeletePlayer();
        }



        #region --- Show Dialogs ---

        private void btnUnsignedPlayers_Click(object sender, EventArgs e)
        {
            new UnsignedPlayersForm().ShowDialog();
        }

        private void btnShowAllPlayers_Click(object sender, EventArgs e)
        {
            new AllPlayersForm().ShowDialog();
        }

        private void btnTCreate_Click(object sender, EventArgs e)
        {
            new EditForm(EditMode.TeamCreate, null, null).ShowDialog();
        }

        private void btnPCreate_Click(object sender, EventArgs e)
        {
            Team team = TeamsListBox[TeamSelectedIndex] as Team;
            if (TeamsListBox.Count == 0) return;

            new EditForm(EditMode.PlayerCreate, team, null).ShowDialog();
        }

        private void btnTEdit_Click(object sender, EventArgs e)
        {
            Team team = presenter.GetSelectedTeam();
            if (TeamsListBox.Count == 0 && team == null) return;

            new EditForm(EditMode.TeamEdit, team, null).ShowDialog();
        }

        private void btnPEdit_Click(object sender, EventArgs e)
        {
            Tuple<Team, Player> teamAndPlayer = presenter.GetSelectedPlayerAndTeam();
            if (PlayersListBox.Count == 0 && teamAndPlayer.Item2 == null) return;

            new EditForm(EditMode.PlayerEdit, teamAndPlayer.Item1, teamAndPlayer.Item2).ShowDialog();
        }

        #endregion --- Show Dialogs ---

    }
}
