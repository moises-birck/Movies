using ApplicationMovies.Service.Interface;

namespace ApplicationMovies.Service
{
    public class MoviesInitializerService : IMoviesInitializerService
    {
        private readonly IMoviesService _moviesService;

        public MoviesInitializerService(IMoviesService moviesService)
        {
            _moviesService = moviesService;
        }

        public async Task InitializeMovies()
        {
            _moviesService.ReadMoviesFromCsvAndInsert();
            await Task.CompletedTask;
        }
    }
}
