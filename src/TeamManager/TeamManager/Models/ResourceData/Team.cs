using System;
using System.Collections.Generic;

namespace TeamManager.Models.ResourceData
{
    public class Team : IComparable<Team> 
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public Team(string name)
        {
            Id = Guid.NewGuid().ToString();
            Name = name;
        }

        public static implicit operator string(Team team)
        {
            return team.Name;
        }

        public int CompareTo(Team other)
        {
            if (ReferenceEquals(this, other)) return 0;
            if (ReferenceEquals(null, other)) return 1;
            return string.Compare(Name, other.Name, StringComparison.Ordinal);
        }

        public override bool Equals(object obj)
        {
            Team team = obj as Team;
            return team != null &&
                   Id == team.Id &&
                   Name == team.Name;
        }

        public override int GetHashCode()
        {
            int hashCode = -1919740922;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Id);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            return hashCode;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
