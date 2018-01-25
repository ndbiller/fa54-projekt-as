namespace TeamManager.Models.Logic
{
    /// <summary>
    /// Defines the type of the <see cref="IBusinessLogic"/> to be used.
    /// </summary>
    public enum BusinessLogicType
    {
        /// <summary> Calls the normal methods in the <see cref="Database.IDataLayer"/>. </summary>
        Normal,

        /// <summary> Calls the multi-threaded methods in the <see cref="Database.IDataLayer"/>. </summary>
        MultiThreaded
    }
}
