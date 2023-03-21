using System;
using System.Collections.Generic;

namespace MovieManager.Models
{
    public partial class Director
    {
        public Director()
        {
            Movies = new HashSet<Movie>();
        }

        public int Iddirector { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;

        public string FullName {
            get {
                return FirstName + " " + LastName;
            }
        }

        public virtual ICollection<Movie> Movies { get; set; }
    }
}
