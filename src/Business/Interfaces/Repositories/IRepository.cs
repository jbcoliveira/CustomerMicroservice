using Business.Models;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Business.Interfaces.Repositories
{
    public interface IRepository<TEntity> : IDisposable where TEntity : BaseEntity
    {
        Task Add(TEntity entity);

        Task<TEntity> GetById(int id);
        IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
        Task<IQueryable<TEntity>> GetAll();

        Task Update(TEntity entity);
        Task Remove(int id);

        Task Remove(TEntity entity);

        Task<int> SaveChanges();
    }
}