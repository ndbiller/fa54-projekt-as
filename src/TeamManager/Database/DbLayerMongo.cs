using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using log4net;
using TeamManager.Models.ResourceData;
using TeamManager.Utilities;

namespace TeamManager.Database
{
    /// <summary>
    /// <see cref="DbLayerMongo"/> will contain none-relational data.
    /// For more information, please refer to:
    /// <see cref="DatabaseType"/>
    /// <see cref="IDataLayer"/>
    /// </summary>
    public sealed class DbLayerMongo : IDataLayer
    {
        /// <summary> Logger instance of the class <see cref="DbLayerMongo"/> </summary>
        private static readonly ILog Log = Logger.GetLogger();


        // get the mlab db servers credentials from environment variables (set them with .env.bat)
        internal static readonly string MLAB_USERNAME;
        internal static readonly string MLAB_PASSWORD;
        internal static readonly string MLAB_URI;
        internal static readonly string MLAB_PORT;
        internal static readonly string MLAB_DATABASE_NAME;

        private static readonly string ConnectionString;

        private static MongoClient Client { get; set; }
        public static IMongoDatabase Connection { get; private set; }
        public static IMongoCollection<Team> TeamCollection { get; set; }
        public static IMongoCollection<Player> PlayerCollection { get; set; }

        public string TeamsCollectionName => "team";
        public string PlayersCollectionName => "player";

        public int TimeoutMilisec => 3000;



        static DbLayerMongo()
        {
#if DB_LOCAL
            Log.Info("Using Mongo-Db local server connection.");
            // connect to local mongodb server
            MLAB_USERNAME = string.Empty;
            MLAB_PASSWORD = string.Empty;
            MLAB_URI = "localhost";
            MLAB_PORT = "27017";
            MLAB_DATABASE_NAME = "teamplayer";

            ConnectionString = $"mongodb://{MLAB_URI}:{MLAB_PORT}";
#else
            Log.Info("Using Mongo-Db online server connection.");

            try
            {
                MLAB_USERNAME      = Environment.GetEnvironmentVariable("MLAB_USERNAME");
                MLAB_PASSWORD      = Environment.GetEnvironmentVariable("MLAB_PASSWORD");
                MLAB_URI           = Environment.GetEnvironmentVariable("MLAB_URI");
                MLAB_PORT          = Environment.GetEnvironmentVariable("MLAB_PORT");
                MLAB_DATABASE_NAME = Environment.GetEnvironmentVariable("MLAB_DATABASE_NAME");
            }
            catch (Exception e)
            {
                Log.Error("cctor - Failed to retrieve environment variables for mongo-db connection string => ", e);
            }

            // connect to mLab mongodb server
            ConnectionString = "mongodb://" + MLAB_USERNAME + ":" + MLAB_PASSWORD + "@" + MLAB_URI + ":" + MLAB_PORT + "/" + MLAB_DATABASE_NAME;
#endif
        }

        public DbLayerMongo()
        {
            CreateConnection();
        }

        public void CreateConnection()
        {
            try
            {
                Client = new MongoClient(ConnectionString);

                Connection = Client.GetDatabase(MLAB_DATABASE_NAME);
                TeamCollection = Connection.GetCollection<Team>(TeamsCollectionName);
                PlayerCollection = Connection.GetCollection<Player>(PlayersCollectionName);
            }
            catch (Exception e)
            {
                Log.Fatal("Failed to initialize or create connection to mongodb => ", e);
                throw;
            }
        }

        public List<Team> Teams()
        {
            try
            {
                List<Team> teams = TeamCollection.Find(_ => true).ToList();
                return teams;
            }
            catch (TimeoutException e)
            {
                Log.Error("Received time out for retrieving teams => ", e);
                return null;
            }
            catch (Exception e)
            {
                Log.Error("Failed to retrieve teams => ", e);
                return null;
            }
        }

