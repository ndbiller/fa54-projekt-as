using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamManager.Database;
using TeamManager.Models.ResourceData;

namespace TeamManager.Models.TechnicalConcept
{
    public abstract class TechnicalConceptBase
    {
        protected IDataLayer dataLayer;
        public Team Team { get; set; }
        public Player Player { get; set; }


        public TechnicalConceptBase(DatabaseType dbType)
        {
            switch (dbType)
            {
                case DatabaseType.MongoDB:
                    this.dataLayer = new DBLayerMongo();
                    break;
                case DatabaseType.SQL:
                    this.dataLayer = new DBLayerSql();
                    break;
                default:
                    this.dataLayer = new DBLayerSql();
                    break;
            }
        }
    }
}
