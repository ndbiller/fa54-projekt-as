using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamManager.Models.ResourceData
{
    public class Player
    {
#if MONGO_DB
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Team { get; set; }
#else
        public uint Id { get; set; }
        public uint TeamId { get; set; }
#endif
        public string Name { get; set; }
    }
}
