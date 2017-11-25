using System;

namespace TeamManager.Models.ResourceData
{
    public class Team
    {
        public string Id { get; set; }
        public string Name { get; set; }


        public Team(string name)
        {
            this.Id = Guid.NewGuid().ToString();
            this.Name = name;
        }
    }
}
