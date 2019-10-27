using IdentityServer4.DataAccess;
using IdentityServer4.DataModels.Shared;
using System.Linq;

namespace IdentityServer4.DomainLogic.Shared
{
    public class CountryService: ICountryService
    {
        private readonly IGenericRepository<Country> _countryRepository;

        public CountryService(IGenericRepository<Country> countryRepository)
        {
            _countryRepository = countryRepository;
        }

        public IQueryable<Country> GetCountries()
        {
            return _countryRepository.GetAll();
        }
    }
}
