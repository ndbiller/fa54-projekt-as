using TeamManager.Database;
using TeamManager.Models.Logic;

namespace TeamManager.Utilities
{
    /// <summary>
    /// Defining all defaults to have in one place.
    /// </summary>
    public static class Defaults
    {
        /// <summary> Returns a new instance of <see cref="BusinessLogic"/> with <see cref="DbLayerMongo"/> as database using 
        /// default sorting as <see cref="SortType.Ascending"/>. </summary>
        public static IBusinessLogic BusinessLogic => new BusinessLogic(DatabaseType, SortType);

        /// <summary> Returns the <see cref="BusinessLogicType"/> as <see cref="BusinessLogicType.Normal"/>. </summary>
        public static BusinessLogicType BusinessLogicType => BusinessLogicType.Normal;

        /// <summary> Returns the <see cref="SortType"/> as <see cref="SortType.Ascending"/>. </summary>
        public static SortType SortType => SortType.Ascending;

        /// <summary> Returns a new instance of <see cref="DbLayerMongo"/>. </summary>
        public static IDataLayer Database => new DbLayerMongo();

        /// <summary> Returns the <see cref="DatabaseType"/> as <see cref="DatabaseType.Mongo"/>. </summary>
        public static DatabaseType DatabaseType => DatabaseType.Mongo;


    }
}
