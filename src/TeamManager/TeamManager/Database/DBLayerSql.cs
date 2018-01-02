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
        internal static readonly String POSTGRESQL_USERNAME = Environment.GetEnvironmentVariable("POSTGRESQL_USERNAME");
        internal static readonly String POSTGRESQL_PASSWORD = Environment.GetEnvironmentVariable("POSTGRESQL_PASSWORD");
        internal static readonly String POSTGRESQL_URI = Environment.GetEnvironmentVariable("POSTGRESQL_URI");
        internal static readonly String POSTGRESQL_PORT = Environment.GetEnvironmentVariable("POSTGRESQL_PORT");
        internal static readonly String POSTGRESQL_DATABASE_NAME = Environment.GetEnvironmentVariable("POSTGRESQL_DATABASE_NAME");

        // connect to heroku postgresql server
        // PostgeSQL-style connection string
        internal static readonly String connectionString = "Server="+POSTGRESQL_URI+
            ";Port="+POSTGRESQL_PORT+
            ";User Id="+POSTGRESQL_USERNAME+
            ";Password="+POSTGRESQL_PASSWORD+
            ";Database="+POSTGRESQL_DATABASE_NAME+
            ";SSL Mode=Require;"+
            "Trust Server Certificate=true;";

        private static NpgsqlConnection Connection { get; set; }
        //public static IMongoDatabase Database { get; private set; }
        //public static IMongoCollection<Team> TeamCollection { get; set; }
        //public static IMongoCollection<Player> PlayerCollection { get; set; }

        public DBLayerSql() : base()
        {
            Console.Clear();
            Connection = new NpgsqlConnection(connectionString);
            Console.WriteLine("Connection created.");
            //ConnectDB();
        }

        public void ConnectDB()
        {
            Connection.Open();
            Console.WriteLine("\nConnection opened.");
        }

        public void DisconnectDB()
        {
            Connection.Close();
            Console.WriteLine("Connection closed.");
        }

        public void ExecuteSQL(string sql)
        {
            // execute custom sql code
            var customCommand = new NpgsqlCommand(sql, Connection);
            ConnectDB();
            customCommand.ExecuteNonQuery();
            DisconnectDB();
            Console.WriteLine("Command executed: \n" + sql);
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
