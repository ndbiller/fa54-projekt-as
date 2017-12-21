using System.Windows.Forms;

namespace TeamManager.Views.Interfaces
{
    /// <summary>
    /// The <see cref="IMainView"/> interface which the <see cref="Windows.MainWindow"/> implements in order to expose properties
    /// to the presenter using the MVP pattern.
    /// </summary>
    public interface IMainView
    {
        /// <summary> Gets or sets the the selected index of teams ListBox. </summary>
        int TeamSelectedIndex { get; set; }

        /// <summary> Gets or sets the the selected index of players ListBox. </summary>
        int PlayerSelectedIndex { get; set; }

        /// <summary> Gets or sets the text in the search TextBox. </summary>
        string SearchText { get; set; }

        /// <summary> Gets the items from the teams ListBox. </summary>
        ListBox.ObjectCollection TeamsListBox { get; }

        /// <summary> Gets the items from the players ListBox. </summary>
        ListBox.ObjectCollection PlayersListBox { get; }
    }
}
