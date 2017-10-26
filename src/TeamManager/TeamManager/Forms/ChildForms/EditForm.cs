using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Custom;

namespace TeamManager.Forms.ChildForms
{
    public partial class EditForm : CustomForm
    {
        private ViewType currentView;

        public EditForm(ViewType viewType)
        {
            InitializeComponent();
            InitializeComponentExtend(viewType);
        }

        private void InitializeComponentExtend(ViewType viewType)
        {
            switch (viewType)
            {
                case ViewType.TeamCreate:
                    currentView = ViewType.TeamCreate;
                    lbTeam.Hide();
                    cbxTeams.Hide();
                    Text = "Team Create";
                    break;

                case ViewType.TeamEdit:
                    currentView = ViewType.TeamEdit;
                    lbTeam.Hide();
                    cbxTeams.Hide();
                    Text = "Team Edit";
                    break;

                case ViewType.PlayerEdit:
                    currentView = ViewType.PlayerEdit;
                    Text = "Player Edit";
                    // TODO: Display player name in textbox and teams list.

                    break;

                case ViewType.PlayerCreate:
                    currentView = ViewType.PlayerCreate;
                    Text = "Player Create";
                    // TODO: Display teams list.

                    break;

                case ViewType.PlayerAssignToTeam:
                    currentView = ViewType.PlayerAssignToTeam;
                    tbxName.ReadOnly = true;
                    tbxName.Enabled = false;
                    Text = "Assign Player to Team";
                    // TODO: Display player name and teams list.

                    break;
            }
        }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // TODO: Implement save.
            switch (currentView)
            {
                case ViewType.TeamCreate:
                    new UnsignedPlayersForm().ShowDialog();
                    break;
                case ViewType.TeamEdit:
                    break;
                case ViewType.PlayerEdit:
                    break;
                case ViewType.PlayerCreate:
                    break;
                case ViewType.PlayerAssignToTeam:
                    break;

            }

            Close();
        }
    }
}
