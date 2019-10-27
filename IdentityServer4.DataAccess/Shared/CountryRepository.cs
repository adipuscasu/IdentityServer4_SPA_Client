using IdentityServer4.DataModels.Shared;

namespace IdentityServer4.DataAccess.Shared
{
    public class CountryRepository : GenericRepository<Country>
    {
        private readonly ApplicationDbContext _dbContext;

        public CountryRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
