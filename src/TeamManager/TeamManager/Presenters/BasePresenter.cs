using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamManager.Main.ConceptTypes;

namespace TeamManager.Presenters
{
    /// <summary>
    /// The base presenter will contain the Concept Type that will be used in the way 
    /// we retrieve data from the database and all commmon data between all presenters.
    /// </summary>
    public abstract class BasePresenter
    {
        protected static IConceptType conceptType;


        public static void SetConceptType(ConceptType type)
        {
            switch (type)
            {
                case ConceptType.First:
                    conceptType = new FirstConcept();
                    break;

                case ConceptType.Second:
                    conceptType = new SecondConcept();
                    break;

                default:
                    conceptType = new FirstConcept();
                    break;
            }
        }
    }
}
