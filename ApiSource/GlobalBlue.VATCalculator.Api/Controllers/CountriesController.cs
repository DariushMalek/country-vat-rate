using GlobalBlue.VATCalculator.Api.Mapper;
using GlobalBlue.VATCalculator.Model.Entities;
using GlobalBlue.VATCalculator.Model.Response;
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

        private readonly ICountryRateMapper _countryRateMapper;

        public CountriesController(ILogger<CountriesController> logger, ICountryService countryService, ICountryRateService countryRateService, ICountryRateMapper countryRateMapper)
        {
            _logger = logger;
            _countryService = countryService;
            _countryRateService = countryRateService;
            _countryRateMapper = countryRateMapper;
        }

        [HttpGet()]
        public async Task<ActionResult<IEnumerable<Country>>> GetAll()
        {
            var result = await _countryService.GetAllCountries();
            _logger.LogInformation($"GetAllCountries has returned {result.Count()} of countries");
            return Ok(result);
        }

        [HttpGet("getRates/{id}")]
        public async Task<ActionResult<IEnumerable<CountryRateInfoResponse>>> GetRates(int id)
        {
            var result = await _countryRateService.GetCountryCurrentRates(id);
            _logger.LogInformation($"GetRates has returned {result.Count()} of countries");
            return Ok(_countryRateMapper.ToResponse(result));
        }
    }
}