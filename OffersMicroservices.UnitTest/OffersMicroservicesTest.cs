using EmployeeMicroserviceUnitTest.MockData;
using Microsoft.AspNetCore.Mvc;
using Moq;
using OffersMicroservices.Controllers;
using OffersMicroservices.Database.Entities;
using OffersMicroservices.Repository;
using OffersMicroservices.UnitTest.MockData;
using OffersMicroserviceUnitTest.MockData;
using System;
using Xunit;

namespace OffersMicroservices.UnitTest
{
    public class OffersMicroservicesTest
    {
        [Fact]
        public async void Offer_ShouldReturn200Status()
        {
            //Arrange
            var offerService = new Mock<IOfferService>();
            var employees=EmployeeOfferMockData.GetEmployeeOffers();
            offerService.Setup(x => x.Offer()).ReturnsAsync(employees);
            var sut = new OfferController(offerService.Object);

            //Act
            var result = (OkObjectResult)await sut.Offer();

            //Assert
            Assert.IsType<OkObjectResult>(result);
        }
        
        [Fact]
        public async void Offer_ShouldReturn404Status()
        {
            //Arrange
            var offerService=new Mock<IOfferService>();
            var sut=new OfferController(offerService.Object);
            //Act
            var result=await sut.Offer();
            //Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async void GetOfferDetails_ShouldReturn200Status()
        {
            //Arrange
            var offerService= new Mock<IOfferService>();
            var offers=OfferEmployeeMockData.GetOfferEmployee();
            offerService.Setup(x => x.GetOfferDetails(offers[0].id)).ReturnsAsync(offers);
            var sut = new OfferController(offerService.Object);
            //Act
            var result = (OkObjectResult)await sut.GetOfferDetails(offers[0].id);
            //Assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async void GetOfferDetails_ShouldReturn404Status()
        {
            //Arrange
            var offerServiice = new Mock<IOfferService>();
            var sut=new OfferController(offerServiice.Object);
            //Act
            var result = await sut.GetOfferDetails(0);
            //Assert
            Assert.IsType<NotFoundResult>(result);  
        }

        [Fact]
        public async void GetOfferDetailsByCategory_ShouldReturn200Status()
        {
            //Arrange
            var offerService=new Mock<IOfferService>();
            var offers=EmployeeOfferMockData.GetEmployeeOffers();
            offerService.Setup(x=>x.GetOfferDetailsByCategory(1)).ReturnsAsync(offers);
            var sut= new OfferController(offerService.Object);
            //Act
            var result= (OkObjectResult)await sut.GetOfferDetailsByCategory(1);
            //Assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async void GetOfferDetailsByCategory_ShouldReturn404Status()
        {
            //Arrange
            var offerService = new Mock<IOfferService>();
            var sut = new OfferController(offerService.Object);
            //Act
            var result =await sut.GetOfferDetailsByCategory(1);
            //Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async void GetOfferByTopLikes_ShouldReturn200Status()
        {
            //Arrange
            var offerService = new Mock<IOfferService>();
            var offers = EmployeeOfferMockData.GetEmployeeOffers();
            offerService.Setup(x => x.GetOfferByTopLikes()).ReturnsAsync(offers);
            var sut = new OfferController(offerService.Object);
            //Act
            var result =(OkObjectResult)await sut.GetOfferByTopLikes();
            //Assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async void GetOfferByTopLikes_ShouldReturn404Status()
        {
            //Arrange
            var offerService = new Mock<IOfferService>();
            var sut = new OfferController(offerService.Object);
            //Act
            var result = await sut.GetOfferByTopLikes();
            //Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async void GetOfferByPostedDate_ShouldReturn200Status()
        {
            //Arrange
            var offerService = new Mock<IOfferService>();
            var offers = EmployeeOfferMockData.GetEmployeeOffers();
            offerService.Setup(x => x.GetOfferByPostedDate()).ReturnsAsync(offers);
            var sut = new OfferController(offerService.Object);
            //Act
            var result = (OkObjectResult)await sut.GetOfferByPostedDate();
            //Assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async void GetOfferByPostedDate_ShouldReturn404Status()
        {
            //Arrange
            var offerService = new Mock<IOfferService>();
            var sut = new OfferController(offerService.Object);
            //Act
            var result = await sut.GetOfferByPostedDate();
            //Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async void CreateOffer_ShouldReturn200Status()
        {
            //Arrange
            var offerService = new Mock<IOfferService>();
            var offers = OfferMockData.GetOffers();
            offerService.Setup(x => x.CreateAsync(offers[0]));
            var sut = new OfferController(offerService.Object);
            //Act
            var result = (OkResult)await sut.CreateOffer(offers[0]);
            //Assert
            Assert.IsType<OkResult>(result);
        }
        [Fact]
        public async void EditOffer_ShouldReturn200Status()
        {
            //Arrange
            var offerService = new Mock<IOfferService>();
            var offers = OfferMockData.GetOffers();
            var off_Id=offers[0].Id;
            offerService.Setup(x => x.EditAsync(off_Id,offers[0]));
            var sut = new OfferController(offerService.Object);
            //Act
            var result = (OkResult)await sut.EditOffer(off_Id,offers[0]);
            //Assert
            Assert.IsType<OkResult>(result);
        }

        [Fact]
        public async void EngageOffer_ShouldReturn200Status()
        {
            //Arrange
            var offerService = new Mock<IOfferService>();
            var offers = OfferMockData.GetOffers();
            var off_Id = offers[0].Id;
            var emp_Id = offers[0].Emp_Id;
            offerService.Setup(x => x.EngageAsync(off_Id, emp_Id));
            var sut = new OfferController(offerService.Object);
            //Act
            var result = (OkResult)await sut.EngageOffer(off_Id, emp_Id);
            //Assert
            Assert.IsType<OkResult>(result);
        }

        [Fact]
        public async void GetOfferDetailsByEmpId_ShouldReturn200Status()
        {
            //Arrange
            var offerService = new Mock<IOfferService>();
            var empoffers = EmployeeOfferMockData.GetEmployeeOffers();
            var emp=EmployeeMockData.GetEmployees();
            offerService.Setup(x => x.GetOfferDetailsByEmpId(emp[0].EmpId)).ReturnsAsync(empoffers);
            var sut = new OfferController(offerService.Object);
            //Act
            var result = (OkObjectResult)await sut.GetOfferDetailsByEmpId(325671);
            //Assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async void GetOfferDetailsByEmpId_ShouldReturn404Status()
        {
            //Arrange
            var offerService = new Mock<IOfferService>();
            var sut = new OfferController(offerService.Object);
            //Act
            var result = await sut.GetOfferDetailsByEmpId(0);
            //Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async void GetComments_ShouldReturn200Status()
        {
            //Arrange
            var offerService = new Mock<IOfferService>();
            var offer=OfferMockData.GetOffers();
            var comment=EmployeeCommentMockData.GetEmployeeComments();
            offerService.Setup(x => x.GetComments(offer[0].Id)).ReturnsAsync(comment);
            var sut = new OfferController(offerService.Object);
            //Act
            var result =(OkObjectResult) await sut.GetComments(offer[0].Id);
            //Assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async void GetComments_ShouldReturn404Status()
        {
            //Arrange
            var offerService = new Mock<IOfferService>();
            var sut = new OfferController(offerService.Object);
            //Act
            var result =await sut.GetComments(0);
            //Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async void PostComment_ShouldReturn200Status()
        {
            //Arrange
            var offerService = new Mock<IOfferService>();
            var comment = new Comment()
            {
                Content = "Impressive",
                Offer_Id = 2,
                User_Id = 18201
            };
            offerService.Setup(x => x.PostAsync(comment));
            var sut = new OfferController(offerService.Object);
            //Act
            var result = (OkResult)await sut.PostComment(comment);
            //Assert
            Assert.IsType<OkResult>(result);
        }
    }
}
