using System.Linq;
using IdentityServer4.DataModels.Shared;
using IdentityServer4.DomainLogic.Shared;
using Microsoft.AspNetCore.Mvc;

namespace IdentityServer4.REST_API.Controllers
{
   
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController : ControllerBase
    {
        private readonly ICountryService _countryService;

        public CountriesController(ICountryService countryService)
        {
            _countryService = countryService;
        }

        public IQueryable<Country> GetCountries()
        {
            return _countryService.GetCountries();
        }
    }
}