using ApplicationMovies.Json;
using ApplicationMovies.Service.Interface;
using DomainMovies.Model;
using InfraMovies.Configuration;

namespace ApplicationMovies.Service
{
    public class ProducersService : IProducersService
    {
        private readonly MoviesContext _dbContext;

        public ProducersService(MoviesContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        public List<string> GetProducersWithMoreOfOnePrize()
        {
            var producersWithMoreThanOneAward = _dbContext.MoviesDb
                .Where(w => w.Winner.Equals("Yes", StringComparison.OrdinalIgnoreCase))
                .GroupBy(g => g.Producers )
                .Where(w => w.Count() > 1)
                .Select(s => s.Key)
                .ToList();

            return producersWithMoreThanOneAward;
        }
        
        public List<Movies> GetAllNominatedForAward() => _dbContext.MoviesDb.ToList();

        public AwardsResponseResult GetMinorAndMajorYearRangeProducers()
        {
            var producersWithMoreThanOneAward = GetProducersWithMoreOfOnePrize();

            var minList = new List<AwardsResponse>();
            var maxList = new List<AwardsResponse>();

            int minInterval = int.MaxValue;
            int maxInterval = int.MinValue;

            foreach (var produtor in producersWithMoreThanOneAward)
            {
                var producerAwards = _dbContext.MoviesDb
                    .Where(w => w.Producers == produtor)
                    .OrderBy(o => o.Year)
                    .ToList();
                
                //Não foi pedido o intervalo total, primeiro e ultimo prêmio, mas deixei o código para pegar...
                //int previousWin = producerAwards.First().Year;
                //int followingWin = producerAwards.Last().Year;               

                for (int i = 0; i < producerAwards.Count - 1; i++)
                {
                    int consecutiveInterval = producerAwards[i + 1].Year - producerAwards[i].Year;
                   
                    if (consecutiveInterval <= minInterval)
                    {
                        if (consecutiveInterval < minInterval) 
                        {
                            minList.Clear();
                            minInterval = consecutiveInterval;
                        }
                        else if (consecutiveInterval == minInterval && minList.Any(r => r.Producer == produtor))
                            continue;

                        minList.Add(new AwardsResponse
                        {
                            Producer = produtor,
                            Interval = consecutiveInterval,
                            PreviousWin = producerAwards[i].Year,
                            FollowingWin = producerAwards[i + 1].Year
                        });
                    }

                    if (consecutiveInterval >= maxInterval)
                    {                        
                        if (consecutiveInterval > maxInterval)
                        {
                            maxList.Clear();
                            maxInterval = consecutiveInterval;
                        }   
                        else if (consecutiveInterval == maxInterval && minList.Any(r => r.Producer == produtor))
                            continue;                       
                        
                        maxList.Add(new AwardsResponse
                        {
                            Producer = produtor,
                            Interval = consecutiveInterval,
                            PreviousWin = producerAwards[i].Year,
                            FollowingWin = producerAwards[i + 1].Year
                        });
                    }
                }
            }

            var result = new AwardsResponseResult
            {
                Min = minList,
                Max = maxList
            };

            return result;
        }
      
    }
}
