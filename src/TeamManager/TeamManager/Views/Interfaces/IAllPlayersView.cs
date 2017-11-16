using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
