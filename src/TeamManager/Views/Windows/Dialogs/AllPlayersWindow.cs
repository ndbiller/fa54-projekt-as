using System;
using System.Windows.Forms;
using System.Windows.Forms.Custom;
using TeamManager.Models.ResourceData;
using TeamManager.Presenters;
using TeamManager.Utilities;
using TeamManager.Views.Enums;
using TeamManager.Views.Interfaces;
using TeamManager.Views.Loader;

namespace TeamManager.Views.Windows.Dialogs
{
    public partial class AllPlayersWindow : CustomForm, IAllPlayersView
    {
        /// <summary> The presenter of the <see cref="AllPlayersWindow"/> where all the logic happens. </summary>
        private readonly AllPlayersPresenter _presenter;

        #region --- View Interface Items ---

        /// <summary> Gets or sets the the selected index of <see cref="lbxPlayers"/> ListBox. </summary>
        public int PlayerSelectedIndex
        {
            get => lbxPlayers.SelectedIndex;
            set => lbxPlayers.SelectedIndex = value;
        }

        /// <summary> Gets or sets the <see cref="tbxTeam"/> TextBox text. </summary>
        public string TeamNameText
        {
            get => tbxTeam.Text;
            set => tbxTeam.Text = value;
        }

        /// <summary> Gets or sets the <see cref="tbxName"/> TextBox text. </summary>
        public string PlayerNameText
        {
            get => tbxName.Text;
            set => tbxName.Text = value;
        }

        /// <summary> Gets the items from the <see cref="lbxPlayers"/> ListBox. </summary>
        public ListBox.ObjectCollection PlayersListBox => lbxPlayers.Items;

        #endregion --- View Interface Items ---


        

        /// <summary> 
        /// <see cref="AllPlayersWindow"/> constructor will pass it's own instance to the presenter and initialize the 
        /// players into the <see cref="lbxPlayers"/> ListBox. 
        /// </summary>
        public AllPlayersWindow()
        {
            Loaders.StartLoader(LoaderType.Loader, 750);

            InitializeComponent();
            _presenter = new AllPlayersPresenter(this);
            _presenter.BindPlayersData();

            Loaders.StopLoader(Handle);
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
        /// Updates the view every time a different player is selected from the <see cref="lbxPlayers"/> ListBox and displays
        /// the name of the player and his team on the right side.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lbxPlayers_SelectedIndexChanged(object sender, EventArgs e)
        {
            _presenter.UpdateView();
        }

        /// <summary>
        /// When this window is closed, which considered as Dialog or ChildForm, the presenter will invoke the
        /// event that will tell the parent window to update it's data.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AllPlayersWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            _presenter.WindowClosed();
            Owner?.Activate();
        }


        #region --- Show Dialogs ---

        /// <summary>
        /// Displays the <see cref="EditWindow"/> to edit the selected player.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPEdit_Click(object sender, EventArgs e)
        {
            Tuple<Team, Player> teamAndPlayer = _presenter.GetTeamAndPlayer();
            if (teamAndPlayer == null || teamAndPlayer.ContainsNull()) return;

            new EditWindow(EditMode.PlayerEdit, teamAndPlayer.Item1, teamAndPlayer.Item2).ShowDialog(this);
        }

        /// <summary>
        /// Displays the <see cref="EditWindow"/> to create a new player.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPCreate_Click(object sender, EventArgs e)
        {
            new EditWindow(EditMode.PlayerCreate, null, null).ShowDialog(this);
        }

        #endregion --- Show Dialogs ---

    }
}
