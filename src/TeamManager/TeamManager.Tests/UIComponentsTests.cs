using NUnit.Framework;
using System.Windows.Forms;
using TeamManager.Models.ResourceData;
using TeamManager.Utilities;

namespace TeamManager.Tests
{
    [TestFixture]
    public class UiComponentsTests
    {
        /// <summary>
        /// Object collection child object of ListBox which is the component we work the most when using the GUI.
        /// </summary>
        private ListBox.ObjectCollection _collection;


        /// <summary>
        /// Test if can add teams or players as Team/Player object and retrieve them back to team/player from object.
        /// </summary>
        [Test]
        public void ListBox_ObjectCollection()
        {
            _collection = new ListBox.ObjectCollection(new ListBox());
            Team team = new Team("Brazil");
            Player player = new Player("Ronaldo");

            _collection.Add(team);
            _collection.Add(player);

            Assert.IsInstanceOf<Team>(_collection[0]);
            Assert.IsInstanceOf<Player>(_collection[1]);
            Assert.AreNotSame(_collection[0], _collection[1]);
            Assert.AreEqual(_collection[0].ToTeam().Id, team.Id);
            Assert.AreEqual(_collection[1].ToPlayer().Id, player.Id);
        }

        /// <summary>
        /// Test clear and see if it's empty.
        /// </summary>
        [Test]
        public void ListBox_ObjectCollection_ClearingAll()
        {
            _collection = new ListBox.ObjectCollection(new ListBox());
            Team team = new Team("Brazil");
            Player player = new Player("Ronaldo");

            _collection.Add(team);
            _collection.Add(player);

            Assert.IsNotEmpty(_collection);
            _collection.Clear();
            Assert.IsEmpty(_collection);
        }

        /// <summary>
        /// Casts object to Team object after filling the collection and 
        /// check if null or compare with original and casted object.
        /// </summary>
        [Test]
        public void ListBox_ObjectCollection_CastingObjectToTeam()
        {
            _collection = new ListBox.ObjectCollection(new ListBox());
            Team team = new Team("Brazil");

            _collection.Add(team);

            Team teamCasted = _collection[0].ToTeam();

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
            _collection = new ListBox.ObjectCollection(new ListBox());
            Player player = new Player("Ronaldo");

            _collection.Add(player);

            Player playerCasted = _collection[0].ToPlayer();

            Assert.NotNull(playerCasted);
            Assert.AreSame(playerCasted, player);
        }

        /// <summary>
        /// Casts object to Team and compare team id to const team id.
        /// </summary>
        [Test]
        public void ListBox_ObjectCollection_CompareTeamId()
        {
            _collection = new ListBox.ObjectCollection(new ListBox());
            Team team = new Team("Brazil");

            _collection.Add(team);

            Team teamCasted = _collection[0].ToTeam();

            Assert.AreEqual(teamCasted.Id, team.Id);
            Assert.AreSame(teamCasted, team);
        }

        /// <summary>
        /// Casts object to Team and compare team id to const team id.
        /// </summary>
        [Test]
        public void ListBox_ObjectCollection_ComparePlayerId()
        {
            _collection = new ListBox.ObjectCollection(new ListBox());
            Player player = new Player("Ronaldo");

            _collection.Add(player);

            Player playerCasted = _collection[0].ToPlayer();

            Assert.AreEqual(playerCasted.Id, player.Id);
            Assert.AreSame(playerCasted, player);
        }
    }
}
