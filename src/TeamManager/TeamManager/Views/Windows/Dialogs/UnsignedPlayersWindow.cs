using System;
using System.Windows.Forms;
using System.Windows.Forms.Custom;
using TeamManager.Models.ResourceData;
using TeamManager.Presenters;
using TeamManager.Views.Enums;
using TeamManager.Views.Interfaces;

namespace TeamManager.Views.Windows.Dialogs
{
    public partial class UnsignedPlayersWindow : CustomForm, IUnsignedPlayersView
    {
        /// <summary> The presenter of the <see cref="UnsignedPlayersWindow"/> where all the logic happens. </summary>
        private readonly UnsignedPlayersPresenter _presenter;

        #region --- View Interface Items ---

        /// <summary> Gets or sets the the selected index of <see cref="lbxPlayers"/> ListBox. </summary>
        public int PlayerSelectedIndex
        {
            get => lbxPlayers.SelectedIndex;
            set => lbxPlayers.SelectedIndex = value;
        }

        /// <summary> Gets the items from the <see cref="lbxPlayers"/> ListBox. </summary>
        public ListBox.ObjectCollection PlayersListBox => lbxPlayers.Items;

        #endregion --- View Interface Items ---




        /// <summary> 
        /// <see cref="UnsignedPlayersWindow"/> constructor will pass it's own instance to the presenter and initialize the 
        /// players into the <see cref="lbxPlayers"/> ListBox. 
        /// </summary>
        public UnsignedPlayersWindow()
        {
            InitializeComponent();
            _presenter = new UnsignedPlayersPresenter(this);
            _presenter.BindPlayersData();
        }



        /// <summary>
        /// Deletes the selected player.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPDelete_Click(object sender, EventArgs e)
        {
            _presenter.DeletePlayer();
        }

        /// <summary>
        /// When this window is closed, which considered as Dialog or ChildForm, the presenter will invoke the
        /// event that will tell the parent window to update it's data.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UnsignedPlayersForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            _presenter.WindowClosed();
        }


        #region --- Show Dialogs ---

        /// <summary>
        /// Displays the <see cref="EditWindow"/> to add the selected unsigned player to a team.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPAddToTeam_Click(object sender, EventArgs e)
        {
            Player player = _presenter.GetPlayer();
            if (player == null) return;

            new EditWindow(EditMode.PlayerAssignToTeam, null, player).ShowDialog();
        }

        /// <summary>
        /// Displays the <see cref="EditWindow"/> to create a new player.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPCreate_Click(object sender, EventArgs e)
        {
            new EditWindow(EditMode.PlayerCreate, null, null).ShowDialog();
        }

        #endregion --- Show Dialogs ---

    }
}
