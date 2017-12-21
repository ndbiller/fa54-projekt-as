namespace TeamManager.Views.Enums
{
    /// <summary>
    /// The <see cref="WindowType"/> enum main purpose is to define in the <see cref="Presenters.Events.PresenterArgs"/> 
    /// which child window/form is just closed when the <see cref="Presenters.Events.PresenterHandler"/> gets invoked.
    /// </summary>
    public enum WindowType
    {
        /// <summary>The <see cref="Windows.MainWindow"/> definition. </summary>
        Main,

        /// <summary>The <see cref="Windows.Dialogs.EditWindow"/> definition. </summary>
        Edit,

        /// <summary>The <see cref="Windows.Dialogs.AllPlayersWindow"/> definition. </summary>
        AllPlayers,

        /// <summary>The <see cref="Windows.Dialogs.UnsignedPlayersWindow"/> definition. </summary>
        UnsignedPlayers
    }
}
