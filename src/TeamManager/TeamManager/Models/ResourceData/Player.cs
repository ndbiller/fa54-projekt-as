using System;

namespace TeamManager.Models.ResourceData
{
    public class Player
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string TeamId { get; set; }

        public Player(string name, string teamId = "0")
        {
            this.Id = Guid.NewGuid().ToString();
            this.Name = name;
            this.TeamId = teamId;
        }
    }
}
