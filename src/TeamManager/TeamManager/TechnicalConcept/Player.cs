using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamManager.TechnicalConcept
{
    public class Player
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
        public Team ATeam
        {
            get { return ATeam; }
            private set { ATeam = value; }
        }

        public Player()
        {
            this.Name = "New Player";
            this.Id = 0.ToString();
        }
        public Player(String name)
        {
            this.Name = name;
            this.Id = 0.ToString();
        }
        public Player(String name, String id)
        {
            this.Name = name;
            this.Id = id;
        }
        public Player(String name, String id, Team aTeam)
        {
            this.Name = name;
            this.Id = id;
            this.ATeam = aTeam;
        }

        public void ChangeTeam(Team newTeam)
        {
            this.ATeam = newTeam;
        }
    }
}