        public async Task<List<Team>> TeamsAsync()
        {
            try
            {
                var teams = await TeamCollection.FindAsync(_ => true);
                return teams.ToList();
            }
            catch (TimeoutException e)
            {
                Log.Error("Received time out for retrieving teams async => ", e);
                return null;
            }
            catch (Exception e)
            {
                Log.Error("Failed to retrieve teams async => ", e);
                return null;
            }
        }

        public List<Player> Players()
        {
            try
            {
                List<Player> players = PlayerCollection.Find(_ => true).ToList();
                return players;
            }
            catch (TimeoutException e)
            {
                Log.Error("Received time out for retrieving players => ", e);
                return null;
            }
            catch (Exception e)
            {
                Log.Error("Failed to retrieve players => ", e);
                return null;
            }
        }

        public async Task<List<Player>> PlayersAsync()
        {
            try
            {
                var players = await PlayerCollection.FindAsync(_ => true);
                return players.ToList();
            }
            catch (TimeoutException e)
            {
                Log.Error("Received time out for retrieving players async => ", e);
                return null;
            }
            catch (Exception e)
            {
                Log.Error("Failed to retrieve players => async ", e);
                return null;
            }
        }

        public List<Player> ShowPlayers(string teamId)
        {
            try
            {
                List<Player> players = PlayerCollection.Find(p => p.TeamId == teamId).ToList();
                return players;
            }
            catch (TimeoutException e)
            {
                Log.Error("Received time out for showing players => ", e);
                return null;
            }
            catch (Exception e)
            {
                Log.Error("Failed to retrieve players => ", e);
                return null;
            }
        }

        public async Task<List<Player>> ShowPlayersAsync(string teamId)
        {
            try
            {
                var players = await PlayerCollection.FindAsync(p => p.TeamId == teamId);
                return players.ToList();
            }
            catch (TimeoutException e)
            {
                Log.Error("Received time out for showing players async => ", e);
                return null;
            }
            catch (Exception e)
            {
                Log.Error("Failed to retrieve players async => ", e);
                return null;
            }
        }

        public bool CreateTeam(string name)
        {
            try
            {
                TeamCollection.InsertOne(new Team(name));
                return true;
            }
            catch (TimeoutException e)
            {
                Log.Error("Received time out for creating team => ", e);
                return false;
            }
            catch (Exception e)
            {
                Log.Error("Failed to create team => ", e);
                return false;
            }
        }

        public async Task<bool> CreateTeamAsync(string name)
        {
            try
            {
                await TeamCollection.InsertOneAsync(new Team(name)).TimeoutAfter(TimeoutMilisec);
                return true;
            }
            catch (TimeoutException e)
            {
                Log.Error("Received time out for creating team => async ", e);
                return false;
            }
            catch (Exception e)
            {
                Log.Error("Failed to create team async => ", e);
                return false;
            }
        }

        public bool CreatePlayer(string name, string teamId)
        {
            try
            {
                PlayerCollection.InsertOne(new Player(name, teamId));
                return true;
            }
            catch (TimeoutException e)
            {
                Log.Error("Received time out for creating player => ", e);
                return false;
            }
            catch (Exception e)
            {
                Log.Error("Failed to create player => ", e);
                return false;
            }
        }

        public async Task<bool> CreatePlayerAsync(string name, string teamId)
        {
            try
            {
                await PlayerCollection.InsertOneAsync(new Player(name, teamId)).TimeoutAfter(TimeoutMilisec);
                return true;
            }
            catch (TimeoutException e)
            {
                Log.Error("Received time out for creating player async => ", e);
                return false;
            }
            catch (Exception e)
            {
                Log.Error("Failed to create player async => ", e);
                return false;
            }
        }

        public Team ReadTeam(string id)
        {
            try
            {
                var results = TeamCollection.Find(t => t.Id == id);
                return results.First<Team>();
            }
            catch (TimeoutException e)
            {
                Log.Error("Received time out for reading team => ", e);
                return null;
            }
            catch (Exception e)
            {
                Log.Error("Failed to read team => ", e);
                return null;
            }
        }

