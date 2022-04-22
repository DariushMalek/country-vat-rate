using GlobalBlue.VATCalculator.Model.Entities;
using GlobalBlue.VATCalculator.Service.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace GlobalBlue.VATCalculator.Api.Controllers
{
    [ApiController]
    [Route("api/countries")]
    public class CountriesController : ControllerBase
    {
        private readonly ILogger<CountriesController> _logger;

        private readonly ICountryService _countryService;

        private readonly ICountryRateService _countryRateService;

        public CountriesController(ILogger<CountriesController> logger, ICountryService countryService, ICountryRateService countryRateService)
        {
            _logger = logger;
            _countryService = countryService;
            _countryRateService = countryRateService;
        }

        [HttpGet()]
        public async Task<ActionResult> GetAll()
        {
            return Ok();
        }

        [HttpGet("getRates/{id}")]
        public async Task<ActionResult> GetRates(int id)
        {
            return Ok();
        }
    }
}