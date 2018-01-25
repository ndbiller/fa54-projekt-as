using System.Collections.Generic;
using System.Linq;
using TeamManager.Models.ResourceData;

namespace TeamManager.Models.Strategy
{
    /// <summary>
    /// Sorting in Ascending order.
    /// For more info, refer to <see cref="ISortStrategy"/>.
    /// </summary>
    public class SortAscending : ISortStrategy
    {
        public List<T> Sort<T>(IEnumerable<T> list) where T : ResourceBase
        {
            return list?.OrderBy(l => l.Name).ToList();
        }
    }
}
