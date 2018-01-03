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
        public List<Team> Sort(IEnumerable<Team> list)
        {
            return list?.OrderByDescending(team => team.Name).ToList();
        }

        public List<Player> Sort(IEnumerable<Player> list)
        {
            return list?.OrderByDescending(player => player.Name).ToList();
        }
    }
}
