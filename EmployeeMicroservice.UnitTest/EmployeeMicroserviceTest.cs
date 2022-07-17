using System;
using Xunit;
using EmployeeMicroservice.Controllers;
using EmployeeMicroservice.Database;
using Microsoft.AspNetCore.Mvc;
using Moq;
using EmployeeMicroservice.Repository;
using EmployeeMicroserviceUnitTest.MockData;
using System.Net;
using FluentAssertions;

namespace EmployeeMicroservice.UnitTest
{
    public class EmployeeMicroServiceTest
    {
        [Fact]
        public async void ViewProfile_ShouldReturn200Status() 
        {
            // Arrange
            var employeeService = new Mock<IEmployeeService>();
            var employees = EmployeeMockData.GetEmployees();
            employeeService.Setup(s => s.ViewProfile(employees[0].EmpId)).ReturnsAsync(employees[0]);
            var sut = new EmployeesController(employeeService.Object); //System Under Test

            // Act
            var result = await sut.ViewProfile(employees[0].EmpId);

            // Assert
            Assert.IsType<OkObjectResult>(result.Result as OkObjectResult);
        }

        [Fact]
        public async void ViewProfile_ShouldReturn404Status()
        {
            // Arrange
            var employeeService = new Mock<IEmployeeService>();
            var sut = new EmployeesController(employeeService.Object);

            // Act
            var result = await sut.ViewProfile(0);

            // Assert
            Assert.IsType<NotFoundResult>(result.Result);
        }

        [Fact]
        public async void ViewProfile_ShouldReturnExceptionMessage()
        {
            // Arrange
            var employeeService = new Mock<IEmployeeService>();
            var sut = new EmployeesController(employeeService.Object);

            // Act
            var result = await sut.ViewProfile(-1);

            // Assert
            Assert.IsType<BadRequestObjectResult>(result.Result);
        }

        [Fact]
        public async void ViewEmployeeOffers_ShouldReturn200Status()
        {
            // Arrange
            var employeeService = new Mock<IEmployeeService>();
            var employees = EmployeeMockData.GetEmployees();
            var offers = OfferMockData.GetOffers();
            var empoffers = EmployeeOfferMockData.GetEmployeeOffers();
            employeeService.Setup(s => s.ViewEmployeeOffers(employees[0].EmpId)).ReturnsAsync(empoffers);
            var sut = new EmployeesController(employeeService.Object);

            // Act
            var result = await sut.ViewEmployeeOffers(employees[0].EmpId);

            // Assert
            Assert.IsType<OkObjectResult>(result.Result as OkObjectResult);
        }

        [Fact]
        public async void ViewEmployeeOffers_ShouldReturn404Status()
        {
            // Arrange
            var employeeService = new Mock<IEmployeeService>();
            var sut = new EmployeesController(employeeService.Object);

            // Act
            var result = await sut.ViewEmployeeOffers(0);

            // Assert
            Assert.IsType<NotFoundResult>(result.Result);
        }

        [Fact]
        public async void ViewEmployeeOffers_ShouldReturnExceptionMessage()
        {
            // Arrange
            var employeeService = new Mock<IEmployeeService>();
            var sut = new EmployeesController(employeeService.Object);

            // Act
            var result = await sut.ViewEmployeeOffers(-1);

            // Assert
            Assert.IsType<BadRequestObjectResult>(result.Result);
        }

        [Fact]
        public async void ViewMostLikedOffers_ShouldReturn200Status()
        {
            // Arrange
            var employeeService = new Mock<IEmployeeService>();
            var empoffers = EmployeeOfferMockData.Get3MostLikedEmployeeOffers();
            employeeService.Setup(s => s.ViewMostLikedOffers()).ReturnsAsync(empoffers);
            var sut = new EmployeesController(employeeService.Object);

            // Act
            var result = await sut.ViewMostLikedOffers();

            // Assert
            Assert.IsType<OkObjectResult>(result.Result as OkObjectResult);
        }

        [Fact]
        public async void ViewMostLikedOffers_ShouldReturn404Status()
        {
            // Arrange
            var employeeService = new Mock<IEmployeeService>();
            var sut = new EmployeesController(employeeService.Object);

            // Act
            var result = await sut.ViewMostLikedOffers();

            // Assert
            Assert.IsType<NotFoundResult>(result.Result);
        }

        [Fact]
        public async void ViewMostLikedOffers_ShouldReturnExceptionMessage()
        {
            // Arrange
            var employeeService = new Mock<IEmployeeService>();
            var empoffers = EmployeeOfferMockData.GetEmployeeOffersForCheckingException();
            employeeService.Setup(s => s.ViewMostLikedOffers()).ReturnsAsync(empoffers);
            var sut = new EmployeesController(employeeService.Object);

            // Act
            var result = await sut.ViewMostLikedOffers();

            // Assert
            Assert.IsType<BadRequestObjectResult>(result.Result);
        }
    }
}
