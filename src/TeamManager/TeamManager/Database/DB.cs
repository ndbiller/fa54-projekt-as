using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamManager.Main.ResourceData;

namespace TeamManager.Database
{
    static public class DB
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

        static private MongoClient Client = new MongoClient(connectionString);
        static public IMongoDatabase Database { get; private set; } = Client.GetDatabase(databaseName);
        static public IMongoCollection<Team> Teams { get; set; } = Database.GetCollection<Team>("team");
        static public IMongoCollection<Player> Players { get; set; } = Database.GetCollection<Player>("player");
    }
}
