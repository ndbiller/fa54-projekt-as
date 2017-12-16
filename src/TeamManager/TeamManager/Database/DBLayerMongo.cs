using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using TeamManager.Models.ResourceData;
using TeamManager.Utilities;

namespace TeamManager.Database
{
    public class DBLayerMongo : IDataLayer
    {
        // get the mlab db servers credentials from environment variables (set them with .env.bat)
        internal static readonly string MLAB_USERNAME;
        internal static readonly string MLAB_PASSWORD;
        internal static readonly string MLAB_URI;
        internal static readonly string MLAB_PORT;
        internal static readonly string MLAB_DATABASE_NAME;

        private static readonly string DatabaseName;
        private static readonly string ConnectionString;

        private static MongoClient Client { get; set; }
        public static IMongoDatabase Database { get; private set; }
        public static IMongoCollection<Team> TeamCollection { get; set; }
        public static IMongoCollection<Player> PlayerCollection { get; set; }

        private const string TeamsCollectionName = "team";
        private const string PlayersCollectionName = "player";

        private const int TimeoutMilisec = 3000;

        static DBLayerMongo()
        {
#if MONGO_DB_LOCAL
            // connect to local mongodb server
            databaseName     = "teamplayer";
            connectionString = "mongodb://localhost:27017";
#else
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
                Debug.WriteLine("[cctor_DBLayerMongo] - Failed to retrieve environment variables => " + e.StackTrace);
            }

            // connect to mLab mongodb server
            DatabaseName     = MLAB_DATABASE_NAME;
            ConnectionString = "mongodb://" + MLAB_USERNAME + ":" + MLAB_PASSWORD + "@" + MLAB_URI + ":" + MLAB_PORT + "/" + MLAB_DATABASE_NAME;
#endif
        }

        public DBLayerMongo()
        {
            ConnectDB();
        }

        public void ConnectDB()
        {
            try
            {
                Client = new MongoClient(ConnectionString);

                Database = Client.GetDatabase(DatabaseName);
                TeamCollection = Database.GetCollection<Team>(TeamsCollectionName);
                PlayerCollection = Database.GetCollection<Player>(PlayersCollectionName);
            }
            catch (Exception e)
            {
                Debug.WriteLine("[ConnectDB] - Failed to initialize or create connection to mongodb => " + e.StackTrace);
                throw;
            }
        }

        public bool CreatePlayer(string name, string teamId)
        {
            try
            {
                PlayerCollection.InsertOne(new Player(name, teamId));
                return true;
            }
            catch (Exception e)
            {
                Debug.WriteLine("[CreatePlayer] - Failed to create player => " + e.Source);
                return false;
            }
        }

