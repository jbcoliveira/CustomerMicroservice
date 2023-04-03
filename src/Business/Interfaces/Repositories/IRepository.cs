using Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces.Repositories
{
    public interface IRepository<TEntity> : IDisposable where TEntity : BaseEntity
    {
        Task Add(TEntity entity);

        Task<TEntity> GetById(int id);

        Task Update(TEntity entity);

        Task Remove(int id);
        Task<int> SaveChanges();
    }
}
