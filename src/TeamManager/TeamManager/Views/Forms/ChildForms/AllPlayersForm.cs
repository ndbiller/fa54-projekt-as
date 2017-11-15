using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void btnPEdit_Click(object sender, EventArgs e)
        {
            new EditForm(ViewType.PlayerEdit).ShowDialog();
        }

        private void btnPCreate_Click(object sender, EventArgs e)
        {
            new EditForm(ViewType.PlayerCreate).ShowDialog();
        }

        private void lbxPlayers_SelectedIndexChanged(object sender, EventArgs e)
        {
            presenter.UpdateView(lbxPlayers.Text);
        }

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