        public async Task<Team> ReadTeamAsync(string id)
        {
            try
            {
                var results = await TeamCollection.FindAsync(t => t.Id == id);
                return results.First();
            }
            catch (TimeoutException e)
            {
                Log.Error("Received time out for reading team async => ", e);
                return null;
            }
            catch (Exception e)
            {
                Log.Error("Failed to read team async => ", e);
                return null;
            }
        }

        public Player ReadPlayer(string id)
        {
            try
            {
                var results = PlayerCollection.Find(p => p.Id == id);
                return results.First<Player>();
            }
            catch (TimeoutException e)
            {
                Log.Error("Received time out for reading player => ", e);
                return null;
            }
            catch (Exception e)
            {
                Log.Error("Failed to read player => ", e);
                return null;
            }
        }

        public async Task<Player> ReadPlayerAsync(string id)
        {
            try
            {
                var results = await PlayerCollection.FindAsync(p => p.Id == id);
                return results.First();
            }
            catch (TimeoutException e)
            {
                Log.Error("Received time out for reading player async => ", e);
                return null;
            }
            catch (Exception e)
            {
                Log.Error("Failed to read player async => ", e);
                return null;
            }
        }

        public bool UpdateTeam(string id, string name)
        {
            var filter = Builders<BsonDocument>.Filter.Eq("_id", id);
            var update = Builders<BsonDocument>.Update.Set("Name", name);

            try
            {
                var collection = Connection.GetCollection<BsonDocument>(TeamsCollectionName);
                collection.UpdateOne(filter, update);
                return true;
            }
            catch (TimeoutException e)
            {
                Log.Error("Received time out for updating team => ", e);
                return false;
            }
            catch (Exception e)
            {
                Log.Error("Failed to update team => ", e);
                return false;
            }
        }

        public async Task<bool> UpdateTeamAsync(string id, string name)
        {
            var filter = Builders<BsonDocument>.Filter.Eq("_id", id);
            var update = Builders<BsonDocument>.Update.Set("Name", name);

            try
            {
                var collection = Connection.GetCollection<BsonDocument>(TeamsCollectionName);
                await collection.UpdateOneAsync(filter, update).TimeoutAfter(TimeoutMilisec);
                return true;
            }
            catch (TimeoutException e)
            {
                Log.Error("Received time out for updating team async => ", e);
                return false;
            }
            catch (Exception e)
            {
                Log.Error("Failed to update team async => ", e);
                return false;
            }
        }

        public bool UpdatePlayer(string id, string name)
        {
            var filter = Builders<BsonDocument>.Filter.Eq("_id", id);
            var update = Builders<BsonDocument>.Update.Set("Name", name);

            try
            {
                var collection = Connection.GetCollection<BsonDocument>(PlayersCollectionName);
                collection.UpdateOne(filter, update);
                return true;
            }
            catch (TimeoutException e)
            {
                Log.Error("Received time out for updating player => ", e);
                return false;
            }
            catch (Exception e)
            {
                Log.Error("Failed to update player => ", e);
                return false;
            }
        }

        public async Task<bool> UpdatePlayerAsync(string id, string name)
        {
            var filter = Builders<BsonDocument>.Filter.Eq("_id", id);
            var update = Builders<BsonDocument>.Update.Set("Name", name);

            try
            {
                var collection = Connection.GetCollection<BsonDocument>(PlayersCollectionName);
                await collection.UpdateOneAsync(filter, update).TimeoutAfter(TimeoutMilisec);
                return true;
            }
            catch (TimeoutException e)
            {
                Log.Error("Received time out for updating player async => ", e);
                return false;
            }
            catch (Exception e)
            {
                Log.Error("Failed to update player async => ", e);
                return false;
            }
        }

        // NOTE: Where is this used? It seems to be the same as the other UpdatePlayer Method. What is teamId used for here?
        public bool UpdatePlayer(string id, string teamId, string name)
        {
            var filter = Builders<BsonDocument>.Filter.Eq("_id", id);
            var update = Builders<BsonDocument>.Update.Set("Name", name);

            try
            {
                var collection = Connection.GetCollection<BsonDocument>(PlayersCollectionName);
                collection.UpdateOne(filter, update);
                return true;
            }
            catch (TimeoutException e)
            {
                Log.Error("Received time out for updating player => ", e);
                return false;
            }
            catch (Exception e)
            {
                Log.Error("Failed to update player => ", e);
                return false;
            }
        }

