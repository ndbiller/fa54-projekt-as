namespace TeamManager.Database
{
    /// <summary>
    /// The <see cref="DatabaseType"/> that will be used when the project gets initialized.
    /// </summary>
    public enum DatabaseType
    {
        /// <summary> Not-Relational database. </summary>
        Mongo,

        /// <summary> Relational database. </summary>
        PostgreSql
    }
}
