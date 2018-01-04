using System.Collections.Generic;
using TeamManager.Models.ResourceData;

namespace TeamManager.Models.Strategy
{
    /// <summary>
    /// This interface will get implemented by all the other <see cref="StrategyType"/>s so it allows us to retrieve the same
    /// kind of data from the database, just in a different behavior by using this interface in the <see cref="Presenters.BasePresenter"/>
    /// in order to share the data between all the other presenters that will use it's data in the view.
    /// </summary>
    public interface IStrategy
    {
        /// <summary>
        /// Retrieves all the <see cref="Team"/>s from the database.
        /// </summary>
        /// <returns>Collection of <see cref="Team"/>s. </returns>
        List<Team> GetAllTeams();

        /// <summary>
        /// Retrieves all the <see cref="Team"/>s from the database with a specified filter.
        /// </summary>
        /// <param name="filterText">The text to filter when searching for players. </param>
        /// <param name="ignoreCase">Whether to ignore case sensetive. </param>
        /// <returns>Collection of <see cref="Team"/>s. </returns>
        List<Team> GetAllTeams(string filterText, bool ignoreCase);

        /// <summary>
        /// Retrieves a <see cref="Team"/> by the specified <see cref="teamId"/>.
        /// </summary>
        /// <param name="teamId">The Id of the <see cref="Team"/>. </param>
        /// <returns>A <see cref="Team"/>. </returns>
        Team GetPlayerTeam(string teamId);

        /// <summary>
        /// Adds a new <see cref="Team"/> with a specified <see cref="teamName"/>.
        /// </summary>
        /// <param name="teamName">The name of the <see cref="Team"/>. </param>
        /// <returns>Whether the operation were successful. </returns>
        bool AddNewTeam(string teamName);

        /// <summary>
        /// Changes a <see cref="Team"/> name with a specified <see cref="teamNewName"/>.
        /// </summary>
        /// <param name="teamId">The Id of the <see cref="Team"/>. </param>
        /// <param name="teamNewName">The new name of the <see cref="Team"/>. </param>
        /// <returns>Whether the operation were successful. </returns>
        bool ChangeTeamName(string teamId, string teamNewName);

        /// <summary>
        /// Removes a <see cref="Team"/> with a specified <see cref="teamId"/>.
        /// </summary>
        /// <param name="teamId">The Id of the <see cref="Team"/>. </param>
        /// <returns>Whether the operation were successful. </returns>
        bool RemoveTeam(string teamId);








        /// <summary>
        /// Retrieves all the <see cref="Player"/>s from the database.
        /// </summary>
        /// <returns>Collection of <see cref="Player"/>s. </returns>
        List<Player> GetAllPlayers();

        /// <summary>
        /// Retrieves all the <see cref="Player"/>s from the database with a specified filter.
        /// </summary>
        /// <param name="filterText">The text to filter when searching for players. </param>
        /// <param name="ignoreCase">Whether to ignore case sensetive. </param>
        /// <returns>Collection of <see cref="Player"/>s. </returns>
        List<Player> GetAllPlayers(string filterText, bool ignoreCase);

        /// <summary>
        /// Retrieves all <see cref="Team"/> <see cref="Player"/>s with the specified <see cref="teamId"/>.
        /// </summary>
        /// <param name="teamId">The Id of the <see cref="Team"/>. </param>
        /// <returns>Collection of <see cref="Player"/>s. </returns>
        List<Player> GetTeamPlayers(string teamId);

        /// <summary>
        /// Retrieves all <see cref="Team"/> <see cref="Player"/>s with the specified <see cref="teamId"/> and filter.
        /// </summary>
        /// <param name="teamId">The Id of the <see cref="Team"/>. </param>
        /// <param name="filterText">The text to filter when searching for players. </param>
        /// <param name="ignoreCase">Whether to ignore case sensetive. </param>
        /// <returns>Collection of <see cref="Player"/>s. </returns>
        List<Player> GetTeamPlayers(string teamId, string filterText, bool ignoreCase);

        /// <summary>
        /// Adds a new <see cref="Player"/> with a specified <see cref="playerName"/>.
        /// </summary>
        /// <param name="playerName">The <see cref="Player"/> name. </param>
        /// <returns>Whether the operation were successful. </returns>
        bool AddNewPlayer(string playerName);

        /// <summary>
        /// Adds a new <see cref="Player"/> with a specified <see cref="playerName"/> and <see cref="teamId"/>.
        /// </summary>
        /// <param name="playerName">The <see cref="Player"/> name. </param>
        /// <param name="teamId">The Id of the <see cref="Team"/>. </param>
        /// <returns>Whether the operation were successful. </returns>
        bool AddNewPlayer(string playerName, string teamId);

        /// <summary>
        /// Changes a <see cref="Player"/> name with a specified <see cref="playerNewName"/>.
        /// </summary>
        /// <param name="playerId">The Id of the <see cref="Player"/>. </param>
        /// <param name="playerNewName">The new name of the <see cref="Player"/>. </param>
        /// <returns>Whether the operation were successful. </returns>
        bool ChangePlayerName(string playerId, string playerNewName);

        /// <summary>
        /// Removes a <see cref="Player"/> with a specified <see cref="playerId"/>.
        /// </summary>
        /// <param name="playerId">The Id of the <see cref="Player"/>. </param>
        /// <returns>Whether the operation were successful. </returns>
        bool RemovePlayer(string playerId);

        /// <summary>
        /// Changes the <see cref="Player"/> team with the specified <see cref="teamId"/>.
        /// </summary>
        /// <param name="playerId">The Id of the <see cref="Player"/>. </param>
        /// <param name="teamId">The Id of the <see cref="Team"/>. </param>
        /// <returns>Whether the operation were successful. </returns>
        bool ChangePlayerTeam(string playerId, string teamId);

    }
}
