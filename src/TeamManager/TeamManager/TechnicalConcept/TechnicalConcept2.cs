using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamManager.Database;

namespace TeamManager.TechnicalConcept
{
    public class TechnicalConcept2 : ITechnicalConcept
    {
        public IDbManager ADbManager
        {
            get { return ADbManager; }
            set { ADbManager = value; }
        }
        public Team ATeam
        {
            get { return ATeam; }
            set { ATeam = value; }
        }
        public Player APlayer
        {
            get { return APlayer; }
            set { APlayer = value; }
        }

        public TechnicalConcept2(IDbManager aDbManager)
        {
            this.ADbManager = aDbManager;
        }

        public List<String> GetAllTeams()
        {
            throw new NotImplementedException();
        }
        public String AddNewTeam(String teamName)
        {
            throw new NotImplementedException();
        }
        public String ChangeTeamName(String teamId, String NewTeamName)
        {
            throw new NotImplementedException();
        }
        public String RemoveTeam(String teamId)
        {
            throw new NotImplementedException();
        }

        public List<String> GetAllPlayer()
        {
            throw new NotImplementedException();
        }
        public List<String> GetTeamPlayers(String teamId)
        {
            throw new NotImplementedException();
        }
        public String AddNewPlayer(String playerName)
        {
            throw new NotImplementedException();
        }
        public String ChangePlayerName(String playerId)
        {
            throw new NotImplementedException();
        }
        public String RemovePlayer(String playerId)
        {
            throw new NotImplementedException();
        }
        public String TransferPlayer(String playerId, String teamId)
        {
            throw new NotImplementedException();
        }
    }
}
