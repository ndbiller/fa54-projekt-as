using NUnit.Framework;
using System;
using System.Collections.Generic;
using TeamManager.Database;
using TeamManager.Models.ResourceData;
using TeamManager.Models.TechnicalConcept;

namespace TeamManager.Tests
{
    [TestFixture]
    public class TechnicalConceptTests
    {
        private ITechnicalConcept concept1MongoDB = new TechnicalConcept1(DatabaseType.MongoDB);
        private ITechnicalConcept concept2MongoDB = new TechnicalConcept2(DatabaseType.MongoDB);
        private ITechnicalConcept concept1SQL     = new TechnicalConcept1(DatabaseType.SQL);
        private ITechnicalConcept concept2SQL     = new TechnicalConcept2(DatabaseType.SQL);

        /// <summary>
        /// Testing whether we get atleast 3 players count just as example for later testing.
        /// </summary>
        [Test]
        public void MongoDB_Concept1_GetAllPlayers()
        {
            // Arrange
            List<Player> players = concept1MongoDB.GetAllPlayers();
            int playersCountExpected = 3;

            // Actual
            int playersCountActual = players.Count;

            // Assert
            Console.WriteLine("Expecting to get atleast 3 players:");
            Console.WriteLine($"Actual Players Count Results -> {playersCountActual}");
            Console.WriteLine($"Expected Players Count Results -> {playersCountExpected}");

            Assert.GreaterOrEqual(playersCountActual, playersCountExpected);
        }
    }
}
