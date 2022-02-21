using System.Collections;
using System.Collections.Generic;

namespace CoreGenericRepo.Models.Entity
{
    public class MovieType
    {
        public int MovieTypeID { get; set; }
        public string MovieTypeName { get; set; }
        public ICollection<Movie> Movies { get; set; }
    }
}