        public bool CreateTeam(string name)
        {
            try
            {
                TeamCollection.InsertOne(new Team(name));
                return true;
            }
            catch (Exception e)
            {
                Debug.WriteLine("[CreateTeam] - Failed to create team => " + e.Source);
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
            catch (Exception e)
            {
                Debug.WriteLine("[DeletePlayer] - Failed to delete player => " + e.Source);
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
            catch (Exception e)
            {
                Debug.WriteLine("[DeleteTeam] - Failed to delete team => " + e.Source);
                return false;
            }
        }

        public Player ReadPlayer(string id)
        {
            try
            {
                var results = PlayerCollection.Find(p => p.Id == id);
                Player player = results.First<Player>();
                return player;
            }
            catch (Exception e)
            {
                Debug.WriteLine("[ReadPlayer] - Failed to read player => " + e.Source);
                return null;
            }
        }

        public Team ReadTeam(string id)
        {
            try
            {
                var results = TeamCollection.Find(t => t.Id == id);
                Team team = results.First<Team>();
                return team;
            }
            catch (Exception e)
            {
                Debug.WriteLine("[ReadTeam] - Failed to read team => " + e.Source);
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
            catch (Exception e)
            {
                Debug.WriteLine("[ShowPlayers] - Failed to retrieve players => " + e.Source);
                return null;
            }
        }

        public bool UpdatePlayer(string id, string name)
        {
            var filter = Builders<BsonDocument>.Filter.Eq("_id", id);
            var update = Builders<BsonDocument>.Update.Set("Name", name);

            try
            {
                var collection = Database.GetCollection<BsonDocument>(PlayersCollectionName);
                return collection.UpdateOneAsync(filter, update).Wait(TimeoutMilisec);
            }
            catch (Exception e)
            {
                Debug.WriteLine("[UpdatePlayer] - Failed to update player => " + e.Source);
            }

            return false;
        }

        public async Task<bool> UpdatePlayerAsync(string id, string name)
        {
            try
            {
                await Task.Factory.StartNew(() => UpdatePlayer(id, name)).TimeoutAfter(TimeoutMilisec);
                return true;
            }
            catch (Exception e)
            {
                Debug.WriteLine("[UpdatePlayerAsync] - Failed to update player async => " + e.Source);
            }

            return false;
        }

        public bool UpdatePlayer(string id, string teamId, string name)
        {
            var filter = Builders<BsonDocument>.Filter.Eq("_id", id);
            var update = Builders<BsonDocument>.Update.Set("Name", name);

            try
            {
                var collection = Database.GetCollection<BsonDocument>(PlayersCollectionName);
                return collection.UpdateOneAsync(filter, update).Wait(TimeoutMilisec);
            }
            catch (Exception e)
            {
                Debug.WriteLine("[UpdatePlayer] - Failed to update player => " + e.Source);
            }

            return false;
        }

        public async Task<bool> UpdatePlayerAsync(string id, string teamId, string name)
        {
            try
            {
                await Task.Factory.StartNew(() => UpdatePlayer(id, name)).TimeoutAfter(TimeoutMilisec);
                return true;
            }
            catch (Exception e)
            {
                Debug.WriteLine("[UpdatePlayerAsync] - Failed to update player async => " + e.Source);
            }

            return false;
        }

        public bool UpdateTeam(string id, string name)
        {
            var filter = Builders<BsonDocument>.Filter.Eq("_id", id);
            var update = Builders<BsonDocument>.Update.Set("Name", name);

            try
            {
                var collection = Database.GetCollection<BsonDocument>(TeamsCollectionName);
                return collection.UpdateOneAsync(filter, update).Wait(TimeoutMilisec);
            }
            catch (Exception e)
            {
                Debug.WriteLine("[UpdateTeam] - Failed to update team => " + e.Source);
            }

            return false;
        }

        public async Task<bool> UpdateTeamAsync(string id, string name)
        {
            try
            {
                await Task.Factory.StartNew(() => UpdateTeam(id, name)).TimeoutAfter(TimeoutMilisec);
                return true;
            }
            catch (Exception e)
            {
                Debug.WriteLine("[UpdateTeamAsync] - Failed to update team async => " + e.Source);
            }

            return false;
        }

        public List<Player> Players()
        {
            try
            {
                List<Player> players = PlayerCollection.Find(_ => true).ToList();
                return players;
            }
            catch (Exception e)
            {
                Debug.WriteLine("[Players] - Failed to retrieve players => " + e.Source);
                return null;
            }
        }

        public List<Team> Teams()
        {
            try
            {
                List<Team> teams = TeamCollection.Find(_ => true).ToList();
                return teams;
            }
            catch (Exception e)
            {
                Debug.WriteLine("[Teams] - Failed to retrieve teams => " + e.Source);
                return null;
            }

        }

        public bool ChangePlayerTeam(string playerId, string teamId)
        {
            var filter = Builders<BsonDocument>.Filter.Eq("_id", playerId);
            var update = Builders<BsonDocument>.Update.Set("TeamId", teamId);

            try
            {
                var collection = Database.GetCollection<BsonDocument>(PlayersCollectionName);
                collection.UpdateOne(filter, update);
                return true;
            }
            catch (Exception e)
            {
                Debug.WriteLine("[ChangePlayerTeam] - Failed to change player team => " + e.Source);
                return false;
            }
        }


    }
}
