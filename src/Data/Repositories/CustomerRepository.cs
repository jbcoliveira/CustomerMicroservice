using Business.Interfaces.Repositories;
using Business.Models;
using Data.Context;

namespace Data.Repositories
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        public CustomerRepository(ApplicationDbContext db) : base(db)
        {
        }
    }
}