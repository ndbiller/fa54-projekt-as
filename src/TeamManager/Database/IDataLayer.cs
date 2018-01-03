using System.Collections.Generic;
using System.Threading.Tasks;
using TeamManager.Models.ResourceData;

namespace TeamManager.Database
{
    /// <summary>
    /// The <see cref="IDataLayer"/> interface that each <see cref="DatabaseType"/> must implement. That way, the application can
    /// use any database while keeping the same consistent data.
    /// </summary>
    public interface IDataLayer
    {
        /// <summary>
        /// Opens the database connections.
        /// </summary>
        void OpenConnection();

        /// <summary>
        /// The Timeout in miliseconds for task to execute when using the async calls.
        /// </summary>
        int TimeoutMilisec { get; }

        /// <summary>
        /// The collection/table of the <see cref="Team"/>s.
        /// </summary>
        string TeamsCollectionName { get; }

        /// <summary>
        /// The collection/table of the <see cref="Player"/>s.
        /// </summary>
        string PlayersCollectionName { get; }


        #region --- Normal Methods ---
        
        /// <summary>
        /// Retrieves all <see cref="Team"/>s in a list.
        /// </summary>
        /// <returns>Returns a collections of <see cref="Team"/>. </returns>
        List<Team> Teams();

        /// <summary>
        /// Creates a new <see cref="Team"/> with the specified name.
        /// </summary>
        /// <param name="name">The name for the new created <see cref="Team"/>. </param>
        /// <returns>Returns true if operation were succesfull. </returns>
        bool CreateTeam(string name);
        
        /// <summary>
        /// Gets a <see cref="Team"/> with the specified <see cref="id"/>.
        /// </summary>
        /// <param name="id">The <see cref="id"/> of the <see cref="Team"/>. </param>
        /// <returns>Returns a <see cref="Team"/>. </returns>
        Team ReadTeam(string id);

        /// <summary>
        /// Updates the <see cref="Team"/> with the new <see cref="Team"/> <see cref="name"/>.
        /// </summary>
        /// <param name="id">The <see cref="id"/> of the <see cref="Team"/>. </param>
        /// <param name="name">The new <see cref="name"/> of the <see cref="Team"/>. </param>
        /// <returns>Returns true if operation were succesfull. </returns>
        bool UpdateTeam(string id, string name);

        /// <summary>
        /// Deletes a <see cref="Team"/> with the specified team <see cref="id"/>.
        /// </summary>
        /// <param name="id">The <see cref="id"/> of the <see cref="Team"/>. </param>
        /// <returns>Returns true if operation were succesfull. </returns>
        bool DeleteTeam(string id);



        /// <summary>
        /// Retrieves all <see cref="Player"/>s in a list.
        /// </summary>
        /// <returns>Returns a collections of <see cref="Player"/>. </returns>
        List<Player> Players();

        /// <summary>
        /// Retrieves all <see cref="Player"/>s in a list with the specified <see cref="teamId"/>.
        /// </summary>
        /// <param name="teamId">The <see cref="teamId"/> of the <see cref="Player"/>. </param>
        /// <returns>Returns a collections of <see cref="Player"/>. </returns>
        List<Player> ShowPlayers(string teamId);

        /// <summary>
        /// Creates a new <see cref="Player"/> with the specified <see cref="name"/> and <see cref="teamId"/>.
        /// </summary>
        /// <param name="name">The name of the <see cref="Player"/>. </param>
        /// <param name="teamId">The id of the <see cref="Team"/>. </param>
        /// <returns>Returns true if operation were succesfull. </returns>
        bool CreatePlayer(string name, string teamId);

        /// <summary>
        /// Gets a <see cref="Player"/> with the specified <see cref="id"/>.
        /// </summary>
        /// <param name="id">The <see cref="id"/> of the <see cref="Player"/>. </param>
        /// <returns>Returns a <see cref="Player"/>. </returns>
        Player ReadPlayer(string id);

        /// <summary>
        /// Updates the <see cref="Player"/> with the new <see cref="Player"/> <see cref="name"/>.
        /// </summary>
        /// <param name="id">The <see cref="id"/> of the <see cref="Player"/>. </param>
        /// <param name="name">The new <see cref="name"/> of the <see cref="Player"/>. </param>
        /// <returns>Returns true if operation were succesfull. </returns>
        bool UpdatePlayer(string id, string name);

        /// <summary>
        /// Updates the <see cref="Player"/> with the new <see cref="Player"/> <see cref="name"/> and <see cref="teamId"/>.
        /// </summary>
        /// <param name="id">The <see cref="id"/> of the <see cref="Player"/>. </param>
        /// <param name="teamId">The <see cref="teamId"/> of the <see cref="Team"/>. </param>
        /// <param name="name">The new <see cref="name"/> of the <see cref="Player"/>. </param>
        /// <returns>Returns true if operation were succesfull. </returns>
        bool UpdatePlayer(string id, string teamId, string name);

        /// <summary>
        /// Deletes a <see cref="Player"/> with the specified team <see cref="id"/>.
        /// </summary>
        /// <param name="id">The <see cref="id"/> of the <see cref="Player"/>. </param>
        /// <returns>Returns true if operation were succesfull. </returns>
        bool DeletePlayer(string id);

