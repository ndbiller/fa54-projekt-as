namespace TeamManager.Models.Strategy
{
    /// <summary>
    /// This enum controls the way the data will get initialized from the database.
    /// </summary>
    public enum StrategyType
    {
        /// <summary>
        /// Retrieves the data in ascending order.
        /// </summary>
        First,

        /// <summary>
        /// Retrieves the data in ascending order using async calls.
        /// </summary>
        FirstMt,

        /// <summary>
        /// Retrieves the data in descending order.
        /// </summary>
        Second,

        /// <summary>
        /// Retrieves the data in descending order using async calls.
        /// </summary>
        SecondMt
    }
}
