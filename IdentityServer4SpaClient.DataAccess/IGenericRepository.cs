using System.Linq;
using System.Threading.Tasks;
using IdentityServer4.DataModels;

namespace IdentityServer4.DataAccess
{
    public interface IGenericRepository<TEntity> where TEntity : IEntity
    {
        IQueryable<TEntity> GetAll();

        Task<TEntity> GetById(string id);

        Task Create(TEntity entity);

        Task Update(string id, TEntity entity);

    }
}
