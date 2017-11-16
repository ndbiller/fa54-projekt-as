using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
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

        private void btnPDelete_Click(object sender, EventArgs e)
        {
            presenter.DeletePlayer();
        }

        private void btnTDelete_Click(object sender, EventArgs e)
        {
            presenter.DeleteTeam();
        }

        private void lbxTeams_SelectedIndexChanged(object sender, EventArgs e)
        {
            presenter.BindPlayersData();
        }



        #region ------------------- Show Dialogs -------------------
        private void btnUnsignedPlayers_Click(object sender, EventArgs e)
        {
            new UnsignedPlayersForm().ShowDialog();
        }

        private void btnShowAllPlayers_Click(object sender, EventArgs e)
        {
            new AllPlayersForm().ShowDialog();
        }

        private void btnPEdit_Click(object sender, EventArgs e)
        {
            new EditForm(ViewType.PlayerEdit).ShowDialog();
        }

        private void btnPCreate_Click(object sender, EventArgs e)
        {
            new EditForm(ViewType.PlayerCreate).ShowDialog();
        }

        private void btnTEdit_Click(object sender, EventArgs e)
        {
            new EditForm(ViewType.TeamEdit).ShowDialog();
        }

        private void btnTCreate_Click(object sender, EventArgs e)
        {
            new EditForm(ViewType.TeamCreate).ShowDialog();
        }
        #endregion -------------- Show Dialogs -------------------

        public string SearchText
        {
            get => tbxSearch.TextS;
            set => tbxSearch.TextS = value;
        }

        public List<string> ListBoxTeams
        {
            get => lbxTeams.Items.Cast<string>().ToList();
            set => lbxTeams.DataSource = value;
        }

        public List<string> ListBoxPlayers
        {
            get => lbxPlayers.Items.Cast<string>().ToList();
            set => lbxPlayers.DataSource = value;
        }

    }
}
