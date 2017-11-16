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
        protected IDataLayer DataLayer { get; set; }
        public Team ATeam { get; set; }
        public Player APlayer { get; set; }

        public TechnicalConceptBase(DataType dataType)
        {
            switch (dataType)
            {
                case DataType.MongoDB:
                    this.DataLayer = new DBLayerMongo();
                    break;
                case DataType.SQL:
                    this.DataLayer = new DBLayerSql();
                    break;
                default:
                    this.DataLayer = new DBLayerSql();
                    break;
            }
        }
    }
}
