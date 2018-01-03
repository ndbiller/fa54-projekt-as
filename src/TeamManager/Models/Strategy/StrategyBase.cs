using TeamManager.Database;
using TeamManager.Utilities;

namespace TeamManager.Models.Strategy
{
    /// <summary>
    /// The <see cref="StrategyBase"/> will contain the <see cref="IDataLayer"/> interface which gives 
    /// access to the choosen database in order to retrieve data for the inherited <see cref="StrategyType"/>s
    /// in order to pass the neccessary data to the <see cref="Presenters.BasePresenter"/>.
    /// </summary>
    public abstract class StrategyBase
    {
        /// <summary> The <see cref="IDataLayer"/> instance that will be used for retrieving data from the database. </summary>
        protected IDataLayer DbLayer;




        /// <summary>
        /// The constructor of the <see cref="StrategyBase"/> will initialize the database type and receive the type
        /// from the constructors of it's inherited objects.
        /// </summary>
        /// <param name="dbType"></param>
        protected StrategyBase(DatabaseType dbType)
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
        }

    }
}
