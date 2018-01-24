using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamManager.Models.ResourceData;

namespace TeamManager.Models.Logic
{
    public interface ISortStrategy
    {
        List<T> Sort<T>(IEnumerable<T> list) where T : ResourceBase;
    }
}
