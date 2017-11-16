using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamManager.Models.TechnicalConcept
{
    public class Player
    {
        public string Name { get; private set; }
        public string Id { get; private set; }
        public Team ATeam { get; private set; }

        public Player()
        {
            this.Name = "New Player";
            this.Id = 0.ToString();
        }
        public Player(string name)
        {
            this.Name = name;
            this.Id = 0.ToString();
        }
        public Player(string name, string id)
        {
            this.Name = name;
            this.Id = id;
        }
        public Player(string name, string id, Team aTeam)
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
