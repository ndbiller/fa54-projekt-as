using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TeamManager.Models.ResourceData;

namespace TeamManager.Database
{
    public class DBLayerMongo : IDataLayer
    {
        // get the mlab db servers credentials from environment variables (set them with .env.bat)
        internal static readonly string MLAB_USERNAME = Environment.GetEnvironmentVariable("MLAB_USERNAME");
        internal static readonly string MLAB_PASSWORD = Environment.GetEnvironmentVariable("MLAB_PASSWORD");
        internal static readonly string MLAB_URI = Environment.GetEnvironmentVariable("MLAB_URI");
        internal static readonly string MLAB_PORT = Environment.GetEnvironmentVariable("MLAB_PORT");
        internal static readonly string MLAB_DATABASE_NAME = Environment.GetEnvironmentVariable("MLAB_DATABASE_NAME");


#if MONGO_DB_LOCAL
// connect to local mongodb server
        private static string databaseName = "teamplayer";
        private static string connectionString = "mongodb://localhost:27017";
#else
        // connect to mLab mongodb server
        private static string databaseName = MLAB_DATABASE_NAME;
        private static string connectionString = "mongodb://" + MLAB_USERNAME + ":" + MLAB_PASSWORD + "@" + MLAB_URI + ":" + MLAB_PORT + "/" + MLAB_DATABASE_NAME;
#endif
        private static MongoClient Client { get; set; }
        public static IMongoDatabase Database { get; private set; }
        public static IMongoCollection<Team> TeamCollection { get; set; }
        public static IMongoCollection<Player> PlayerCollection { get; set; }

        public DBLayerMongo() : base()
        {
            this.ConnectDB();
        }

        public void ConnectDB()
        {
            Client = new MongoClient(connectionString);
            Database = Client.GetDatabase(databaseName);
            TeamCollection = Database.GetCollection<Team>("team");
            PlayerCollection = Database.GetCollection<Player>("player");
        }

        public bool CreatePlayer(string name, string teamId)
        {
            DBLayerMongo.PlayerCollection.InsertOne(new Player(name, teamId));
            return true;
        }

        public bool CreateTeam(string name)
        {
            DBLayerMongo.TeamCollection.InsertOne(new Team(name));
            return true;
        }

        public bool DeletePlayer(string id)
        {
            DBLayerMongo.PlayerCollection.DeleteOne(a => a.Id == id);
            return true;
        }

        public bool DeleteTeam(string id)
        {
            DBLayerMongo.TeamCollection.DeleteOne(a => a.Id == id);
            return true;
        }

        public Player ReadPlayer(string id)
        {
            Player player = DBLayerMongo.PlayerCollection.Find(p => p.Id == id).First<Player>();
            return player;
        }

        public Team ReadTeam(string id)
        {
            Team teams = DBLayerMongo.TeamCollection.Find(t => t.Id == id).First<Team>();
            return teams;
        }

        public List<Player> ShowPlayers(string teamId)
        {
            List<Player> players = DBLayerMongo.PlayerCollection.Find(p => p.TeamId == teamId).ToList();
            return players;
        }

        public async Task<bool> UpdatePlayerAsync(string id, string name)
        {
            var collection = Database.GetCollection<BsonDocument>("player");
            var filter = Builders<BsonDocument>.Filter.Eq("_id", id);
            var update = Builders<BsonDocument>.Update.Set("Name", name);
            var result = await collection.UpdateOneAsync(filter, update);
            return true;
        }

        public async Task<bool> UpdatePlayerAsync(string id, string teamId, string name)
        {
            var collection = Database.GetCollection<BsonDocument>("player");
            var filter = Builders<BsonDocument>.Filter.Eq("_id", id);
            var update = Builders<BsonDocument>.Update.Set("Name", name);
            var result = await collection.UpdateOneAsync(filter, update);
            return true;
        }

        public async Task<bool> UpdateTeamAsync(string id, string name)
        {
            var collection = Database.GetCollection<BsonDocument>("team");
            var filter = Builders<BsonDocument>.Filter.Eq("_id", id);
            var update = Builders<BsonDocument>.Update.Set("Name", name);
            var result = await collection.UpdateOneAsync(filter, update);
            return true;
        }

        public List<Player> Players()
        {
            List<Player> players = DBLayerMongo.PlayerCollection.Find(_ => true).ToList();
            return players;
        }

        public List<Team> Teams()
        {
            List<Team> teams = DBLayerMongo.TeamCollection.Find(_ => true).ToList();
            return teams;
        }

        public bool ChangePlayerTeam(string playerId, string teamId)
        {
            var collection = Database.GetCollection<BsonDocument>("player");
            var filter = Builders<BsonDocument>.Filter.Eq("_id", playerId);
            var update = Builders<BsonDocument>.Update.Set("TeamId", teamId);
            collection.UpdateOne(filter, update);
            return true;
        }
    }
}
