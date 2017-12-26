using TeamManager.Database;
using TeamManager.Models.TechnicalConcept;

namespace TeamManager.Utilities
{
    /// <summary>
    /// Defining all defaults to have in one place.
    /// </summary>
    public static class Defaults
    {
        /// <summary> Returns a new instance of <see cref="TechnicalConcept1"/> with <see cref="DbLayerMongo"/> as database. </summary>
        public static ITechnicalConcept TechnicalConcept => new TechnicalConcept1(DatabaseType);

        /// <summary> Returns the <see cref="TechnicalConceptType"/> as <see cref="TechnicalConceptType.FirstMt"/>. </summary>
        public static TechnicalConceptType TechnicalConceptType => TechnicalConceptType.FirstMt;

        /// <summary> Returns a new instance of <see cref="DbLayerMongo"/>. </summary>
        public static IDataLayer Database => new DbLayerMongo();

        /// <summary> Returns the <see cref="DatabaseType"/> as <see cref="DatabaseType.Mongo"/>. </summary>
        public static DatabaseType DatabaseType => DatabaseType.Mongo;
    }
}
