using TeamManager.Database;
using TeamManager.Models.ResourceData;

namespace TeamManager.Models.TechnicalConcept
{
    public abstract class TechnicalConceptBase
    {
        protected IDataLayer dbLayer;
        public Team Team { get; set; }
        public Player Player { get; set; }


        protected TechnicalConceptBase(DatabaseType dbType)
        {
            switch (dbType)
            {
                case DatabaseType.MongoDB:
                    this.dbLayer = new DBLayerMongo();
                    break;
                case DatabaseType.SQL:
                    this.dbLayer = new DBLayerSql();
                    break;
                default:
                    this.dbLayer = new DBLayerSql();
                    break;
            }
        }
    }
}
