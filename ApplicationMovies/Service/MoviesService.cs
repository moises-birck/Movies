using ApplicationMovies.Map;
using ApplicationMovies.Service.Interface;
using CsvHelper;
using CsvHelper.Configuration;
using DomainMovies.Model;
using InfraMovie.Repository;
using InfraMovies.Configuration;
using System.Globalization;

namespace ApplicationMovies.Service
{
    public class MoviesService : IMoviesService
    {
        private readonly IMoviesRepository _moviesRepository;

        public MoviesService(IMoviesRepository moviesRepository)
        {
            _moviesRepository = moviesRepository;
        }

        public void ReadMoviesFromCsvAndInsert()
        {
            string relativePath = "File\\movielist.csv";
            string projectDirectory = Directory.GetCurrentDirectory();
            string fullPath = Path.Combine(projectDirectory, relativePath);

            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                Delimiter = ";"
            };

            using (var reader = new StreamReader(fullPath))
            using (var csv = new CsvReader(reader, config))
            {
                csv.Context.RegisterClassMap<MovieMap>();
                var movieList = csv.GetRecords<Movies>().ToList();
                _moviesRepository.InsertMovies(movieList);
            }
        }
    }
}
