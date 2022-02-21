using System.ComponentModel.DataAnnotations.Schema;

namespace CoreGenericRepo.Models.Entity
{
    public class Movie
    {
        public int MovieID { get; set; }
        public string MovieName { get; set; }
        public string MovieDescription { get; set; }
        public string MovieImage { get; set; }
        public int MovieTypeID { get; set; }
        public MovieType MovieType { get; set; }
    }
}
