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
        public void Get_WithIDFilledExecutes_ReturnsNotFoundResult(int id)
        {
            //Arrange

            //Act
            var result = _controller.Get(id);
            var statusCodeResult = result as NotFoundResult;

            //Assert
            Assert.IsNotNull(statusCodeResult);
            Assert.That(statusCodeResult.StatusCode, Is.EqualTo(404));

        }

        [Test]
        [TestCase(1)]
        public void Get_WithIDFilledExecutes_ReturnsOkStatusCodeResult(int id)
        {
            //Arrange

            //Act
            var result = _controller.Get(id);
            var statusCodeResult = result as OkObjectResult;

            //Assert
            Assert.IsNotNull(statusCodeResult);
            Assert.That(statusCodeResult.StatusCode, Is.EqualTo(200));

        }

        [Test]
        [TestCaseSource(nameof(CustomersForPost))]
        public void Post_WhenCalled_ShouldCreateARegistry(CustomerViewModel customer)
        {
            //Arrange

            //Act
            var result = _controller.Post(customer);
            var statusCodeResult = result as OkObjectResult;

            //Assert
            Assert.IsNotNull(statusCodeResult);
            Assert.That(statusCodeResult.StatusCode, Is.EqualTo(200));

        }

        [Test]
        public void Post_WhenCalledWithWrongEmailFormat_ShouldShowErrorMessageAndBadRequest()
        {
            //Arrange
            var customer = new CustomerViewModel { Email = "joao@@joao.com", FirstName = "Joao", Password = "pwd", SurName = "Oliveira" };

            //Act
            var result = _controller.Post(customer);
            var statusCodeResult = result as BadRequestObjectResult;

            //Assert
            Assert.IsNotNull(statusCodeResult);
            Assert.That(statusCodeResult.StatusCode, Is.EqualTo(400));
            Assert.That(statusCodeResult.Value, Is.EqualTo("Error. Some input is missing or it is in wrong format."));

        }

        [Test]
        public void Put_WhenCalled_ShouldCreateARegistry()
        {
            //Arrange
            var customer = new CustomerViewModel { Id = 1, Email = "joao@@joao.com", FirstName = "Joao", Password = "pwd", SurName = "Oliveira" };
            //Act
            var result = _controller.Put(customer.Id, customer);
            var statusCodeResult = result as OkObjectResult;

            //Assert
            Assert.IsNotNull(statusCodeResult);
            Assert.That(statusCodeResult.StatusCode, Is.EqualTo(200));

        }

        [Test]
        public void Put_WhenCalledWithWrongEmailFormat_ShouldShowErrorMessageAndBadRequest()
        {
            //Arrange
            var customer = new CustomerViewModel { Id = 1, Email = "joao@@joao.com", FirstName = "Joao", Password = "pwd", SurName = "Oliveira" };

            //Act
            var result = _controller.Put(customer.Id, customer);
            var statusCodeResult = result as BadRequestObjectResult;

            //Assert
            Assert.IsNotNull(statusCodeResult);
            Assert.That(statusCodeResult.StatusCode, Is.EqualTo(400));
            Assert.That(statusCodeResult.Value, Is.EqualTo("Error. Some input is missing or it is in wrong format."));

        }

        [Test]
        [TestCase(0)]
        public void Delete_WithIDFilledExecutes_ReturnsNotFoundResult(int id)
        {
            //Arrange

            //Act
            var result = _controller.Delete(id);
            var statusCodeResult = result as NotFoundResult;

            //Assert
            Assert.IsNotNull(statusCodeResult);
            Assert.That(statusCodeResult.StatusCode, Is.EqualTo(404));

        }

        [Test]
        [TestCase(1)]
        public void Delete_WithIDFilledExecutes_ReturnsOkStatusCodeResult(int id)
        {
            //Arrange

            //Act
            var result = _controller.Delete(id);
            var statusCodeResult = result as OkObjectResult;

            //Assert
            Assert.IsNotNull(statusCodeResult);
            Assert.That(statusCodeResult.StatusCode, Is.EqualTo(200));

        }

        private static object[] CustomersWithNullValuesSource =
        {
            new CustomerViewModel{ Email = null, FirstName = "Joao"},
            new CustomerViewModel{ Email = "joao@joao.com", FirstName = "Joao",Password = "pwd",SurName =null},
            new CustomerViewModel()
        };

        private static object[] CustomersForPost =
{
            new CustomerViewModel{ Email = "joao@joao.com", FirstName = "Joao",Password = "pwd",SurName ="Oliveira"},
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
