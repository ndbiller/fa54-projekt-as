using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamManager.Views.Interfaces;

namespace TeamManager.Presenters
{
    public class EditPresenter : BasePresenter
    {
        private IEditView editView;

        public EditPresenter(IEditView editView)
        {
            this.editView = editView;
        }
    }
}
