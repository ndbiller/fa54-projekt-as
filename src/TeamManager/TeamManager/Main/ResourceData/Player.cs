using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamManager.Main.ResourceData
{
    public class Player
    {
        //public uint Id { get; set; }
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Name { get; set; }
        //public uint TeamId { get; set; }
        public string Team { get; set; }
    }
}
