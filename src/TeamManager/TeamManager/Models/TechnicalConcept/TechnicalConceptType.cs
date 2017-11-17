using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamManager.Main.ConceptTypes
{
    /// <summary>
    /// ConceptType affects the way the data structure will get initialized from the database.
    /// </summary>
    public enum ConceptType
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
