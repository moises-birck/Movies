using ApplicationMovies.Json;
using DomainMovies.Model;

namespace ApplicationMovies.Service.Interface
{
    public interface IProducersService
    {
        AwardsResponseResult GetMinorAndMajorYearRangeProducers();
        List<Movies> GetAllNominatedForAward();
    }
}
