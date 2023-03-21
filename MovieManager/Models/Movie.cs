using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieManager.Models
{
    public partial class Movie
    {
        public Movie()
        {
            ActorMovies = new HashSet<ActorMovie>();
            MovieImages = new HashSet<MovieImage>();
        }

        public int Idmovie { get; set; }
        public string Title { get; set; } = null!;
        public string Desc { get; set; } = null!;
        public int? DirectorId { get; set; }
        [NotMapped]
        public List<IFormFile>? Files { get; set; }

        public virtual Director? Director { get; set; }
        public virtual ICollection<ActorMovie> ActorMovies { get; set; }
        public virtual ICollection<MovieImage> MovieImages { get; set; }
    }
}
