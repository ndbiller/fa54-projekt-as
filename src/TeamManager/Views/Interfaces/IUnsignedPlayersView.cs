using System.Windows.Forms;

namespace TeamManager.Views.Interfaces
{
    /// <summary>
    /// The <see cref="IUnsignedPlayersView"/> interface which the <see cref="Windows.Dialogs.UnsignedPlayersWindow"/> 
    /// implements in order to expose properties to the presenter using the MVP pattern.
    /// </summary>
    public interface IUnsignedPlayersView
    {
        /// <summary> Gets or sets the the selected index of players ListBox. </summary>
        int PlayerSelectedIndex { get; set; }

        /// <summary> Gets the items from the players ListBox. </summary>
        ListBox.ObjectCollection PlayersListBox { get; }
    }
}
