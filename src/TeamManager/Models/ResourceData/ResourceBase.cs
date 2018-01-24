using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamManager.Models.ResourceData
{
    public abstract class ResourceBase
    {
        /// <summary> The <see cref="Id"/> of the <see cref="ResourceBase"/> which is defined with the <see cref="Guid"/>. </summary>
        public string Id { get; set; }

        /// <summary> The <see cref="Name"/> of the <see cref="ResourceBase"/> as string. </summary>
        public string Name { get; set; }


        /// <summary>
        /// Implicit cast to a string so the <see cref="ResourceBase"/> object can be passed directly to a string variable without
        /// using the .ToString() method everywhere.
        /// </summary>
        /// <param name="rc"></param>
        public static implicit operator string(ResourceBase rc)
        {
            return rc.Name;
        }
    }
}
