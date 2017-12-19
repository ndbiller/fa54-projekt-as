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
                case DatabaseType.MongoDB:
                    DbLayer = new DBLayerMongo();
                    break;
                case DatabaseType.SQL:
                    DbLayer = new DBLayerSql();
                    break;
                default:
                    DbLayer = Defaults.Database;
                    break;
            }
        }

    }
}
