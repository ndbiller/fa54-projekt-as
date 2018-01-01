using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TeamManager.Models.ResourceData;
using Npgsql;

namespace TeamManager.Database
{
    public class DBLayerSql : IDataLayer
    {
        // get the postgresql db servers credentials from environment variables (set them with .env.bat)
        internal static readonly string POSTGRESQL_USERNAME = Environment.GetEnvironmentVariable("POSTGRESQL_USERNAME");
        internal static readonly string POSTGRESQL_PASSWORD = Environment.GetEnvironmentVariable("POSTGRESQL_PASSWORD");
        internal static readonly string POSTGRESQL_URI = Environment.GetEnvironmentVariable("POSTGRESQL_URI");
        internal static readonly string POSTGRESQL_PORT = Environment.GetEnvironmentVariable("POSTGRESQL_PORT");
        internal static readonly string POSTGRESQL_DATABASE_NAME = Environment.GetEnvironmentVariable("POSTGRESQL_DATABASE_NAME");

        // connect to heroku postgresql server
        // PostgeSQL-style connection string
        private static string connectionString = String.Format("Server={0};Port={1};User Id={2};Password={3};Database={4};", POSTGRESQL_URI, POSTGRESQL_PORT, POSTGRESQL_USERNAME, POSTGRESQL_PASSWORD, POSTGRESQL_DATABASE_NAME);

        //private static MongoClient Client { get; set; }
        //public static IMongoDatabase Database { get; private set; }
        //public static IMongoCollection<Team> TeamCollection { get; set; }
        //public static IMongoCollection<Player> PlayerCollection { get; set; }

        public DBLayerSql() : base()
        {
            ConnectDB();
        }

        public void ConnectDB()
        {
            //throw new NotImplementedException();
            NpgsqlConnection connection = new NpgsqlConnection(connectionString);
            connection.Open();
            string sql = "SELECT * FROM team";
            NpgsqlDataAdapter dataAdaptor = new NpgsqlDataAdapter(sql, connection);
            connection.Close();
        }

        public bool CreatePlayer(string name, string id)
        {
            throw new NotImplementedException();
        }

        public bool CreateTeam(string name)
        {
            throw new NotImplementedException();
        }

        public bool DeletePlayer(string id)
        {
            throw new NotImplementedException();
        }

        public bool DeleteTeam(string id)
        {
            throw new NotImplementedException();
        }

        public List<Player> Players()
        {
            throw new NotImplementedException();
        }

        public Player ReadPlayer(string id)
        {
            throw new NotImplementedException();
        }

        public Team ReadTeam(string id)
        {
            throw new NotImplementedException();
        }

        public List<Player> ShowPlayers(string teamId)
        {
            throw new NotImplementedException();
        }

        public List<Team> Teams()
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdatePlayerAsync(string id, string name)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdatePlayerAsync(string id, string teamId, string name)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateTeamAsync(string id, string name)
        {
            throw new NotImplementedException();
        }

        public bool ChangePlayerTeam(string playerId, string teamId)
        {
            throw new NotImplementedException();
        }
    }
}
