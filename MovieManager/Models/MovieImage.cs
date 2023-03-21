using System;
using System.Collections.Generic;

namespace MovieManager.Models
{
    public partial class MovieImage
    {
        public int IdmovieImage { get; set; }
        public string Name { get; set; } = null!;
        public string ContentType { get; set; } = null!;
        public byte[]? Content { get; set; }
        public int? MovieId { get; set; }

        public virtual Movie? Movie { get; set; }
    }
}
