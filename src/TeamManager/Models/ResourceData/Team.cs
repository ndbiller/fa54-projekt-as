using System;
using System.Collections.Generic;

namespace TeamManager.Models.ResourceData
{
    /// <summary>
    /// The one and the only <see cref="Team"/> object that is used as resource for almost every place in the project.
    /// It implements the <see cref="IComparable"/> interface in order to make the most of it when working with it in collections.
    /// </summary>
    public class Team : IComparable<Team> 
    {
        /// <summary> The <see cref="Id"/> of the <see cref="Team"/> which is defined with the <see cref="Guid"/>. </summary>
        public string Id { get; set; }

        /// <summary> The <see cref="Name"/> of the <see cref="Team"/> as string. </summary>
        public string Name { get; set; }




        /// <summary>
        /// The constructor requires a <see cref="Name"/> to be passed as the <see cref="Id"/> will generate a new <see cref="Guid"/> automatically.
        /// </summary>
        /// <param name="name"></param>
        public Team(string name)
        {
            Id = Guid.NewGuid().ToString();
            Name = name;
        }

        // for reading the db
        public Team(string id, string name)
        {
            Id = id;
            Name = name;
        }


        /// <summary>
        /// Implicit casting to a string so the <see cref="Team"/> object can be passed directly to a string variable without
        /// using the .ToString() method everywhere.
        /// </summary>
        /// <param name="team"></param>
        public static implicit operator string(Team team)
        {
            return team.Name;
        }

        /// <summary>
        /// Overrides the <see cref="CompareTo"/> method in order to make the most of it when working with this object in collections.
        /// </summary>
        /// <param name="other"></param>
        /// <returns><see cref="int"/></returns>
        public int CompareTo(Team other)
        {
            if (ReferenceEquals(this, other)) return 0;
            if (ReferenceEquals(null, other)) return 1;
            return string.Compare(Name, other.Name, StringComparison.Ordinal);
        }

        /// <summary>
        /// Overrides the <see cref="Equals"/> method as it would make things easier when initialzing this object
        /// into a ListBox.ObjectCollection for example.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns><see cref="bool"/></returns>
        public override bool Equals(object obj)
        {
            Team team = obj as Team;
            return team != null &&
                   Id == team.Id &&
                   Name == team.Name;
        }

        /// <summary>
        /// Overrides the <see cref="GetHashCode"/> method in order to retrieve unique idenifier generated for each <see cref="Team"/> depending on it's
        /// members.
        /// </summary>
        /// <returns><see cref="int"/></returns>
        public override int GetHashCode()
        {
            int hashCode = -1919740922;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Id);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            return hashCode;
        }

        /// <summary>
        /// Overrides the <see cref="ToString"/> method in order to easily pass this object into a ListBox.ObjectCollection for example.
        /// </summary>
        /// <returns><see cref="Name"/></returns>
        public override string ToString()
        {
            return Name;
        }

    }
}
