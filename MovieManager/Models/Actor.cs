using System;
using System.Collections.Generic;

namespace MovieManager.Models
{
    public partial class Actor
    {
        public Actor()
        {
            ActorMovies = new HashSet<ActorMovie>();
        }

        public int Idactor { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;

        public virtual ICollection<ActorMovie> ActorMovies { get; set; }
    }
}
