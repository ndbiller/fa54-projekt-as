using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.Custom;
using TeamManager.Models.ResourceData;
using TeamManager.Presenters;
using TeamManager.Utilities;
using TeamManager.Views.Enums;
using TeamManager.Views.Interfaces;

namespace TeamManager.Views.Forms.Dialogs
{
    public partial class AllPlayersForm : CustomForm, IAllPlayersView
    {

        #region --- View Interface Items ---

        public int PlayerSelectedIndex
        {
            get => lbxPlayers.SelectedIndex;
            set => lbxPlayers.SelectedIndex = value;
        }

        public string TeamNameText
        {
            get => tbxTeam.Text;
            set => tbxTeam.Text = value;
        }

        public string PlayerNameText
        {
            get => tbxName.Text;
            set => tbxName.Text = value;
        }

        public ListBox.ObjectCollection PlayersListBox => lbxPlayers.Items;

        #endregion --- View Interface Items ---


        private readonly AllPlayersPresenter _presenter;



        public AllPlayersForm()
        {
            InitializeComponent();
            _presenter = new AllPlayersPresenter(this);
            _presenter.BindPlayersData();
        }

        private void btnPDelete_Click(object sender, EventArgs e)
        {
            _presenter.DeletePlayer();
        }

        private void lbxPlayers_SelectedIndexChanged(object sender, EventArgs e)
        {
            _presenter.UpdateView();
        }

        private void AllPlayersForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            _presenter.FormClosed();
        }


        #region --- Show Dialogs ---

        private void btnPEdit_Click(object sender, EventArgs e)
        {
            Tuple<Team, Player> teamAndPlayer = _presenter.GetTeamAndPlayer();
            if (teamAndPlayer == null || teamAndPlayer.ContainsNull()) return;

            new EditForm(EditMode.PlayerEdit, teamAndPlayer.Item1, teamAndPlayer.Item2).ShowDialog();
        }

        private void btnPCreate_Click(object sender, EventArgs e)
        {
            new EditForm(EditMode.PlayerCreate, null, null).ShowDialog();
        }

        #endregion --- Show Dialogs ---

    }
}
