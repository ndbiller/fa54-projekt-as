using System.Windows.Forms;

namespace TeamManager.Views.Interfaces
{
    /// <summary>
    /// The <see cref="IAllPlayersView"/> interface which the <see cref="Windows.Dialogs.AllPlayersWindow"/> 
    /// implements in order to expose properties to the presenter using the MVP pattern.
    /// </summary>
    public interface IAllPlayersView
    {
        /// <summary> Gets or sets the the selected index of players ListBox. </summary>
        int PlayerSelectedIndex { get; set; }

        /// <summary> Gets or sets the team TextBox text. </summary>
        string TeamNameText { get; set; }

        /// <summary> Gets or sets the player name TextBox text. </summary>
        string PlayerNameText { get; set; }

        /// <summary> Gets the items from the players ListBox. </summary>
        ListBox.ObjectCollection PlayersListBox { get; }
    }
}
