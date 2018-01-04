using TeamManager.Database;
using TeamManager.Models.Strategy;

namespace TeamManager.Utilities
{
    /// <summary>
    /// Defining all defaults to have in one place.
    /// </summary>
    public static class Defaults
    {
        /// <summary> Returns a new instance of <see cref="AscendingStrategy"/> with <see cref="DbLayerMongo"/> as database. </summary>
        public static IStrategy Strategy => new AscendingStrategy(DatabaseType);

        /// <summary> Returns the <see cref="StrategyType"/> as <see cref="StrategyType.FirstMt"/>. </summary>
        public static StrategyType StrategyType => StrategyType.FirstMt;

        /// <summary> Returns a new instance of <see cref="DbLayerMongo"/>. </summary>
        public static IDataLayer Database => new DbLayerMongo();

        /// <summary> Returns the <see cref="DatabaseType"/> as <see cref="DatabaseType.Mongo"/>. </summary>
        public static DatabaseType DatabaseType => DatabaseType.Mongo;
    }
}
