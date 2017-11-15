using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamManager.TechnicalConcept
{
    public class Team
    {
        public string Name { get; private set; }
        public string Id { get; private set; }

        public Team()
        {
            this.Name = "New Team";
        }
        public Team(string name)
        {
            this.Name = name;
        }
        public Team(string name, string id)
        {
            this.Name = name;
            this.Id = id;
        }
    }
}
