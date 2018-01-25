using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using log4net;
using TeamManager.Models.ResourceData;
using TeamManager.Utilities;
using Npgsql;

namespace TeamManager.Database
{
    /// <summary>
    /// <see cref="DbLayerSql"/> will contain relational data.
    /// For more information, please refer to:
    /// <see cref="DatabaseType"/>
    /// <see cref="IDataLayer"/>
    /// </summary>
    public sealed class DbLayerSql : IDataLayer
    {
        /// <summary> Logger instance of the class <see cref="DbLayerSql"/> </summary>
        private static readonly ILog Log = Logger.GetLogger();

        // get the postgresql db servers credentials from environment variables (set them with .env.bat)
        internal static readonly string POSTGRESQL_USERNAME;
        internal static readonly string POSTGRESQL_PASSWORD;
        internal static readonly string POSTGRESQL_URI;
        internal static readonly string POSTGRESQL_PORT;
        internal static readonly string POSTGRESQL_DATABASE_NAME;

        // connect to heroku postgresql server
        // PostgeSQL-style connection string
        internal static readonly string ConnectionString;

        private static NpgsqlConnection Connection { get; set; }

        public string TeamsCollectionName => "team";
        public string PlayersCollectionName => "player";

        public int TimeoutMilisec => 3000;



        static DbLayerSql()
        {
#if DB_LOCAL
            Log.Info("Using PostgreSql local server connection.");
            // connect to local PostgreSql server
            POSTGRESQL_USERNAME      = "localuser";
            POSTGRESQL_PASSWORD      = "localpass";
            POSTGRESQL_URI           = "127.0.0.1";
            POSTGRESQL_PORT          = "5432";
            POSTGRESQL_DATABASE_NAME = "localdb";

            ConnectionString = "Server=" + POSTGRESQL_URI +
                               ";Port=" + POSTGRESQL_PORT +
                               ";User Id=" + POSTGRESQL_USERNAME +
                               ";Password=" + POSTGRESQL_PASSWORD +
                               ";Database=" + POSTGRESQL_DATABASE_NAME +
                               ";";
#else
            Log.Info("Using PostgreSql online server connection.");

            try
            {
                POSTGRESQL_USERNAME      = Environment.GetEnvironmentVariable("POSTGRESQL_USERNAME");
                POSTGRESQL_PASSWORD      = Environment.GetEnvironmentVariable("POSTGRESQL_PASSWORD");
                POSTGRESQL_URI           = Environment.GetEnvironmentVariable("POSTGRESQL_URI");
                POSTGRESQL_PORT          = Environment.GetEnvironmentVariable("POSTGRESQL_PORT");
                POSTGRESQL_DATABASE_NAME = Environment.GetEnvironmentVariable("POSTGRESQL_DATABASE_NAME");
            }
            catch (Exception e)
            {
                Log.Error("cctor - Failed to retrieve environment variables for mongo-db connection string => ", e);
            }

            ConnectionString = "Server="    + POSTGRESQL_URI +
                               ";Port="     + POSTGRESQL_PORT +
                               ";User Id="  + POSTGRESQL_USERNAME +
                               ";Password=" + POSTGRESQL_PASSWORD +
                               ";Database=" + POSTGRESQL_DATABASE_NAME +
                               ";SSL Mode=Require;" +
                               "Trust Server Certificate=true;";
#endif
        }


        public DbLayerSql()
        {
            CreateConnection();
        }

        public void CreateConnection()
        {
            try
            {
                Connection = new NpgsqlConnection(ConnectionString);

                Connection.Open();
                Thread.Sleep(75);
                Connection.Close();
            }
            catch (Exception e)
            {
                Log.Fatal("Failed to initialize or create connection to postgreSql => ", e);
                throw;
            }

            Log.Info("Connection created.");
        }

        public void ExecuteSql(string query)
        {
            // execute custom query code
            NpgsqlCommand customCommand = new NpgsqlCommand(query, Connection);
            Connection.Open();
            customCommand.ExecuteNonQuery();
            Connection.Close();
            Log.Info("Query executed: \n" + query);
        }

