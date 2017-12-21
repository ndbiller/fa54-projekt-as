using System;
using TeamManager.Views.Enums;

namespace TeamManager.Presenters.Events
{
    /// <summary>
    /// The <see cref="PresenterArgs"/> class will contain some data that we're interested in when the <see cref="PresenterHandler"/> get invoked.
    /// </summary>
    public class PresenterArgs : EventArgs
    {
        /// <summary> Defines the window that invoked the <see cref="PresenterHandler"/>. </summary>
        public WindowType Child { get; }


        /// <summary>
        /// Initializes the <see cref="Child"/> member with its <see cref="WindowType"/>.
        /// </summary>
        /// <param name="child"></param>
        public PresenterArgs(WindowType child)
        {
            Child = child;
        }
    }
}
