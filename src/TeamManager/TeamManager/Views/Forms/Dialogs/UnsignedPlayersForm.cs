using System;
using System.Windows.Forms;
using System.Windows.Forms.Custom;
using TeamManager.Models.ResourceData;
using TeamManager.Presenters;
using TeamManager.Views.Enums;
using TeamManager.Views.Interfaces;

namespace TeamManager.Views.Forms.Dialogs
{
    public partial class UnsignedPlayersForm : CustomForm, IUnsignedPlayersView
    {

        #region --- View Interface Items ---

        public int PlayerSelectedIndex
        {
            get => lbxPlayers.SelectedIndex;
            set => lbxPlayers.SelectedIndex = value;
        }

        public ListBox.ObjectCollection PlayersListBox => lbxPlayers.Items;

        #endregion --- View Interface Items ---

        private readonly UnsignedPlayersPresenter _presenter;



        public UnsignedPlayersForm()
        {
            InitializeComponent();
            _presenter = new UnsignedPlayersPresenter(this);
            _presenter.BindPlayersData();
        }

        private void btnPDelete_Click(object sender, EventArgs e)
        {
            _presenter.DeletePlayer();
        }

        private void UnsignedPlayersForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            _presenter.FormClosed();
        }


        #region --- Show Dialogs ---

        private void btnPAddToTeam_Click(object sender, EventArgs e)
        {
            Player player = _presenter.GetPlayer();
            if (player == null) return;

            new EditForm(EditMode.PlayerAssignToTeam, null, player).ShowDialog();
        }

        private void btnPCreate_Click(object sender, EventArgs e)
        {
            new EditForm(EditMode.PlayerCreate, null, null).ShowDialog();
        }

        #endregion --- Show Dialogs ---

    }
}