        /// <summary>
        /// Changes the <see cref="Player"/> team with the specified <see cref="teamId"/>.
        /// </summary>
        /// <param name="playerId">The id of the <see cref="Player"/>. </param>
        /// <param name="teamId">The id of the <see cref="Team"/>. </param>
        /// <returns>Returns true if operation were succesfull. </returns>
        bool ChangePlayerTeam(string playerId, string teamId);

        #endregion --- Normal Methods --- 


        #region --- Async Methods ---

        /// <summary>
        /// Retrieves all <see cref="Team"/>s in a list using async call.
        /// </summary>
        /// <returns>Returns a collections of <see cref="Team"/>. </returns>
        Task<List<Team>> TeamsAsync();

        /// <summary>
        /// Creates a new <see cref="Team"/> with the specified name using async call.
        /// </summary>
        /// <param name="name">The name for the new created <see cref="Team"/>. </param>
        /// <returns>Returns true if operation were succesfull. </returns>
        Task<bool> CreateTeamAsync(string name);

        /// <summary>
        /// Gets a <see cref="Team"/> with the specified <see cref="id"/> using async call.
        /// </summary>
        /// <param name="id">The <see cref="id"/> of the <see cref="Team"/>. </param>
        /// <returns>Returns a <see cref="Team"/>. </returns>
        Task<Team> ReadTeamAsync(string id);

        /// <summary>
        /// Updates the <see cref="Team"/> with the new <see cref="Team"/> <see cref="name"/> using async call.
        /// </summary>
        /// <param name="id">The <see cref="id"/> of the <see cref="Team"/>. </param>
        /// <param name="name">The new <see cref="name"/> of the <see cref="Team"/>. </param>
        /// <returns>Returns true if operation were succesfull. </returns>
        Task<bool> UpdateTeamAsync(string id, string name);

        /// <summary>
        /// Deletes a <see cref="Team"/> with the specified team <see cref="id"/> using async call.
        /// </summary>
        /// <param name="id">The <see cref="id"/> of the <see cref="Team"/>. </param>
        /// <returns>Returns true if operation were succesfull. </returns>
        Task<bool> DeleteTeamAsync(string id);




        /// <summary>
        /// Retrieves all <see cref="Player"/>s in a list using async call.
        /// </summary>
        /// <returns>Returns a collections of <see cref="Player"/>. </returns>
        Task<List<Player>> PlayersAsync();

        /// <summary>
        /// Retrieves all <see cref="Player"/>s in a list with the specified <see cref="teamId"/> using async call.
        /// </summary>
        /// <param name="teamId">The <see cref="teamId"/> of the <see cref="Player"/>. </param>
        /// <returns>Returns a collections of <see cref="Player"/>. </returns>
        Task<List<Player>> ShowPlayersAsync(string teamId);

        /// <summary>
        /// Creates a new <see cref="Player"/> with the specified <see cref="name"/> and <see cref="teamId"/> using async call.
        /// </summary>
        /// <param name="name">The name of the <see cref="Player"/>. </param>
        /// <param name="teamId">The id of the <see cref="Team"/>. </param>
        /// <returns>Returns true if operation were succesfull. </returns>
        Task<bool> CreatePlayerAsync(string name, string teamId);

        /// <summary>
        /// Gets a <see cref="Player"/> with the specified <see cref="id"/> using async call.
        /// </summary>
        /// <param name="id">The <see cref="id"/> of the <see cref="Player"/>. </param>
        /// <returns>Returns a <see cref="Player"/>. </returns>
        Task<Player> ReadPlayerAsync(string id);

        /// <summary>
        /// Updates the <see cref="Player"/> with the new <see cref="Player"/> <see cref="name"/> using async call.
        /// </summary>
        /// <param name="id">The <see cref="id"/> of the <see cref="Player"/>. </param>
        /// <param name="name">The new <see cref="name"/> of the <see cref="Player"/>. </param>
        /// <returns>Returns true if operation were succesfull. </returns>
        Task<bool> UpdatePlayerAsync(string id, string name);

        /// <summary>
        /// Updates the <see cref="Player"/> with the new <see cref="Player"/> <see cref="name"/> and <see cref="teamId"/> using async call.
        /// </summary>
        /// <param name="id">The <see cref="id"/> of the <see cref="Player"/>. </param>
        /// <param name="teamId">The <see cref="teamId"/> of the <see cref="Team"/>. </param>
        /// <param name="name">The new <see cref="name"/> of the <see cref="Player"/>. </param>
        /// <returns>Returns true if operation were succesfull. </returns>
        Task<bool> UpdatePlayerAsync(string id, string teamId, string name);

        /// <summary>
        /// Deletes a <see cref="Player"/> with the specified team <see cref="id"/> using async call.
        /// </summary>
        /// <param name="id">The <see cref="id"/> of the <see cref="Player"/>. </param>
        /// <returns>Returns true if operation were succesfull. </returns>
        Task<bool> DeletePlayerAsync(string id);

        /// <summary>
        /// Changes the <see cref="Player"/> team with the specified <see cref="teamId"/> using async call.
        /// </summary>
        /// <param name="playerId">The id of the <see cref="Player"/>. </param>
        /// <param name="teamId">The id of the <see cref="Team"/>. </param>
        /// <returns>Returns true if operation were succesfull. </returns>
        Task<bool> ChangePlayerTeamAsync(string playerId, string teamId);

        #endregion --- Async Methods ---

    }
}