        public List<Team> Teams()
        {
            List<Team> teams = new List<Team>();

            try
            {
                Connection.Open();
                // Retrieve all rows
                string query = $"SELECT id, TRIM(name) FROM {TeamsCollectionName}";
                using (NpgsqlCommand cmd = new NpgsqlCommand(query, Connection))
                using (NpgsqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Team team = new Team(null)
                        {
                            Id   = reader.GetString(0),
                            Name = reader.GetString(1)
                        };
                        teams.Add(team);
                    }
                }
                Connection.Close();
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

            return teams;
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
            List<Player> players = new List<Player>();

            try
            {
                Connection.Open();
                // Retrieve all rows
                string query = $"SELECT id, TRIM(name), team_id FROM {PlayersCollectionName}";
                using (NpgsqlCommand cmd = new NpgsqlCommand(query, Connection))
                using (NpgsqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Player player = new Player(null)
                        {
                            Id     = reader.GetString(0),
                            Name   = reader.GetString(1),
                            TeamId = reader.GetString(2)
                        };
                        players.Add(player);
                    }
                }
                Connection.Close();                
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

            return players;
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
            List<Player> players = new List<Player>();

            try
            {
                Connection.Open();
                // Retrieve all rows with matching team_id
                string query = $"SELECT id, TRIM(name), team_id FROM {PlayersCollectionName} WHERE team_id = {teamId}";
                using (NpgsqlCommand cmd = new NpgsqlCommand(query, Connection))
                using (NpgsqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Player player = new Player(null)
                        {
                            Id     = reader.GetString(0),
                            Name   = reader.GetString(1),
                            TeamId = reader.GetString(2)
                        };
                        players.Add(player);
                    }
                }
                Connection.Close();   
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

            return players;
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
                Connection.Open();
                // gets last id from db
                string id = string.Empty;
                string query = $"SELECT max(id) FROM {TeamsCollectionName}";
                using (NpgsqlCommand cmd = new NpgsqlCommand(query, Connection))
                using (NpgsqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string value = reader.GetString(0);
                        int x = int.Parse(value);
                        string nextValue = (x + 1).ToString();
                        id = nextValue;
                    }
                }

                // write row to db
                string query2 = $"INSERT INTO {TeamsCollectionName} (id, name) VALUES ({id}, \'{name}\')";
                using (NpgsqlCommand cmd = new NpgsqlCommand(query2, Connection))
                {
                    cmd.ExecuteNonQuery();
                }
                Connection.Close();
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

            return true;
        }

