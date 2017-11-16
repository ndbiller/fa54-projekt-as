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

        // connect to local mongodb server
        // static private string databaseName = "teamplayer";
        // static private string connectionString = "mongodb://localhost:27017";

        // connect to mLab mongodb server
        static private string databaseName = MLAB_DATABASE_NAME;
        static private string connectionString = "mongodb://"+MLAB_USERNAME+":"+MLAB_PASSWORD+"@"+MLAB_URI+":"+MLAB_PORT+"/"+MLAB_DATABASE_NAME;

        static private MongoClient Client { get; set; }
        static public IMongoDatabase Database { get; private set; } = Client.GetDatabase(databaseName);
        static public IMongoCollection<Team> Teams { get; set; } = Database.GetCollection<Team>("team");
        static public IMongoCollection<Player> Players { get; set; } = Database.GetCollection<Player>("player");

        public void ConnectDB(string connectionString)
        {
            Client = new MongoClient(connectionString);
        }

        public bool CreatePlayer(string name, string id)
        {
            DBLayerMongo.Players.InsertOne(new Player()
            {
                Name = name,
                Team = id
            });
            return true;
        }

        public bool CreateTeam(string name)
        {
            DBLayerMongo.Teams.InsertOne(new Team()
            {
                Name = name
            });
            return true;
        }

        public bool DeletePlayer(string id)
        {
            DBLayerMongo.Players.DeleteOne(a => a.Id == id);
            return true;
        }

        public bool DeleteTeam(string id)
        {
            DBLayerMongo.Teams.DeleteOne(a => a.Id == id);
            return true;
        }

        public Player ReadPlayer(string id)
        {
            Player player = DBLayerMongo.Players.Find(p => p.Id == id).First<Player>();
            return player;
        }

        public Team ReadTeam(string id)
        {
            Team teams = DBLayerMongo.Teams.Find(t => t.Id == id).First<Team>();
            return teams;
        }

        public List<Player> ShowPlayers(string teamId)
        {
            List<Player> players = DBLayerMongo.Players.Find(p => p.Team == teamId).ToList();
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

        public async Task<bool> UpdateTeamAsync(string id, string name)
        {
            var collection = Database.GetCollection<BsonDocument>("team");
            var filter = Builders<BsonDocument>.Filter.Eq("_id", id);
            var update = Builders<BsonDocument>.Update.Set("Name", name);
            var result = await collection.UpdateOneAsync(filter, update);
            return true;
        }

        List<Player> IDataLayer.Players()
        {
            List<Player> players = DBLayerMongo.Players.Find(_ => true).ToList();
            return players;
        }

        List<Team> IDataLayer.Teams()
        {
            List<Team> teams = DBLayerMongo.Teams.Find(_ => true).ToList();
            return teams;
        }
    }
}
