using CoreGenericRepo.Models.Entity;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections;
using System.Collections.Generic;

namespace CoreGenericRepo.Models.DTO
{
    public class MovieVM
    {
        public ICollection<MovieType> mtList { get; set; }
        public MovieType MovieTypes { get; set; }
        public ICollection<Movie> mList { get; set; }
        public Movie Movies { get; set; }

    }
}
