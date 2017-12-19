using System;
using TeamManager.Views.Enums;

namespace TeamManager.Presenters.Events
{
    public class PresenterArgs : EventArgs
    {
        public FormType Child { get; }


        public PresenterArgs(FormType child)
        {
            Child = child;
        }
    }
}
