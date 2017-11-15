using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamManager.Views.Interfaces
{
    public interface IMainView
    {
        string SearchText { get; set; }
        List<string> ListBoxTeams { get; set; }
        List<string> ListBoxPlayers { get; set; }
    }
}
