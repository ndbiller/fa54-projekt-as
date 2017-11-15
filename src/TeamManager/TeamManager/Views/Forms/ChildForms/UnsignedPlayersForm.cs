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
using TeamManager.Views.Enums;

namespace TeamManager.Views.Forms.ChildForms
{
    public partial class UnsignedPlayersForm : CustomForm
    {
        public UnsignedPlayersForm()
        {
            InitializeComponent();
        }

        private void btnPDelete_Click(object sender, EventArgs e)
        {

        }

        #region ------------------- Show Dialogs -------------------
        private void btnPAddToTeam_Click(object sender, EventArgs e)
        {
            new EditForm(ViewType.PlayerAssignToTeam).ShowDialog();
        }

        private void btnPCreate_Click(object sender, EventArgs e)
        {
            new EditForm(ViewType.PlayerCreate).ShowDialog();
        }
        #endregion -------------- Show Dialogs -------------------

    }
}
