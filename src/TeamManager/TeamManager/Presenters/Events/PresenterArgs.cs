using System;
using TeamManager.Views.Enums;

namespace TeamManager.Presenters.Events
{
    public class PresenterArgs : EventArgs
    {
        private readonly FormType child;

        public FormType Child => child;


        public PresenterArgs(FormType child)
        {
            this.child = child;
        }
    }
}
