using CoreGenericRepo.Models.Entity;
using Microsoft.EntityFrameworkCore;

namespace CoreGenericRepo.Models
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext>options):base(options)
        {

        }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<MovieType> MovieTypes { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<MovieType>().HasMany(x => x.Movies).WithOne(x => x.MovieType).HasForeignKey(x => x.MovieTypeID);
        }

    }
}
