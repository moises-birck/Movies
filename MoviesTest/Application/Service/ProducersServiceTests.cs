using ApplicationMovies.Service;
using DomainMovies.Model;
using InfraMovies.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace TestMovies.Application.Service
{
    [TestClass]
    public class ProducersServiceTests
    {
        private DbContextOptions<MoviesContext> _dbContextOptions;

        [TestInitialize]
        public void Initialize()
        {
            _dbContextOptions = new DbContextOptionsBuilder<MoviesContext>()
                .UseInMemoryDatabase(databaseName: "MoviesTestDbInMemory")
                .Options;

            using (var dbContext = new MoviesContext(_dbContextOptions))
            {
                dbContext.MoviesDb.AddRange(new[]
                {
                new Movies { Id = Guid.NewGuid(), Title = "Movie 1", Year = 2000, Studios = "Studio 1", Producers = "Producer 1", Winner = "Yes" },
                new Movies { Id = Guid.NewGuid(), Title = "Movie 2", Year = 2001, Studios = "Studio 2", Producers = "Producer 2", Winner = "No" },
                new Movies { Id = Guid.NewGuid(), Title = "Movie 3", Year = 2002, Studios = "Studio 3", Producers = "Producer 1", Winner = "Yes" },
                new Movies { Id = Guid.NewGuid(), Title = "Movie 4", Year = 2003, Studios = "Studio 4", Producers = "Producer 2", Winner = "No" },
                new Movies { Id = Guid.NewGuid(), Title = "Movie 5", Year = 2004, Studios = "Studio 5", Producers = "Producer 3", Winner = "No" },
                new Movies { Id = Guid.NewGuid(), Title = "Movie 6", Year = 2005, Studios = "Studio 6", Producers = "Producer 4", Winner = "Yes" },
                new Movies { Id = Guid.NewGuid(), Title = "Movie 7", Year = 2010, Studios = "Studio 7", Producers = "Producer 4", Winner = "Yes" },
                });

                dbContext.SaveChanges();
            }
        }

        [TestMethod]
        public void Test_GetAllNominatedForAward_ReturnsAllMovies()
        {
            using (var dbContext = new MoviesContext(_dbContextOptions))
            {
                var service = new ProducersService(dbContext);

                var result = service.GetAllNominatedForAward();

                Assert.AreEqual(dbContext.Set<Movies>().Count(), result.Count);
            }
        }

        [TestMethod]
        public void GetProducersWithMoreThanOnePrize_Should_Return_Correct_Producers()
        {
            using (var dbContext = new MoviesContext(_dbContextOptions))
            {
                var service = new ProducersService(dbContext);
                var result = service.GetProducersWithMoreOfOnePrize();

                CollectionAssert.Contains(result, "Producer 1");
                CollectionAssert.DoesNotContain(result, "Producer 2");
                CollectionAssert.DoesNotContain(result, "Producer 3");
                CollectionAssert.Contains(result, "Producer 4");
            }
        }

        [TestMethod]
        public void GetMinorAndMajorYearRangeProducers_Should_Return_Correct_AwardsResponseResult()
        {
            using (var dbContext = new MoviesContext(_dbContextOptions))
            {
                var service = new ProducersService(dbContext);

                var result = service.GetMinorAndMajorYearRangeProducers();

                Assert.IsNotNull(result);
                Assert.IsNotNull(result.Min);
                Assert.IsNotNull(result.Max);
                Assert.AreEqual(1, result.Min.Count);
                Assert.AreEqual(1, result.Max.Count);
                Assert.AreEqual("Producer 1", result.Min[0].Producer);
                Assert.AreEqual("Producer 4", result.Max[0].Producer);
            }
        }
    }
}
