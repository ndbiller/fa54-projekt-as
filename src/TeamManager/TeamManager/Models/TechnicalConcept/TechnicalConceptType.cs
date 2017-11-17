using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamManager.Models.TechnicalConcept
{
    /// <summary>
    /// This enum controls the way the data will get initialized from the database.
    /// </summary>
    public enum TechnicalConceptType
    {
        /// <summary>
        /// Retrieves the data in ascending order.
        /// </summary>
        First,

        /// <summary>
        /// Retrieves the data in descending order.
        /// </summary>
        Second
    }
}
