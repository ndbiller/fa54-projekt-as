using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using log4net;
using TeamManager.Models.ResourceData;
using TeamManager.Utilities;
using Npgsql;

namespace TeamManager.Database
{
    public sealed class DbLayerSql : IDataLayer
    {
        /// <summary> Logger instance of the class <see cref="DbLayerSql"/> </summary>
        private static readonly ILog Log = Logger.GetLogger();

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

        public DbLayerSql() : base()
        {
            Console.Clear();
            Connection = new NpgsqlConnection(connectionString);
            Console.WriteLine("Connection created.");
            //ConnectDB();
        }

        public void ConnectDb()
        {
            Connection.Open();
            Console.WriteLine("\nConnection opened.");
        }

        public void DisconnectDb()
        {
            Connection.Close();
            Console.WriteLine("Connection closed.");
        }

        public void ExecuteSQL(string sql)
        {
            // execute custom sql code
            var customCommand = new NpgsqlCommand(sql, Connection);
            ConnectDb();
            customCommand.ExecuteNonQuery();
            DisconnectDb();
            Console.WriteLine("Command executed: \n" + sql);
        }


        public void ConnectDb()
        {
            throw new NotImplementedException();
        }

        public List<Team> Teams()
        {
            try
            {
                throw new NotImplementedException();

                List<Team> teams = null;
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
                return await Task.Factory.StartNew(Teams);
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
                throw new NotImplementedException();

                List<Player> players = null;
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
                return await Task.Factory.StartNew(Players);
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
                throw new NotImplementedException();

                List<Player> players = null;
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
                return await Task.Factory.StartNew(() => ShowPlayers(teamId));
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
                throw new NotImplementedException();

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
                await Task.Factory.StartNew(() => CreateTeamAsync(name));
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
                throw new NotImplementedException();

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
                await Task.Factory.StartNew(() => CreatePlayer(name, teamId));
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
                throw new NotImplementedException();

                return null;
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
                return await Task.Factory.StartNew(() => ReadTeam(id));
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
                throw new NotImplementedException();

                return null;
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
                return await Task.Factory.StartNew(() => ReadPlayer(id));
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

            try
            {
                throw new NotImplementedException();

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
            try
            {
                await Task.Factory.StartNew(() => UpdateTeamAsync(id, name));
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

            try
            {
                throw new NotImplementedException();

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
            try
            {
                await Task.Factory.StartNew(() => UpdatePlayerAsync(id, name));
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

        public bool UpdatePlayer(string id, string teamId, string name)
        {

            try
            {
                throw new NotImplementedException();

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
            try
            {
                await Task.Factory.StartNew(() => UpdatePlayerAsync(id, teamId, name));
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
                throw new NotImplementedException();

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
                await Task.Factory.StartNew(() => DeleteTeamAsync(id));
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
                throw new NotImplementedException();

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
                await Task.Factory.StartNew(() => DeletePlayerAsync(id));
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

            try
            {
                throw new NotImplementedException();


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
            try
            {
                await Task.Factory.StartNew(() => ChangePlayerTeamAsync(playerId, teamId));
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
