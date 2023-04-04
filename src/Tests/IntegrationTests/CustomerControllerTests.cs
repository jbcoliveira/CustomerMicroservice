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
        private CustomerRepository _customerRepository;
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
        public async Task Get_ActionExecutes_ReturnsOKStatusCodeResultAsync()
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

        private void AutoMapperInit()
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(profile: new AutoMapperConfiguration());
            });
            IMapper mapper = mappingConfig.CreateMapper();
            _mapper = mapper;
        }
    }
}
