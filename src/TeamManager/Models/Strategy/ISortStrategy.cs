using System.Collections.Generic;
using TeamManager.Models.ResourceData;

namespace TeamManager.Models.Strategy
{
    /// <summary>
    /// The <see cref="ISortStrategy"/> interface will be in the <see cref="BusinessLogicBase"/> in order to allow 
    /// changing the sort behavior in run-time using the Strategy Pattern.
    /// </summary>
    public interface ISortStrategy
    {
        /// <summary>
        /// Sorts a generic collection that their type is part of the <see cref="ResourceBase"/> class.
        /// </summary>
        /// <typeparam name="T">The type of the collection. </typeparam>
        /// <param name="list">The collection/list. </param>
        /// <returns></returns>
        List<T> Sort<T>(IEnumerable<T> list) where T : ResourceBase;
    }
}
