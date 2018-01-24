using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamManager.Models.ResourceData;

namespace TeamManager.Models.Logic
{
    public class SortDescending : ISortStrategy
    {
        public List<T> Sort<T>(IEnumerable<T> list) where T : ResourceBase
        {
            return list?.OrderByDescending(team => team.Name).ToList();
        }
    }
}
