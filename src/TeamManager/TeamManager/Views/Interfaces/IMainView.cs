using System.Collections.Generic;

namespace TeamManager.Views.Interfaces
{
    public interface IMainView
    {
        string SearchText { get; set; }
        List<string> ListBoxTeams { get; set; }
        List<string> ListBoxPlayers { get; set; }
    }
}
