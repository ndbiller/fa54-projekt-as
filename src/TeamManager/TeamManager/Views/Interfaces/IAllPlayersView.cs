using System.Collections.Generic;

namespace TeamManager.Views.Interfaces
{
    public interface IAllPlayersView
    {
        int SelectedPlayerIndex { get; set; }
        string PlayerNameText { get; set; }
        string TeamNameText { get; set; }
        List<string> ListBoxPlayers { get; set; }
    }
}
