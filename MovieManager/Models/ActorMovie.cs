using System;
using System.Collections.Generic;

namespace MovieManager.Models
{
    public partial class ActorMovie
    {
        public int IdactorMovie { get; set; }
        public int? ActorId { get; set; }
        public int? MovieId { get; set; }

        public virtual Actor? Actor { get; set; }
        public virtual Movie? Movie { get; set; }
    }
}
