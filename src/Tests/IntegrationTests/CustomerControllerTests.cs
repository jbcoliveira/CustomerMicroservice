using API.Configurations;
using API.Controllers;
using API.ViewModels;
using AutoMapper;
using Business.Interfaces.Repositories;
using Data.Repositories;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;

namespace Tests.IntegrationTests
{
    [TestFixture]
    public class CustomerControllerTests : TestBase
    {
        private ICustomerRepository _customerRepository;
        private CustomerController _controller;
        private IMapper _mapper;

        [SetUp]
        public void Setup()
        {
            AutoMapperInit();
            _customerRepository = new CustomerRepository(_dbContext);
            _controller = new CustomerController(_customerRepository, _mapper);
            
        }

        [Test]
        public async Task Get_WhenExecutes_ReturnsOKStatusCodeResultAsync()
        {
            //Arrange

            //Act
            var result = await _controller.GetAsync();
            var statusCodeResult = result as OkObjectResult;
            var list = _mapper.Map<List<CustomerViewModel>>( statusCodeResult.Value) ;

            //Assert
            Assert.IsNotNull(statusCodeResult);
            Assert.That(statusCodeResult.StatusCode, Is.EqualTo(200));
            Assert.That(list, Is.Not.Empty);

        }

        [Test]

        public async Task Get_WhenExecutesWithId_ReturnsOKStatusCodeResultAsync()
        {
            //Arrange

            //Act
            var result = await _controller.GetAsync(1);
            var statusCodeResult = result as OkObjectResult;
            var customer = _mapper.Map<CustomerViewModel>(statusCodeResult.Value);

            //Assert
            Assert.IsNotNull(statusCodeResult);
            Assert.That(statusCodeResult.StatusCode, Is.EqualTo(200));
            Assert.That(customer, Is.Not.Null);

        }
        [Test]
        [TestCase(1)]
        public async Task Get_WithIDFilledExecutes_ReturnsOkStatusCodeResultAsync(int id)
        {
            //Arrange

            //Act
            var result = await _controller.GetAsync(id);
            var statusCodeResult = result as OkObjectResult;

            //Assert
            Assert.IsNotNull(statusCodeResult);
            Assert.That(statusCodeResult.StatusCode, Is.EqualTo(200));

        }
        


        [Test]
        public async Task Put_WhenCalled_ShouldCreateARegistryAsync()
        {
            //Arrange
            var customer = new CustomerViewModel { Id = 1, Email = "joao@joao.com", FirstName = "Joao", Password = "pwd", SurName = "Oliveira" };
            //Act
            var result = await _controller.PutAsync(customer.Id, customer);
            var statusCodeResult = result as OkObjectResult;

            //Assert
            Assert.IsNotNull(statusCodeResult);
            Assert.That(statusCodeResult.StatusCode, Is.EqualTo(200));

        }


        [Test]
        [TestCase(1)]
        public async Task Delete_WithIDFilledExecutes_ReturnsOkStatusCodeResultAsync(int id)
        {
            //Arrange

            //Act
            var result = await _controller.DeleteAsync(id);
            var statusCodeResult = result as OkObjectResult;

            //Assert
            Assert.IsNotNull(statusCodeResult);
            Assert.That(statusCodeResult.StatusCode, Is.EqualTo(200));

        }


        [Test]
        [TestCaseSource(nameof(CustomersForPost))]
        public async Task Post_WhenCalled_ShouldCreateARegistryAsync(CustomerViewModel customer)
        {
            //Arrange

            //Act
            var result = await _controller.PostAsync(customer);
            var statusCodeResult = result as OkObjectResult;

            //Assert
            Assert.IsNotNull(statusCodeResult);
            Assert.That(statusCodeResult.StatusCode, Is.EqualTo(200));

        }
        private void AutoMapperInit()
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(profile: new AutoMapperConfiguration());
            });
            IMapper mapper = mappingConfig.CreateMapper();
            _mapper = mapper;
        }
        private static object[] CustomersForPost =
{
            new CustomerViewModel{ Email = "joao@joao.com", FirstName = "Joao",Password = "pwd",SurName ="Oliveira"},
        };
    }
}
