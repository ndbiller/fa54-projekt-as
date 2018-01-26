using TeamManager.Database;
using TeamManager.Models.Strategy;
using TeamManager.Utilities;

namespace TeamManager.Models.Logic
{
    public abstract class BusinessLogicBase
    {
        /// <summary> The <see cref="IDataLayer"/> instance that will be used for retrieving data from the database. </summary>
        protected IDataLayer DbLayer;

        /// <summary> The <see cref="ISortStrategy"/> instance that will control the sort behavior using the strategy pattern. </summary>
        protected static ISortStrategy SortStrategy;

        /// <summary> Place holder for the <see cref="SortType"/> property. </summary>
        private static SortType _sortType;

        /// <summary> Static property that will allow to change the strategy beavhior in run-time. </summary>
        public static SortType SortType
        {
            get => _sortType;
            set
            {
                _sortType = value;
                if (_sortType == SortType.Descending)
                    SortStrategy = new SortDescending();
                else
                    SortStrategy = new SortAscending();
            }
        }

        /// <summary>
        /// The constructor will initialize the promoted database type and receive the type
        /// from the constructors of the inherited objects.
        /// </summary>
        /// <param name="dbType"></param>
        /// <param name="sortType"></param>
        protected BusinessLogicBase(DatabaseType dbType, SortType sortType)
        {
            switch (dbType)
            {
                case DatabaseType.Mongo:
                    DbLayer = new DbLayerMongo();
                    break;
                case DatabaseType.PostgreSql:
                    DbLayer = new DbLayerSql();
                    break;
                default:
                    DbLayer = Defaults.Database;
                    break;
            }

            SortType = sortType;
        }
    }
}
