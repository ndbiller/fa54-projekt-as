using NUnit.Framework;
using System;
using System.Collections.Generic;
using TeamManager.Database;
using TeamManager.Models.ResourceData;

namespace TeamManager.Tests.Modules
{
    [TestFixture]
    public class StrategyTests
    {
        //private IStrategy _ascendingStrategyMongoDb = new AscendingStrategy(DatabaseType.Mongo);
        //private IStrategy _descendingStrategyMongoDb = new DescendingStrategy(DatabaseType.Mongo);
        //private IStrategy _ascendingStrategySql = new AscendingStrategy(DatabaseType.PostgreSql);
        //private IStrategy _descendingStrategySql = new DescendingStrategy(DatabaseType.PostgreSql);

        /// <summary>
        /// Testing whether we get atleast 3 players count just as example for later testing.
        /// </summary>
        //[Test]
        //public void MongoDB_AscendingStrategy_GetAllPlayers()
        //{
        //    // Arrange
        //    List<Player> players = _ascendingStrategyMongoDb.GetAllPlayers();
        //    int playersCountExpected = 3;

        //    // Actual
        //    int playersCountActual = players.Count;

        //    // Assert
        //    Console.WriteLine("Expecting to get atleast 3 players:");
        //    Console.WriteLine($"Actual Players Count Results -> {playersCountActual}");
        //    Console.WriteLine($"Expected Players Count Results -> {playersCountExpected}");

        //    Assert.GreaterOrEqual(playersCountActual, playersCountExpected);
        //}
    }
}
