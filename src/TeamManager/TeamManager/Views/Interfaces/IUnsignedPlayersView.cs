using System.Windows.Forms;

namespace TeamManager.Views.Interfaces
{
    public interface IUnsignedPlayersView
    {
        int PlayerSelectedIndex { get; set; }
        ListBox.ObjectCollection PlayersListBox { get; }
    }
}
