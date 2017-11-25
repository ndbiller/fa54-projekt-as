using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms.Custom;
using TeamManager.Presenters;
using TeamManager.Views.Enums;
using TeamManager.Views.Interfaces;

namespace TeamManager.Views.Forms.ChildForms
{
    public partial class AllPlayersForm : CustomForm, IAllPlayersView
    {
        private AllPlayersPresenter presenter;

        public AllPlayersForm()
        {
            InitializeComponent();
            presenter = new AllPlayersPresenter(this);
        }

        private void btnPDelete_Click(object sender, EventArgs e)
        {
            presenter.DeletePlayer();
        }

        private void lbxPlayers_SelectedIndexChanged(object sender, EventArgs e)
        {
            presenter.UpdateView(lbxPlayers.Text);
        }

        #region ------------------- Show Dialogs -------------------
        private void btnPEdit_Click(object sender, EventArgs e)
        {
            new EditForm(ViewType.PlayerEdit).ShowDialog();
        }

        private void btnPCreate_Click(object sender, EventArgs e)
        {
            new EditForm(ViewType.PlayerCreate).ShowDialog();
        }
        #endregion -------------- Show Dialogs -------------------

        public int SelectedPlayerIndex
        {
            get => lbxPlayers.SelectedIndex;
            set => lbxPlayers.SelectedIndex = value;
        }

        public string PlayerNameText
        {
            get => tbxName.Text;
            set => tbxName.Text = value;
        }

        public string TeamNameText
        {
            get => tbxTeam.Text;
            set => tbxTeam.Text = value;
        }

        public List<string> ListBoxPlayers
        {
            get => lbxPlayers.Items.Cast<string>().ToList();
            set => lbxPlayers.DataSource = value;
        }


    }
}
