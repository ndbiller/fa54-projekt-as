using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamManager.Database;
using TeamManager.Utilities;

namespace TeamManager.Models.Logic
{
    public abstract class BusinessLogicBase
    {
        /// <summary> The <see cref="IDataLayer"/> instance that will be used for retrieving data from the database. </summary>
        protected IDataLayer DbLayer;


        protected static ISortStrategy SortBehaviour;

        private static SortType _sortType;
        public static SortType SortType
        {
            get => _sortType;
            set
            {
                _sortType = value;
                if (_sortType == SortType.Descending)
                    SortBehaviour = new SortDescending();
                else
                    SortBehaviour = new SortAscending();
            }
        }

        /// <summary>
        /// The constructor of the <see cref="StrategyBase"/> will initialize the database type and receive the type
        /// from the constructors of it's inherited objects.
        /// </summary>
        /// <param name="dbType"></param>
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
