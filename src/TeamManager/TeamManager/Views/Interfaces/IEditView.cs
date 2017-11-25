using System.Windows.Forms;
using TeamManager.Models.ResourceData;

namespace TeamManager.Views.Interfaces
{
    public interface IEditView
    {
        int TeamSelectedIndex { get; set; }
        string NameText { get; }
        Team Team { get; }
        Player Player { get; }
        ComboBox.ObjectCollection TeamsComboBox { get; }
    }
}
