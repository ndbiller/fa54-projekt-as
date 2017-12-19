using System.Windows.Forms;

namespace TeamManager.Views.Interfaces
{
    public interface IMainView
    {
        int TeamSelectedIndex { get; set; }
        int PlayerSelectedIndex { get; set; }
        string SearchText { get; set; }
        ListBox.ObjectCollection TeamsListBox { get; }
        ListBox.ObjectCollection PlayersListBox { get; }
    }
}
