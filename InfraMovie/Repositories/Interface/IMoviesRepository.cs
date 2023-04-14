using DomainMovies.Model;

namespace InfraMovie.Repository
{
    public interface IMoviesRepository
    {
        void InsertMovies(List<Movies> movies);
    }
}
