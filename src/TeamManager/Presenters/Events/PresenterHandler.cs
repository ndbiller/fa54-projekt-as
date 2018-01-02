

namespace TeamManager.Presenters.Events
{
    /// <summary>
    /// Used for creating an event invocation when a child window closes.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public delegate void PresenterHandler(object sender, PresenterArgs e);
}
