using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamManager.Models.ResourceData
{
    public class Team
    {
#if MONGO_DB
        public string Id { get; set; } = Guid.NewGuid().ToString();
#else
        public int Id { get; set; }
#endif
        public string Name { get; set; }
    }
}
