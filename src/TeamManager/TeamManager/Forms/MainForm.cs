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
using TeamManager.Properties;
using TeamManager.Forms.ChildForms;


namespace TeamManager.Forms
{
    public partial class MainForm : CustomForm
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            // TODO: Implement search behavior.
            if (tbxSearch.TextS == tbxSearch.TextSearch)
                tbxSearch.Focus();

        }

        private void btnPDelete_Click(object sender, EventArgs e)
        {
            // TODO: Implement delete player.
        }

        private void btnTDelete_Click(object sender, EventArgs e)
        {
            // TODO: Implement delete team.
        }

        private void lbxTeams_SelectedIndexChanged(object sender, EventArgs e)
        {
            // TODO: Display players of the selected team.
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

    }
}
