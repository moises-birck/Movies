using DomainMovies.Model;
using InfraMovies.Configuration;

namespace InfraMovie.Repository
{
    public class MoviesRepository : IMoviesRepository
    {
        private readonly MoviesContext _context;

        public MoviesRepository(MoviesContext context)
        {
            _context = context;
        }

        public void InsertMovies(List<Movies> movies)
        {
            _context.MoviesDb.AddRange(movies);
            _context.SaveChanges();
        }
    }
}
