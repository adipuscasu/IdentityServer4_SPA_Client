using System.Linq;
using System.Threading.Tasks;
using IdentityServer4.DataModels;
using IdentityServer4_SPA_Client.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace IdentityServer4.DataAccess
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity>
        where TEntity : class, IEntity
    {
    private readonly ApplicationDbContext _dbContext;
    public GenericRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

        public async Task Create(TEntity entity)
        {
            await _dbContext.Set<TEntity>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public IQueryable<TEntity> GetAll()
        {
            return _dbContext.Set<TEntity>().AsNoTracking();
        }

        public async Task<TEntity> GetById(string id)
        {
            return await _dbContext.Set<TEntity>()
                .AsNoTracking()
                .FirstOrDefaultAsync(e => e.Id.ToString() == id);
        }

        public async Task Update(string id, TEntity entity)
        {
            _dbContext.Set<TEntity>().Update(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}
