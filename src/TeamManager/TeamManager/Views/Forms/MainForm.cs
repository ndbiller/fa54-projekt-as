using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.Custom;
using TeamManager.Presenters;
using TeamManager.Views.Enums;
using TeamManager.Views.Forms.ChildForms;
using TeamManager.Views.Interfaces;

namespace TeamManager.Views.Forms
{
    public partial class MainForm : CustomForm, IMainView
    {
        private MainPresenter presenter;

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




        public MainForm()
        {
            InitializeComponent();
            presenter = new MainPresenter(this);
            presenter.BindTeamsData();
            presenter.BindPlayersData();
        }


        private void btnSearch_Click(object sender, EventArgs e)
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
            new EditForm(ViewType.TeamCreate).ShowDialog();
        }

        private void btnPCreate_Click(object sender, EventArgs e)
        {
            new EditForm(ViewType.PlayerCreate).ShowDialog();
        }

        private void btnTEdit_Click(object sender, EventArgs e)
        {
            new EditForm(ViewType.TeamEdit).ShowDialog();
        }

        private void btnPEdit_Click(object sender, EventArgs e)
        {
            new EditForm(ViewType.PlayerEdit).ShowDialog();
        }

        #endregion --- Show Dialogs ---

    }
}
