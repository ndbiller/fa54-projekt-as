using System;
using System.Collections.Generic;
using TeamManager.Database;
using TeamManager.Models.ResourceData;

namespace TeamManager.Models.TechnicalConcept
{
    public class TechnicalConcept2 : TechnicalConceptBase, ITechnicalConcept
    {
        public TechnicalConcept2(DatabaseType dbType) : base(dbType) { }

        public bool AddNewPlayer(string playerName)
        {
            throw new NotImplementedException();
        }

        public bool AddNewTeam(string teamName)
        {
            throw new NotImplementedException();
        }

        public bool ChangePlayerName(string playerId, string playerNewName)
        {
            throw new NotImplementedException();
        }

        public bool ChangeTeamName(string teamId, string teamNewName)
        {
            throw new NotImplementedException();
        }

        public List<Player> GetAllPlayers()
        {
            throw new NotImplementedException();
        }

        public List<Team> GetAllTeams()
        {
            throw new NotImplementedException();
        }

        public List<Player> GetTeamPlayers(string teamId)
        {
            throw new NotImplementedException();
        }

        public bool RemovePlayer(string playerId)
        {
            throw new NotImplementedException();
        }

        public bool RemoveTeam(string teamId)
        {
            throw new NotImplementedException();
        }

        public bool ChangePlayerTeam(string playerId, string teamId)
        {
            throw new NotImplementedException();
        }
    }
}
