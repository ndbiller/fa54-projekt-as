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
    public partial class UnsignedPlayersForm : CustomForm, IUnsignedPlayersView
    {
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

        public List<string> ListBoxPlayers
        {
            get => lbxPlayers.Items.Cast<string>().ToList();
            set => lbxPlayers.DataSource = value;
        }
    }
}
