using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using log4net;
using MongoDB.Bson;
using MongoDB.Driver;
using TeamManager.Models.ResourceData;
using TeamManager.Utilities;

namespace TeamManager.Database
{
    class DBLayerSql : IDataLayer
    {
        private static readonly ILog Log = Logger.GetLogger();


        public void ConnectDB()
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
            var filter = Builders<BsonDocument>.Filter.Eq("_id", id);
            var update = Builders<BsonDocument>.Update.Set("Name", name);

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
            var filter = Builders<BsonDocument>.Filter.Eq("_id", id);
            var update = Builders<BsonDocument>.Update.Set("Name", name);

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
            var filter = Builders<BsonDocument>.Filter.Eq("_id", id);
            var update = Builders<BsonDocument>.Update.Set("Name", name);

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
            var filter = Builders<BsonDocument>.Filter.Eq("_id", playerId);
            var update = Builders<BsonDocument>.Update.Set("TeamId", teamId);

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
