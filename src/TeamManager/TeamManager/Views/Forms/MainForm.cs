using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.Custom;
using TeamManager.Models.ResourceData;
using TeamManager.Presenters;
using TeamManager.Views.Enums;
using TeamManager.Views.Forms.ChildForms;
using TeamManager.Views.Interfaces;

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
            get => tbxSearch.TextS;
            set => tbxSearch.TextS = value;
        }

        public ListBox.ObjectCollection TeamsListBox => lbxTeams.Items;

        public ListBox.ObjectCollection PlayersListBox => lbxPlayers.Items;

        #endregion --- View Interface Items ---


        private MainPresenter presenter;



        public MainForm()
        {
            InitializeComponent();
            presenter = new MainPresenter(this);
            presenter.BindTeamsData();

            // Small issue with tbxSearch in panels when losing focus size increases once. this resolves it.
            tbxSearch.Focus();
            lbxTeams.Focus();
            tbxSearch.Size = new Size(95, 30);

            tbxSearch.GotFocus += delegate { searchTimer.Start(); };
            tbxSearch.Leave += delegate { searchTimer.Stop(); };
            rbnTeams.CheckedChanged += delegate
            {
                tbxSearch.TextS = string.Empty;
                tbxSearch.Focus();
            };
        }


        private void searchTimer_Tick(object sender, EventArgs e)
        {
            presenter.Search(tbxSearch, rbnTeams.Checked);
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
            Team team = presenter.GetSelectedTeam();
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
