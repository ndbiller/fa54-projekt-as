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
        internal static readonly string POSTGRESQL_USERNAME;
        internal static readonly string POSTGRESQL_PASSWORD;
        internal static readonly string POSTGRESQL_URI;
        internal static readonly string POSTGRESQL_PORT;
        internal static readonly string POSTGRESQL_DATABASE_NAME;

        // connect to heroku postgresql server
        // PostgeSQL-style connection string
        internal static readonly string connectionString;

        private static NpgsqlConnection Connection { get; set; }

        private const string TeamsCollectionName = "team";
        private const string PlayersCollectionName = "player";

        private const int TimeoutMilisec = 3000;

        static DbLayerSql()
        {
            try
            {
                POSTGRESQL_USERNAME = Environment.GetEnvironmentVariable("POSTGRESQL_USERNAME");
                POSTGRESQL_PASSWORD = Environment.GetEnvironmentVariable("POSTGRESQL_PASSWORD");
                POSTGRESQL_URI = Environment.GetEnvironmentVariable("POSTGRESQL_URI");
                POSTGRESQL_PORT = Environment.GetEnvironmentVariable("POSTGRESQL_PORT");
                POSTGRESQL_DATABASE_NAME = Environment.GetEnvironmentVariable("POSTGRESQL_DATABASE_NAME");
            }
            catch (Exception e)
            {
                Log.Error("cctor - Failed to retrieve environment variables => ", e);
            }
            connectionString =  "Server=" + POSTGRESQL_URI +
                                ";Port=" + POSTGRESQL_PORT +
                                ";User Id=" + POSTGRESQL_USERNAME +
                                ";Password=" + POSTGRESQL_PASSWORD +
                                ";Database=" + POSTGRESQL_DATABASE_NAME +
                                ";SSL Mode=Require;" +
                                "Trust Server Certificate=true;";
        }

        public DbLayerSql()
        {
            Connection = new NpgsqlConnection(connectionString);
            Log.Info("Connection created.");
        }

        public void OpenConnection()
        {
            Connection.Open();
            Log.Info("Connection opened.");
        }

        public void CloseConnection()
        {
            Connection.Close();
            Log.Info("Connection closed.");
        }

        public void ExecuteSql(string query)
        {
            Connection = new NpgsqlConnection(connectionString);
            // execute custom query code
            NpgsqlCommand customCommand = new NpgsqlCommand(query, Connection);
            OpenConnection();
            customCommand.ExecuteNonQuery();
            CloseConnection();
            Log.Info("Query executed: \n" + query);
        }

        public List<Team> Teams()
        {
            try
            {
                Connection = new NpgsqlConnection(connectionString);
                List<Team> teams = new List<Team>();
                using (Connection)
                {
                    OpenConnection();
                    // Retrieve all rows
                    string query = $"SELECT * FROM {TeamsCollectionName}";
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
                    CloseConnection();
                }

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
                Connection = new NpgsqlConnection(connectionString);
                List<Player> players = new List<Player>();
                using (Connection)
                {
                    OpenConnection();
                    // Retrieve all rows
                    string query = $"SELECT (RTRIM(id), RTRIM(name), RTRIM(team_id)) FROM {PlayersCollectionName}";
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
                    CloseConnection();
                }

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
                List<Player> players = new List<Player>();
                Connection = new NpgsqlConnection(connectionString);
                using (Connection)
                {
                    OpenConnection();
                    // Retrieve all rows with matching team_id
                    string query = $"SELECT * FROM {PlayersCollectionName} WHERE team_id = RTRIM({teamId})";
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
                    CloseConnection();
                }

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
                Connection = new NpgsqlConnection(connectionString);
                using (Connection)
                {
                    OpenConnection();
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
                    string query2 = $"INSERT INTO {TeamsCollectionName} (id,name) VALUES ({id},\'{name}\')";
                    using (NpgsqlCommand cmd = new NpgsqlCommand(query2, Connection))
                    {
                        cmd.ExecuteNonQuery();
                    }
                    CloseConnection();
                }

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
                Connection = new NpgsqlConnection(connectionString);
                using (Connection)
                {
                    OpenConnection();
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
                    string query2 = $"INSERT INTO {PlayersCollectionName}(id,name,team_id) VALUES ({id},\'{name}\',{teamId})";
                    using (var cmd = new NpgsqlCommand(query2, Connection))
                    {
                        cmd.ExecuteNonQuery();
                    }
                    CloseConnection();
                }

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
                Team team = new Team(null);
                Connection = new NpgsqlConnection(connectionString);
                using (Connection)
                {
                    OpenConnection();
                    // Retrieve all rows with matching id
                    string query = $"SELECT * FROM {TeamsCollectionName} WHERE id = RTRIM({id})";
                    using (NpgsqlCommand cmd = new NpgsqlCommand(query, Connection))
                    using (NpgsqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            team.Id = reader.GetString(0);
                            team.Name = reader.GetString(1);
                        }
                    }
                    CloseConnection();
                }

                return team;
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
                Player player = new Player(null);
                Connection = new NpgsqlConnection(connectionString);
                using (Connection)
                {
                    OpenConnection();
                    // Retrieve all rows with matching id
                    string query = $"SELECT * FROM {PlayersCollectionName} WHERE id = RTRIM({id})";
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
                    CloseConnection();
                }
                return player;
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
                Connection = new NpgsqlConnection(connectionString);
                OpenConnection();
                using (Connection)
                {
                    // write row to db
                    string query = $"UPDATE {TeamsCollectionName} SET name = '{name}' WHERE id = RTRIM({id})";
                    using (NpgsqlCommand cmd = new NpgsqlCommand(query, Connection))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }
                CloseConnection();
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
                Connection = new NpgsqlConnection(connectionString);
                OpenConnection();
                using (Connection)
                {
                    // write row to db
                    string query = $"UPDATE {PlayersCollectionName} SET name = RTRIM(\'{name}\') WHERE id = RTRIM({id})";
                    using (NpgsqlCommand cmd = new NpgsqlCommand(query, Connection))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }
                CloseConnection();

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

        // NOTE: Setting teamId here. Is this the desired behaviour?
        public bool UpdatePlayer(string id, string teamId, string name)
        {

            try
            {
                Connection = new NpgsqlConnection(connectionString);
                OpenConnection();
                using (Connection)
                {
                    // write row to db
                    string query = $"UPDATE {PlayersCollectionName} SET name = RTRIM(\'{name}\'), team_id = RTRIM(\'{teamId}\') WHERE id = RTRIM({id})";
                    using (NpgsqlCommand cmd = new NpgsqlCommand(query, Connection))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }
                CloseConnection();

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
                Connection = new NpgsqlConnection(connectionString);
                OpenConnection();
                using (Connection)
                {
                    // delete row from db
                    string query = $"DELETE FROM {TeamsCollectionName} WHERE id = {id}";
                    using (NpgsqlCommand cmd = new NpgsqlCommand(query, Connection))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }
                CloseConnection();

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
                Connection = new NpgsqlConnection(connectionString);
                OpenConnection();
                using (Connection)
                {
                    // delete row from db
                    string query = $"DELETE FROM {PlayersCollectionName} WHERE id = {id}";
                    using (NpgsqlCommand cmd = new NpgsqlCommand(query, Connection))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }
                CloseConnection();

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
                Connection = new NpgsqlConnection(connectionString);
                OpenConnection();
                using (Connection)
                {
                    // write row to db
                    string query = $"UPDATE {PlayersCollectionName} SET team_id = RTRIM(\'{teamId}\') WHERE id = RTRIM({playerId})";
                    using (NpgsqlCommand cmd = new NpgsqlCommand(query, Connection))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }
                CloseConnection();

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
