using System;
using TeamManager.Views.Enums;

namespace TeamManager.Presenters.Events
{
    public class PresenterArgs : EventArgs
    {
        public WindowType Child { get; }


        public PresenterArgs(WindowType child)
        {
            Child = child;
        }
    }
}
