using Business.Models;

namespace Business.Interfaces.Repositories
{
    public interface IRepository<TEntity> : IDisposable where TEntity : BaseEntity
    {
        Task Add(TEntity entity);

        Task<TEntity> GetById(int id);
        Task<IQueryable<TEntity>> GetAll();

        Task Update(TEntity entity);

        Task Remove(int id);

        Task<int> SaveChanges();
    }
}