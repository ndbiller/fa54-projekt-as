using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamManager.Models.ResourceData;
using TeamManager.Views.Interfaces;

namespace TeamManager.Presenters
{
    /// <summary>
    /// The console presenter will be used differently in comparsion to UI presenters.
    /// In here we will implement methods without a view coupling, that the console 
    /// will be using directly in order to try sticking to the MVP pattern.
    /// </summary>
    public class ConsolePresenter : BasePresenter
    {
        public List<Team> AllTeams()
        {
            throw new NotImplementedException();
        }

        public List<Player> AllPlayers()
        {
            throw new NotImplementedException();
        }

        public void CreateNewTeam()
        {
            throw new NotImplementedException();
        }

        public void CreateNewPlayer()
        {
            throw new NotImplementedException();
        }

        public void EditTeam()
        {
            throw new NotImplementedException();
        }

        public void EditPlayer()
        {
            throw new NotImplementedException();
        }

        public void DeleteTeam()
        {
            throw new NotImplementedException();
        }

        public void DeletePlayer()
        {
            throw new NotImplementedException();
        }

        public void ShowUnsignedPlayers()
        {
            throw new NotImplementedException();
        }

        public void Close()
        {
            throw new NotImplementedException();
        }

        public void PrintMenu()
        {
            Console.Clear();
            Console.WriteLine("         TEAM-MANAGER-SYSTEM            \n" +
                              "========================================\n" +
                              "    Show Teams            \t(a)         \n" +
                              "    New Team              \t(b)         \n" +
                              "    Edit Team             \t(c)         \n" +
                              "    Delete Team           \t(d)         \n" +
                              "========================================\n" +
                              "    Show Players          \t(e)         \n" +
                              "    New Player            \t(f)         \n" +
                              "    Edit Player           \t(g)         \n" +
                              "    Delete Player         \t(h)         \n" +
                              "========================================\n" +
                              "    Show Unsigned Players \t(i)         \n" +
                              "    Close                 \t(j)         \n");
        }
    }
}
