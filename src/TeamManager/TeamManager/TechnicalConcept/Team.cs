using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamManager.TechnicalConcept
{
    public class Team
    {
        public String Name
        {
            get { return Name; }
            private set { Name = value; }
        }
        public String Id
        {
            get { return Id; }
            private set { Id = value; }
        }
        public Team()
        {
            this.Name = "New Team";
        }
        public Team(String name)
        {
            this.Name = name;
        }
        public Team(String name, String id)
        {
            this.Name = name;
            this.Id = id;
        }
    }
}
