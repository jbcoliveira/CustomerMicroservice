using Business.Models;

namespace Business.Interfaces.Services
{
    public interface IService
    {
        Task Add(Customer entity);

        Task<Customer> GetById(int id);

        Task Update(Customer entity);

        Task Remove(int id);
    }
}