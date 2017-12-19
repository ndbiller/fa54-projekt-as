using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamManager.Database;
using TeamManager.Models.TechnicalConcept;

namespace TeamManager.Utilities
{
    /// <summary>
    /// Defining all defaults to have in one place.
    /// </summary>
    public static class Defaults
    {
        public static ITechnicalConcept TechnicalConcept => new TechnicalConcept1(DatabaseType);
        public static TechnicalConceptType TechnicalConceptType => TechnicalConceptType.FirstMt;
        public static IDataLayer Database => new DBLayerMongo();
        public static DatabaseType DatabaseType => DatabaseType.MongoDB;
    }
}
