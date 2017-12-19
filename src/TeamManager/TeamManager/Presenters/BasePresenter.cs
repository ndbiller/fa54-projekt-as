using log4net;
using TeamManager.Database;
using TeamManager.Models.TechnicalConcept;
using TeamManager.Presenters.Events;
using TeamManager.Utilities;

namespace TeamManager.Presenters
{
    /// <summary>
    /// The base presenter will contain the Concept Type that will be used in the way 
    /// we retrieve data from the database and all commmon data between all presenters.
    /// </summary>
    public abstract class BasePresenter
    {
        private static readonly ILog Log = Logger.GetLogger();

        protected static ITechnicalConcept Concept;

        protected static event PresenterHandler ChildClosed;


        protected virtual void OnChildClosed(object sender, PresenterArgs e)
        {
            Log.Info($"ChildForm closed invoked => {e.Child}");
            ChildClosed?.Invoke(sender, e);
        }

        public abstract void FormClosed();

        public static void SetConceptAndDatabaseType(TechnicalConceptType conceptType, DatabaseType dbType)
        {
            switch (conceptType)
            {
                case TechnicalConceptType.First:
                    Concept = new TechnicalConcept1(dbType);
                    break;

                case TechnicalConceptType.FirstMt:
                    Concept = new TechnicalConcept1Mt(dbType);
                    break;

                case TechnicalConceptType.Second:
                    Concept = new TechnicalConcept2(dbType);
                    break;

                case TechnicalConceptType.SecondMt:
                    Concept = new TechnicalConcept2Mt(dbType);
                    break;

                default:
                    Concept = Defaults.TechnicalConcept;
                    break;
            }
        }
    }
}
