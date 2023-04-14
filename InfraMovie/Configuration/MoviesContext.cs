using DomainMovies.Model;
using Microsoft.EntityFrameworkCore;

namespace InfraMovies.Configuration
{
    public class MoviesContext : DbContext
    {
        public DbSet<Movies> MoviesDb { get; set; }

        public MoviesContext(DbContextOptions<MoviesContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "MyBaseInMemory");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movies>()
                .HasKey(f => f.Id); 

            modelBuilder.Entity<Movies>()
                .Property(f => f.Title)
                .IsRequired();

            base.OnModelCreating(modelBuilder);
        }
    }
}
