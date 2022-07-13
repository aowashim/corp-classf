using EmployeeMicroserviceUnitTest.MockData;
using Moq;
using PointsMicroservices.Repository;
using Xunit;
using PointsMicroservices.Controllers;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace PointMicroservices.UnitTest
{
    public class PointMicroservicesTest
    {
        [Fact]
        public async Task FetchPoints_ShouldReturn200Status()
        {
            //Arrange
            var pointService = new Mock<IPointService>();
            var employees = EmployeeMockData.GetEmployees();
            pointService.Setup(s => s.FetchPoints(employees[0].EmpId)).ReturnsAsync(employees[0]);
            var sut = new PointController(pointService.Object);
            
            //Act
            var result = (OkObjectResult)await sut.FetchPoints(employees[0].EmpId);

            //Asert
            Assert.IsType<OkObjectResult>(result as OkObjectResult);
        }
        [Fact]
        public async void FetchPoints_ShouldReturn404Status()
        {
            var pointService = new Mock<IPointService>();
            var sut = new PointController(pointService.Object);
            var result = await sut.FetchPoints(0);
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task PointsCalculations_ShouldReturn200Status()
        {
            //Arrange
            var offerService = new Mock<IPointService>();
            var offers=OfferMockData.GetOffers();
            var sut=new PointController(offerService.Object);

            //Act
            var result = (OkResult)await sut.PointsCalculations(offers[0]);

            //Assert
            Assert.IsType<OkResult>(result as OkResult);
        }
    }
}
