using System.Linq;
using IdentityServer4.DataModels.Shared;

namespace IdentityServer4.DomainLogic.Shared
{
    public interface ICountryService
    {
        IQueryable<Country> GetCountries();
    }
}