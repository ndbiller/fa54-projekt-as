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

namespace TeamManager.Forms.ChildForms
{
    public partial class AllPlayersForm : CustomForm
    {
        public AllPlayersForm()
        {
            InitializeComponent();
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
            tbxName.Text = lbxPlayers.Text;
            tbxTeam.Text = "0xFFFFFF";
        }
    }
}
