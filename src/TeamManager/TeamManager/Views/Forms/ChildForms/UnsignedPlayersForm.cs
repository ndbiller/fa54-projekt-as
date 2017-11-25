using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.Custom;
using TeamManager.Models.ResourceData;
using TeamManager.Presenters;
using TeamManager.Views.Enums;
using TeamManager.Views.Interfaces;

namespace TeamManager.Views.Forms.ChildForms
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

        private UnsignedPlayersPresenter presenter;



        public UnsignedPlayersForm()
        {
            InitializeComponent();
            presenter = new UnsignedPlayersPresenter(this);
            presenter.BindPlayersData();
        }

        private void btnPDelete_Click(object sender, EventArgs e)
        {
            presenter.DeletePlayer();
        }

        private void UnsignedPlayersForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            presenter.FormClosed();
        }


        #region --- Show Dialogs ---

        private void btnPAddToTeam_Click(object sender, EventArgs e)
        {
            new EditForm(EditMode.PlayerAssignToTeam).ShowDialog();
        }

        private void btnPCreate_Click(object sender, EventArgs e)
        {
            new EditForm(EditMode.PlayerCreate).ShowDialog();
        }

        #endregion --- Show Dialogs ---
    }
}
