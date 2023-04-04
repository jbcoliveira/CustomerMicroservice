using API.ViewModels;
using AutoMapper;
using Business.Interfaces.Repositories;
using Business.Models;
using Microsoft.AspNetCore.Mvc;

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
        /// <summary>
        /// Retrieves all data
        /// </summary>
        /// <returns></returns>
        [HttpGet("Get")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAsync()
        {
            try
            {
                var query = await _customerRepository.GetAll();
                List<Customer> list = await Task.FromResult(query.ToList());
                List<CustomerViewModel> customers = _mapper.Map<List<CustomerViewModel>>(list);

                return Ok(customers);
            }
            catch (Exception)
            {
                return BadRequest("Error. Some input is missing or it is in wrong format.");
            }
        }

        // GET api/<CustomerController>/5
        /// <summary>
        /// Retrieves data by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("Get/{id}")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAsync(int id)
        {
            try
            {
                var customer = await _customerRepository.GetById(id);

                if (customer == null)
                    return NotFound();

                return Ok(customer);
            }
            catch (Exception)
            {
                return BadRequest("Error. Some input is missing or it is in wrong format.");
            }
        }

        // POST api/<CustomerController>
        /// <summary>
        /// Insert a new customer
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        [HttpPost("Post")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PostAsync([FromBody] CustomerViewModel customer)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                if (!customer.Validate())
                    return BadRequest("Error. Some input is missing or it is in wrong format.");

                await _customerRepository.Add(_mapper.Map<Customer>(customer));
                return Ok(customer);
            }
            catch (Exception)
            {
                return BadRequest("Error. Some input is missing or it is in wrong format.");
            }
        }

        // PUT api/<CustomerController>/5
        /// <summary>
        /// Update a customer
        /// </summary>
        /// <param name="id"></param>
        /// <param name="customer"></param>
        /// <returns></returns>
        [HttpPut("Put/{id}")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> PutAsync(int id, [FromBody] CustomerViewModel customer)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                if (!customer.Validate())
                    return BadRequest("Error. Some input is missing or it is in wrong format.");

                var customerObj = await _customerRepository.GetById(id);

                if (customerObj == null)
                    return NotFound();

                _mapper.Map(customer, customerObj);
                await _customerRepository.Update(customerObj);

                return Ok(customerObj);
            }
            catch (Exception)
            {
                return BadRequest("Error. Some input is missing or it is in wrong format.");
            }
        }

        // DELETE api/<CustomerController>/5
        /// <summary>
        /// Removes a customer
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("Delete/{id}")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            try
            {
                Customer customer = await _customerRepository.GetById(id);

                if (customer == null)
                    return NotFound();

                await _customerRepository.Remove(customer);

                return Ok(customer);
            }
            catch (Exception)
            {
                return BadRequest("Error. Some input is missing or it is in wrong format.");
            }
        }
    }
}