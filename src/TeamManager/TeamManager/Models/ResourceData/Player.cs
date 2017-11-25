using System;
using System.Collections.Generic;

namespace TeamManager.Models.ResourceData
{
    public class Player : IComparable<Player>
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

        public int CompareTo(Player other)
        {
            if (ReferenceEquals(this, other)) return 0;
            if (ReferenceEquals(null, other)) return 1;
            return string.Compare(Name, other.Name, StringComparison.Ordinal);
        }

        public override bool Equals(object obj)
        {
            Player player = obj as Player;
            return player != null &&
                   Id == player.Id &&
                   Name == player.Name &&
                   TeamId == player.TeamId;
        }

        public override int GetHashCode()
        {
            int hashCode = -1994829321;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Id);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(TeamId);
            return hashCode;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
