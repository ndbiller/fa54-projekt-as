using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamManager.Views.Interfaces;

namespace TeamManager.Presenters
{
    public class AllPlayersPresenter : BasePresenter
    {
        private IAllPlayersView allPlayersView;

        public AllPlayersPresenter(IAllPlayersView allPlayersView)
        {
            this.allPlayersView = allPlayersView;
        }
    }
}
