using ApplicationMovies.Service;
using ApplicationMovies.Service.Interface;
using InfraMovie.Repository;
using InfraMovies.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DomainMovies
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
               .AddScoped<IMoviesService, MoviesService>()
               .AddScoped<IMoviesRepository, MoviesRepository>()
               .AddScoped<MoviesContext>()
               .AddDbContext<MoviesContext>(options => options.UseInMemoryDatabase(databaseName: "MyBaseInMemory"))
               .BuildServiceProvider();

            var moviesService = serviceProvider.GetService<IMoviesService>();
            moviesService.ReadMoviesFromCsvAndInsert();

            //var producersService = serviceProvider.GetService<IProducersService>();
            //producersService.GetMinorAndMajorYearRangeProducers();

        }
    }
}

