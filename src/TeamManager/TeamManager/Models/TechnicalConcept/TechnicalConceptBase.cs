using TeamManager.Database;
using TeamManager.Utilities;

namespace TeamManager.Models.TechnicalConcept
{
    public abstract class TechnicalConceptBase
    {
        protected IDataLayer DbLayer;


        protected TechnicalConceptBase(DatabaseType dbType)
        {
            switch (dbType)
            {
                case DatabaseType.Mongo:
                    DbLayer = new DbLayerMongo();
                    break;
                case DatabaseType.Sql:
                    DbLayer = new DbLayerSql();
                    break;
                default:
                    DbLayer = Defaults.Database;
                    break;
            }
        }

    }
}
