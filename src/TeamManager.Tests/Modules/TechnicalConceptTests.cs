using NUnit.Framework;
using System;
using System.Collections.Generic;
using TeamManager.Database;
using TeamManager.Models.ResourceData;
using TeamManager.Models.TechnicalConcept;

namespace TeamManager.Tests.Modules
{
    [TestFixture]
    public class TechnicalConceptTests
    {
        private ITechnicalConcept _concept1MongoDb = new TechnicalConcept1(DatabaseType.Mongo);
        private ITechnicalConcept _concept2MongoDb = new TechnicalConcept2(DatabaseType.Mongo);
        private ITechnicalConcept _concept1Sql     = new TechnicalConcept1(DatabaseType.Sql);
        private ITechnicalConcept _concept2Sql     = new TechnicalConcept2(DatabaseType.Sql);

        /// <summary>
        /// Testing whether we get atleast 3 players count just as example for later testing.
        /// </summary>
        [Test]
        public void MongoDB_Concept1_GetAllPlayers()
        {
            // Arrange
            List<Player> players = _concept1MongoDb.GetAllPlayers();
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
