using ApplicationMovies.Json;
using ApplicationMovies.Service.Interface;
using DomainMovies.Model;
using Microsoft.AspNetCore.Mvc;

namespace ApiMovies.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MoviesController : ControllerBase
    {
        private readonly ILogger<MoviesController> _logger;
        private readonly IProducersService _producersService;

        public MoviesController(IProducersService producersService,
            ILogger<MoviesController> logger)
        {
            _producersService = producersService;
            _logger = logger;
        }

        [HttpGet("consecutive-awards", Name = "GetConsecutiveAwards")]
        public ActionResult<AwardsResponseResult> GetConsecutiveAwards()
        {
            var result = _producersService.GetMinorAndMajorYearRangeProducers();

            if (!result.Min.Any() && !result.Max.Any())
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpGet("all-nominated-for-award", Name = "GetAllNominatedForAward")]
        public ActionResult<Movies> GetAllNominatedForAward()
        {
            var result = _producersService.GetAllNominatedForAward();

            if (!result.Any())
            {
                return NotFound();
            }

            return Ok(result);
        }
    }
}