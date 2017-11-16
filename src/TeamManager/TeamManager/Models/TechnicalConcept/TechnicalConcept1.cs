using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamManager.Database;

namespace TeamManager.Models.TechnicalConcept
{
    public class TechnicalConcept1 : ITechnicalConcept
    {
        public Team ATeam { get; set; }
        public Player APlayer { get; set; }

        public TechnicalConcept1()
        {
        }

        public List<string> GetAllTeams()
        {
            throw new NotImplementedException();
        }
        public string AddNewTeam(string teamName)
        {
            throw new NotImplementedException();
        }
        public string ChangeTeamName(string teamId, string NewTeamName)
        {
            throw new NotImplementedException();
        }
        public string RemoveTeam(string teamId)
        {
            throw new NotImplementedException();
        }

        public List<string> GetAllPlayer()
        {
            throw new NotImplementedException();
        }
        public List<string> GetTeamPlayers(string teamId)
        {
            throw new NotImplementedException();
        }
        public string AddNewPlayer(string playerName)
        {
            throw new NotImplementedException();
        }
        public string ChangePlayerName(string playerId)
        {
            throw new NotImplementedException();
        }
        public string RemovePlayer(string playerId)
        {
            throw new NotImplementedException();
        }
        public string TransferPlayer(string playerId, string teamId)
        {
            throw new NotImplementedException();
        }
}
}
