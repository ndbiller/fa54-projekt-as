using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamManager.Database;
using TeamManager.Models.ResourceData;

namespace TeamManager.Models.TechnicalConcept
{
    public class TechnicalConcept1 : TechnicalConceptBase, ITechnicalConcept
    {
        public TechnicalConcept1(DataType dataType) : base(dataType) { }

        public bool AddNewPlayer(string playerName)
        {
            throw new NotImplementedException();
        }

        public bool AddNewTeam(string teamName)
        {
            throw new NotImplementedException();
        }

        public bool ChangePlayerName(string playerId)
        {
            throw new NotImplementedException();
        }

        public bool ChangeTeamName(string teamId, string NewTeamName)
        {
            throw new NotImplementedException();
        }

        public List<Player> GetAllPlayer()
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

        public bool TransferPlayer(string playerId, string teamId)
        {
            throw new NotImplementedException();
        }
    }
}
