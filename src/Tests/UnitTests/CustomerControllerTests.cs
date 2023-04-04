using API.Configurations;
using API.Controllers;
using API.ViewModels;
using AutoMapper;
using Business.Interfaces.Repositories;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace Tests.UnitTests
{
    [TestFixture]
    public class CustomerControllerTests
    {
        private readonly Mock<ICustomerRepository> _mockCustomerRepository;
        private readonly CustomerController _controller;
        private IMapper _mapper;
        public CustomerControllerTests()
        {
            AutoMapperInit();
            _mockCustomerRepository = new Mock<ICustomerRepository>();
            _controller = new CustomerController(_mockCustomerRepository.Object,_mapper);
        }

        [Test]
        public async Task Get_ActionExecutes_ReturnsOKStatusCodeResultAsync()
        {
            //Arrange

            //Act
            var result = await _controller.GetAsync();
            var statusCodeResult = result as OkObjectResult;

            //Assert
            Assert.IsNotNull(statusCodeResult);
            Assert.That(statusCodeResult.StatusCode, Is.EqualTo(200));

        }

        [Test]
        [TestCase(0)]
        public async Task Get_WithIDFilledExecutes_ReturnsNotFoundResultAsync(int id)
        {
            //Arrange

            //Act
            var result = await _controller.GetAsync(id);
            var statusCodeResult = result as NotFoundResult;

            //Assert
            Assert.IsNotNull(statusCodeResult);
            Assert.That(statusCodeResult.StatusCode, Is.EqualTo(404));

        }

       


        [Test]
        public async Task Post_WhenCalledWithWrongEmailFormat_ShouldShowErrorMessageAndBadRequestAsync()
        {
            //Arrange
            var customer = new CustomerViewModel { Email = "joao@@joao.com", FirstName = "Joao", Password = "pwd", SurName = "Oliveira" };

            //Act
            var result = await _controller.PostAsync(customer);
            var statusCodeResult = result as BadRequestObjectResult;

            //Assert
            Assert.IsNotNull(statusCodeResult);
            Assert.That(statusCodeResult.StatusCode, Is.EqualTo(400));
            Assert.That(statusCodeResult.Value, Is.EqualTo("Error. Some input is missing or it is in wrong format."));

        }



        [Test]
        public async Task Put_WhenCalledWithWrongEmailFormat_ShouldShowErrorMessageAndBadRequestAsync()
        {
            //Arrange
            var customer = new CustomerViewModel { Id = 1, Email = "joao@@joao.com", FirstName = "Joao", Password = "pwd", SurName = "Oliveira" };

            //Act
            var result = await _controller.PutAsync(customer.Id, customer);
            var statusCodeResult = result as BadRequestObjectResult;

            //Assert
            Assert.IsNotNull(statusCodeResult);
            Assert.That(statusCodeResult.StatusCode, Is.EqualTo(400));
            Assert.That(statusCodeResult.Value, Is.EqualTo("Error. Some input is missing or it is in wrong format."));

        }

        [Test]
        [TestCase(0)]
        public async Task Delete_WithIDFilledExecutes_ReturnsNotFoundResultAsync(int id)
        {
            //Arrange

            //Act
            var result = _controller.DeleteAsync(id);
            var statusCodeResult = await result as NotFoundResult;

            //Assert
            Assert.IsNotNull(statusCodeResult);
            Assert.That(statusCodeResult.StatusCode, Is.EqualTo(404));

        }

       

        private static object[] CustomersWithNullValuesSource =
        {
            new CustomerViewModel{ Email = null, FirstName = "Joao"},
            new CustomerViewModel{ Email = "joao@joao.com", FirstName = "Joao",Password = "pwd",SurName =null},
            new CustomerViewModel()
        };



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
