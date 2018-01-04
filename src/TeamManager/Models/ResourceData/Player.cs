using System;
using System.Collections.Generic;

namespace TeamManager.Models.ResourceData
{
    /// <summary>
    /// The one and the only <see cref="Player"/> object that is used as resource for almost every place in the project.
    /// It implements the <see cref="IComparable"/> interface in order to make the most of it when working with it in collections.
    /// </summary>
    public class Player : IComparable<Player>
    {
        /// <summary> The <see cref="Id"/> of the <see cref="Player"/> which is defined with the <see cref="Guid"/>. </summary>
        public string Id { get; set; }

        /// <summary> The <see cref="Name"/> of the <see cref="Player"/> as string. </summary>
        public string Name { get; set; }

        /// <summary> The <see cref="TeamId"/> of the <see cref="Player"/> which is in a relationship with the <see cref="Team.Id"/>. </summary>
        public string TeamId { get; set; }




        /// <summary>
        /// The constructor requires a <see cref="Name"/> to be passed as the <see cref="Id"/> will generate a new <see cref="Guid"/> automatically and
        /// the <see cref="TeamId"/> is not must as the default value is 0(which means unsigned team).
        /// </summary>
        /// <param name="name">The name of the <see cref="Player"/>. </param>
        /// <param name="teamId">Default value = "0" which is unsigned team. </param>
        public Player(string name, string teamId = "0")
        {
            Id = Guid.NewGuid().ToString();
            Name = name;
            TeamId = teamId;
        }



        /// <summary>
        /// Implicit cast to a string so the <see cref="Player"/> object can be passed directly to a string variable without
        /// using the .ToString() method everywhere.
        /// </summary>
        /// <param name="player"></param>
        public static implicit operator string(Player player)
        {
            return player.Name;
        }

        /// <summary>
        /// Overrides the <see cref="CompareTo"/> method in order to make the most of it when working with this object in collections.
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public int CompareTo(Player other)
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
            Player player = obj as Player;
            return player != null &&
                   Id == player.Id &&
                   Name == player.Name &&
                   TeamId == player.TeamId;
        }

        /// <summary>
        /// Overrides the <see cref="GetHashCode"/> method in order to retrieve unique idenifier generated for each <see cref="Player"/> depending on it's
        /// members.
        /// </summary>
        /// <returns><see cref="int"/></returns>
        public override int GetHashCode()
        {
            int hashCode = -1994829321;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Id);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(TeamId);
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
