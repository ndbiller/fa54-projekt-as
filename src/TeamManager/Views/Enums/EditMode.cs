namespace TeamManager.Views.Enums
{
    /// <summary>
    /// The <see cref="EditMode"/> enum main purpose is to define in which mode we want to display the 
    /// <see cref="Windows.Dialogs.EditWindow"/> so it knows how to display the view or treat the data.
    /// </summary>
    public enum EditMode
    {
        /// <summary> Creates new team. </summary>
        TeamCreate,

        /// <summary> Edits team. </summary>
        TeamEdit,

        /// <summary> Creates new player. </summary>
        PlayerCreate,

        /// <summary> Edits team. </summary>
        PlayerEdit,

        /// <summary> Assigns player to a team. </summary>
        PlayerAssignToTeam
    }
}