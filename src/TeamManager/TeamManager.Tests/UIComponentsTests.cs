using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TeamManager.Models.ResourceData;
using TeamManager.Utilities;

namespace TeamManager.Tests
{
    [TestFixture]
    public class UIComponentsTests
    {
        /// <summary>
        /// Object collection child object of ListBox which is the component we work the most when using the GUI.
        /// </summary>
        private ListBox.ObjectCollection collection;


        /// <summary>
        /// Test if can add teams or players as Team/Player object and retrieve them back to team/player from object.
        /// </summary>
        [Test]
        public void ListBox_ObjectCollection()
        {
            collection = new ListBox.ObjectCollection(new ListBox());
            Team team = new Team("Brazil");
            Player player = new Player("Ronaldo");

            collection.Add(team);
            collection.Add(player);

            Assert.IsInstanceOf<Team>(collection[0]);
            Assert.IsInstanceOf<Player>(collection[1]);
            Assert.AreNotSame(collection[0], collection[1]);
            Assert.AreEqual(collection[0].ToTeam().Id, team.Id);
            Assert.AreEqual(collection[1].ToPlayer().Id, player.Id);
        }

        /// <summary>
        /// Test clear and see if it's empty.
        /// </summary>
        [Test]
        public void ListBox_ObjectCollection_ClearingAll()
        {
            collection = new ListBox.ObjectCollection(new ListBox());
            Team team = new Team("Brazil");
            Player player = new Player("Ronaldo");

            collection.Add(team);
            collection.Add(player);

            Assert.IsNotEmpty(collection);
            collection.Clear();
            Assert.IsEmpty(collection);
        }

        /// <summary>
        /// Casts object to Team object after filling the collection and 
        /// check if null or compare with original and casted object.
        /// </summary>
        [Test]
        public void ListBox_ObjectCollection_CastingObjectToTeam()
        {
            collection = new ListBox.ObjectCollection(new ListBox());
            Team team = new Team("Brazil");

            collection.Add(team);

            Team teamCasted = collection[0].ToTeam();

            Assert.NotNull(teamCasted);
            Assert.AreSame(teamCasted, team);
        }

        /// <summary>
        /// Casts object to Player object after filling the collection and 
        /// check if null or compare with original and casted object.
        /// </summary>
        [Test]
        public void ListBox_ObjectCollection_CastingObjectToPlayer()
        {
            collection = new ListBox.ObjectCollection(new ListBox());
            Player player = new Player("Ronaldo");

            collection.Add(player);

            Player playerCasted = collection[0].ToPlayer();

            Assert.NotNull(playerCasted);
            Assert.AreSame(playerCasted, player);
        }

        /// <summary>
        /// Casts object to Team and compare team id to const team id.
        /// </summary>
        [Test]
        public void ListBox_ObjectCollection_CompareTeamId()
        {
            collection = new ListBox.ObjectCollection(new ListBox());
            Team team = new Team("Brazil");

            collection.Add(team);

            Team teamCasted = collection[0].ToTeam();

            Assert.AreEqual(teamCasted.Id, team.Id);
            Assert.AreSame(teamCasted, team);
        }

        /// <summary>
        /// Casts object to Team and compare team id to const team id.
        /// </summary>
        [Test]
        public void ListBox_ObjectCollection_ComparePlayerId()
        {
            collection = new ListBox.ObjectCollection(new ListBox());
            Player player = new Player("Ronaldo");

            collection.Add(player);

            Player playerCasted = collection[0].ToPlayer();

            Assert.AreEqual(playerCasted.Id, player.Id);
            Assert.AreSame(playerCasted, player);
        }
    }
}
