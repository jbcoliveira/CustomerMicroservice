using API.Controllers;
using API.ViewModels;
using Business.Interfaces.Repositories;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace Tests
{
    [TestFixture]
    public class CustomerControllerTests
    {
        private readonly Mock<ICustomerRepository> _mockCustomerRepository;
        private readonly CustomerController _controller;

        public CustomerControllerTests()
        {

            _mockCustomerRepository = new Mock<ICustomerRepository>();
            _controller = new CustomerController(_mockCustomerRepository.Object);
        }

        [Test]
        public void Get_ActionExecutes_ReturnsOkResult()
        {
            //Arrange

            //Act
            var result = _controller.Get();
            var okResult = result as OkObjectResult;

            //Assert
            Assert.IsNotNull(okResult);
            Assert.That(okResult.StatusCode,Is.EqualTo(200) );

        }

        [Test]
        [TestCase(0)]
        public void Get_WithIDFilledExecutes_ReturnsNotFoundResult(int id)
        {
            //Arrange
           
            //Act
            var result = _controller.Get(id);
            var okResult = result as NotFoundResult;

            //Assert
            Assert.IsNotNull(okResult);
            Assert.That(okResult.StatusCode, Is.EqualTo(404));

        }

        [Test]
        [TestCase(1)]
        public void Get_WithIDFilledExecutes_ReturnsOkResult(int id)
        {
            //Arrange

            //Act
            var result = _controller.Get(id);
            var okResult = result as OkObjectResult;

            //Assert
            Assert.IsNotNull(okResult);
            Assert.That(okResult.StatusCode, Is.EqualTo(200));

        }


        public static object[] CustomerViewModelWithNullValuesSource =
        {
            new CustomerViewModel{ Email = null, FirstName = "Joao"},
            new CustomerViewModel{ Email = "joao@joao.com", FirstName = "Joao",Password = "pwd",SurName =null},
            new CustomerViewModel{ Email = "joao@joao.com", FirstName = null,Password = "pwd",SurName ="Oliveira"},
            new CustomerViewModel{ Email = "joao@joao.com", FirstName = "Joao",Password = null,SurName ="Oliveira"},
            new CustomerViewModel()
            

 
        };
    }
}
