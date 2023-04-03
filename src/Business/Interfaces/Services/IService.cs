using Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