        public async Task<bool> CreateTeamAsync(string name)
        {
            try
            {
                await Task.Factory.StartNew(() => CreateTeam(name));
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

            return true;
        }

        public bool CreatePlayer(string name, string teamId)
        {
            try
            {
                Connection.Open();
                // get last id from db
                string id = string.Empty;
                string query = $"SELECT max(id) FROM {PlayersCollectionName}";
                using (NpgsqlCommand cmd = new NpgsqlCommand(query, Connection))
                using (NpgsqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string value = reader.GetString(0);
                        int x = int.Parse(value);
                        string nextValue = (x + 1).ToString();
                        id = nextValue;
                    }
                }
                 
                // write row to db
                string query2 = $"INSERT INTO {PlayersCollectionName} (id, name, team_id) VALUES ({id}, \'{name}\', {teamId})";
                using (var cmd = new NpgsqlCommand(query2, Connection))
                {
                    cmd.ExecuteNonQuery();
                }
                Connection.Close();
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

            return true;
        }

        public async Task<bool> CreatePlayerAsync(string name, string teamId)
        {
            try
            {
                await Task.Factory.StartNew(() => CreatePlayer(name, teamId));
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

            return true;
        }

        public Team ReadTeam(string id)
        {
            Team team = new Team(null);

            try
            {
                Connection.Open();
                // Retrieve all rows with matching id
                string query = $"SELECT id, TRIM(name) FROM {TeamsCollectionName} WHERE id = {id}";
                using (NpgsqlCommand cmd = new NpgsqlCommand(query, Connection))
                using (NpgsqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        team.Id = reader.GetString(0);
                        team.Name = reader.GetString(1);
                    }
                }
                Connection.Close();
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

            return team;
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
            Player player = new Player(null);

            try
            {
                Connection.Open();
                // Retrieve all rows with matching id
                string query = $"SELECT id, TRIM(name), team_id FROM {PlayersCollectionName} WHERE id = {id}";
                using (NpgsqlCommand cmd = new NpgsqlCommand(query, Connection))
                using (NpgsqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        player.Id = reader.GetString(0);
                        player.Name = reader.GetString(1);
                        player.TeamId = reader.GetString(2);
                    }
                }
                Connection.Close();
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

            return player;
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
                Connection.Open();
                // write row to db
                string query = $"UPDATE {TeamsCollectionName} SET name = '{name}' WHERE id = {id}";
                using (NpgsqlCommand cmd = new NpgsqlCommand(query, Connection))
                {
                    cmd.ExecuteNonQuery();
                }
                Connection.Close();
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

            return true;
        }

        public async Task<bool> UpdateTeamAsync(string id, string name)
        {
            try
            {
                await Task.Factory.StartNew(() => UpdateTeam(id, name));
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

            return true;
        }

        public bool UpdatePlayer(string id, string name)
        {
            try
            {
                Connection.Open();
                // write row to db
                string query = $"UPDATE {PlayersCollectionName} SET name = \'{name}\' WHERE id = {id}";
                using (NpgsqlCommand cmd = new NpgsqlCommand(query, Connection))
                {
                    cmd.ExecuteNonQuery();
                }
                Connection.Close();
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

            return true;
        }

        public async Task<bool> UpdatePlayerAsync(string id, string name)
        {
            try
            {
                await Task.Factory.StartNew(() => UpdatePlayer(id, name));
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

            return true;
        }

        public bool UpdatePlayer(string id, string teamId, string name)
        {

            try
            {
                Connection.Open();
                // write row to db
                string query = $"UPDATE {PlayersCollectionName} SET name = \'{name}\', team_id = \'{teamId}\' WHERE id = {id}";
                using (NpgsqlCommand cmd = new NpgsqlCommand(query, Connection))
                {
                    cmd.ExecuteNonQuery();
                }
                Connection.Close();
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

            return true;
        }

        public async Task<bool> UpdatePlayerAsync(string id, string teamId, string name)
        {
            try
            {
                await Task.Factory.StartNew(() => UpdatePlayer(id, teamId, name));
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

            return true;
        }

        public bool DeleteTeam(string id)
        {
            try
            {
                Connection.Open();
                // delete row from db
                string query = $"DELETE FROM {TeamsCollectionName} WHERE id = {id}";
                using (NpgsqlCommand cmd = new NpgsqlCommand(query, Connection))
                {
                    cmd.ExecuteNonQuery();
                }
                Connection.Close();
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

            return true;
        }

        public async Task<bool> DeleteTeamAsync(string id)
        {
            try
            {
                await Task.Factory.StartNew(() => DeleteTeam(id));
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

            return true;
        }

        public bool DeletePlayer(string id)
        {
            try
            {
                Connection.Open();
                // delete row from db
                string query = $"DELETE FROM {PlayersCollectionName} WHERE id = {id}";
                using (NpgsqlCommand cmd = new NpgsqlCommand(query, Connection))
                {
                    cmd.ExecuteNonQuery();
                }
                Connection.Close();
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

            return true;
        }

        public async Task<bool> DeletePlayerAsync(string id)
        {
            try
            {
                await Task.Factory.StartNew(() => DeletePlayer(id));
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

            return true;
        }

        public bool ChangePlayerTeam(string playerId, string teamId)
        {

            try
            {
                Connection.Open();
                // write row to db
                string query = $"UPDATE {PlayersCollectionName} SET team_id = \'{teamId}\' WHERE id = {playerId}";
                using (NpgsqlCommand cmd = new NpgsqlCommand(query, Connection))
                {
                    cmd.ExecuteNonQuery();
                }
                Connection.Close();
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

            return true;
        }

        public async Task<bool> ChangePlayerTeamAsync(string playerId, string teamId)
        {
            try
            {
                await Task.Factory.StartNew(() => ChangePlayerTeam(playerId, teamId));
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

            return true;
        }


    }
}
