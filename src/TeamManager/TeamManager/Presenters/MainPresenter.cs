using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamManager.Views.Interfaces;

namespace TeamManager.Presenters
{
    public class MainPresenter : BasePresenter
    {
        private IMainView mainView;

        public MainPresenter(IMainView mainView)
        {
            this.mainView = mainView;
        }
    }
}
