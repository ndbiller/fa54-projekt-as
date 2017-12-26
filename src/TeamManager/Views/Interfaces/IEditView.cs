using System.Windows.Forms;
using TeamManager.Models.ResourceData;

namespace TeamManager.Views.Interfaces
{
    /// <summary>
    /// The <see cref="IEditView"/> interface which the <see cref="Windows.Dialogs.EditWindow"/> 
    /// implements in order to expose properties to the presenter using the MVP pattern.
    /// </summary>
    public interface IEditView
    {
        /// <summary> Gets or sets the the selected index of teams ComboBox. </summary>
        int TeamSelectedIndex { get; set; }

        /// <summary> Gets text of the name TextBox text to edit Team or Player name. </summary>
        string NameText { get; }

        /// <summary> Gets the <see cref="Team"/> that has been passed from the parent window. </summary>
        Team Team { get; }

        /// <summary> Gets the <see cref="Player"/> that has been passed from the parent window. </summary>
        Player Player { get; }

        /// <summary> Gets the items from the teams ComboBox. </summary>
        ComboBox.ObjectCollection TeamsComboBox { get; }
    }
}