        public async Task<bool> UpdatePlayerAsync(string id, string teamId, string name)
        {
            var filter = Builders<BsonDocument>.Filter.Eq("_id", id);
            var update = Builders<BsonDocument>.Update.Set("Name", name);

            try
            {
                var collection = Connection.GetCollection<BsonDocument>(PlayersCollectionName);
                await collection.UpdateOneAsync(filter, update).TimeoutAfter(TimeoutMilisec);
                return true;
            }
            catch (TimeoutException e)
            {
                Log.Error("Received time out for updating player async => ", e);
                return false;
            }
            catch (Exception e)
            {
                Log.Error("Failed to update player async => ", e);
                return false;
            }
        }

        public bool DeleteTeam(string id)
        {
            try
            {
                TeamCollection.DeleteOne(a => a.Id == id);
                return true;
            }
            catch (TimeoutException e)
            {
                Log.Error("Received time out for deleting team => ", e);
                return false;
            }
            catch (Exception e)
            {
                Log.Error("Failed to delete team => ", e);
                return false;
            }
        }

        public async Task<bool> DeleteTeamAsync(string id)
        {
            try
            {
                await TeamCollection.DeleteOneAsync(a => a.Id == id).TimeoutAfter(TimeoutMilisec);
                return true;
            }
            catch (TimeoutException e)
            {
                Log.Error("Received time out for deleting team async => ", e);
                return false;
            }
            catch (Exception e)
            {
                Log.Error("Failed to delete team async => ", e);
                return false;
            }
        }

        public bool DeletePlayer(string id)
        {
            try
            {
                PlayerCollection.DeleteOne(a => a.Id == id);
                return true;
            }
            catch (TimeoutException e)
            {
                Log.Error("Received time out for deleting player => ", e);
                return false;
            }
            catch (Exception e)
            {
                Log.Error("Failed to delete player => ", e);
                return false;
            }
        }

        public async Task<bool> DeletePlayerAsync(string id)
        {
            try
            {
                await PlayerCollection.DeleteOneAsync(a => a.Id == id).TimeoutAfter(TimeoutMilisec);
                return true;
            }
            catch (TimeoutException e)
            {
                Log.Error("Received time out for deleting player async => ", e);
                return false;
            }
            catch (Exception e)
            {
                Log.Error("Failed to delete player async => ", e);
                return false;
            }
        }

        public bool ChangePlayerTeam(string playerId, string teamId)
        {
            var filter = Builders<BsonDocument>.Filter.Eq("_id", playerId);
            var update = Builders<BsonDocument>.Update.Set("TeamId", teamId);

            try
            {
                var collection = Connection.GetCollection<BsonDocument>(PlayersCollectionName);
                collection.UpdateOne(filter, update);
                return true;
            }
            catch (TimeoutException e)
            {
                Log.Error("Received time out for changing player team => ", e);
                return false;
            }
            catch (Exception e)
            {
                Log.Error("Failed to change player team => ", e);
                return false;
            }
        }

        public async Task<bool> ChangePlayerTeamAsync(string playerId, string teamId)
        {
            var filter = Builders<BsonDocument>.Filter.Eq("_id", playerId);
            var update = Builders<BsonDocument>.Update.Set("TeamId", teamId);

            try
            {
                var collection = Connection.GetCollection<BsonDocument>(PlayersCollectionName);
                await collection.UpdateOneAsync(filter, update).TimeoutAfter(TimeoutMilisec);
                return true;
            }
            catch (TimeoutException e)
            {
                Log.Error("Received time out for changing player team async => ", e);
                return false;
            }
            catch (Exception e)
            {
                Log.Error("Failed to change player team => async ", e);
                return false;
            }
        }
    }
}
