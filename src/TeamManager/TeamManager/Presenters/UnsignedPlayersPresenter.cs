using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamManager.Views.Interfaces;

namespace TeamManager.Presenters
{
    public class UnsignedPlayersPresenter : BasePresenter
    {
        private IUnsignedPlayersView unsignedPlayersView;

        public UnsignedPlayersPresenter(IUnsignedPlayersView unsignedPlayersView)
        {
            this.unsignedPlayersView = unsignedPlayersView;
        }
    }
}
