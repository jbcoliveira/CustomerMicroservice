using Business.Interfaces.Repositories;
using Business.Interfaces.Services;
using Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public class CustomerService : ICustomerService
    {

        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task Add(Customer entity)
        {
            await _customerRepository.Add(entity);    
        }

        public async Task<Customer> GetById(int id)
        {
            return await _customerRepository.GetById(id);
        }

        public async Task Update(Customer entity)
        {
            await _customerRepository.Update(entity);
        }

        public async Task Remove(int id)
        {
           await _customerRepository.Remove(id);
        }
    }
}
