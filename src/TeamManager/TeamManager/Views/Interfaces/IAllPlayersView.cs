using System.Windows.Forms;

namespace TeamManager.Views.Interfaces
{
    public interface IAllPlayersView
    {
        int PlayerSelectedIndex { get; set; }
        string TeamNameText { get; set; }
        string PlayerNameText { get; set; }
        ListBox.ObjectCollection PlayersListBox { get; }
    }
}
