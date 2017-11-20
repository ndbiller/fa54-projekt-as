using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamManager.Models.ResourceData;

namespace TeamManager.Database
{
    public class DBLayerMongo : IDataLayer
    {
        // get the mlab db servers credentials from environment variables (set them with .env.bat)
        internal readonly static string MLAB_USERNAME = Environment.GetEnvironmentVariable("MLAB_USERNAME");
        internal readonly static string MLAB_PASSWORD = Environment.GetEnvironmentVariable("MLAB_PASSWORD");
        internal readonly static string MLAB_URI = Environment.GetEnvironmentVariable("MLAB_URI");
        internal readonly static string MLAB_PORT = Environment.GetEnvironmentVariable("MLAB_PORT");
        internal readonly static string MLAB_DATABASE_NAME = Environment.GetEnvironmentVariable("MLAB_DATABASE_NAME");


#if MONGO_DB_LOCAL
// connect to local mongodb server
        static private string databaseName = "teamplayer";
        static private string connectionString = "mongodb://localhost:27017";
#else
        // connect to mLab mongodb server
        static private string databaseName = MLAB_DATABASE_NAME;
        static private string connectionString = "mongodb://" + MLAB_USERNAME + ":" + MLAB_PASSWORD + "@" + MLAB_URI + ":" + MLAB_PORT + "/" + MLAB_DATABASE_NAME;
#endif
        static private MongoClient Client { get; set; }
        static public IMongoDatabase Database { get; private set; }
        static public IMongoCollection<Team> TeamCollection { get; set; }
        static public IMongoCollection<Player> PlayerCollection { get; set; }

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
    }
}
