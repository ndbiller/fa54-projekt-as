using System.Collections.Generic;
using System.Linq;
using TeamManager.Models.ResourceData;

namespace TeamManager.Models.Strategy
{
    /// <summary>
    /// Sorting in Descending order.
    /// For more info, refer to <see cref="ISortStrategy"/>.
    /// </summary>
    public class SortDescending : ISortStrategy
    {
        public List<T> Sort<T>(IEnumerable<T> list) where T : ResourceBase
        {
            return list?.OrderByDescending(team => team.Name).ToList();
        }
    }
}
