using API.ViewModels;
using AutoMapper;
using Business.Interfaces.Repositories;
using Business.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private ICustomerRepository _customerRepository { get; set; }
        private readonly IMapper _mapper;

        public CustomerController(ICustomerRepository customerRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }

        // GET: api/<CustomerController>
        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAsync()
        {
            var query = await _customerRepository.GetAll();
            List<Customer> list = await Task.FromResult(query.ToList());
            List<CustomerViewModel> customers = _mapper.Map<List<CustomerViewModel>>(list);

            return Ok(customers);
        }

        // GET api/<CustomerController>/5
        [HttpGet("{id}")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Get(int id)
        {
            var customer = new CustomerViewModel { Id = id, Email = "joao@joao.com", FirstName = "Joao", Password = "pwd", SurName = "" };

            if (customer.Id != 1)
                return NotFound();

            return Ok(customer);
        }

        // POST api/<CustomerController>
        [HttpPost]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Post([FromBody] CustomerViewModel customer)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if(!customer.Validate())
                return BadRequest("Error. Some input is missing or it is in wrong format.");

            return Ok(customer);
        }

        // PUT api/<CustomerController>/5
        [HttpPut("{id}")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Put(int id, [FromBody] CustomerViewModel customer)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!customer.Validate())
                return BadRequest("Error. Some input is missing or it is in wrong format.");

            return Ok();
        }

        // DELETE api/<CustomerController>/5
        [HttpDelete("{id}")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Delete(int id)
        {
            var customer = new CustomerViewModel { Id = id, Email = "joao@joao.com", FirstName = "Joao", Password = "pwd", SurName = "" };

            if (customer.Id != 1)
                return NotFound();

            return Ok(customer);
        }
    }
}