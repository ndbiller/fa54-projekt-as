using System;

namespace TeamManager.Models.ResourceData
{
    /// <summary>
    /// Commmon data that the resource data will be used.
    /// It's important that every resource data objects inheriting this class due to the constraint in the 
    /// <see cref="Strategy.ISortStrategy"/>.
    /// </summary>
    public abstract class ResourceBase
    {
        /// <summary> The <see cref="Id"/> of the <see cref="ResourceBase"/> which is defined with the <see cref="Guid"/>. </summary>
        public string Id { get; set; }

        /// <summary> The <see cref="Name"/> of the <see cref="ResourceBase"/> as string. </summary>
        public string Name { get; set; }




        /// <summary>
        /// Initializes members and generates a new <see cref="Id"/> everytime the ctor is called.
        /// </summary>
        /// <param name="name"></param>
        protected ResourceBase(string name)
        {
            Id = Guid.NewGuid().ToString();
            Name = name;
        }


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
