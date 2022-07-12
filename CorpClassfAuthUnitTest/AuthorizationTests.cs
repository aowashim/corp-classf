using System;
using Xunit;
using Moq;
using CorpClassfAuth.Repository;
using CorpClassfAuthUnitTest.MockData;
using CorpClassfAuth.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;

namespace CorpClassfAuthUnitTest
{
    public class AuthorizationTests
    {
        [Fact]
        public async void SignUp_ShouldReturn200Status()
        {
            // Arrange
            var mock = new Mock<IAuthRepository>();
            var signups = SignMockData.GetSignUpDetails();
            mock.Setup(m => m.SignUpAsync(signups[0])).ReturnsAsync(IdentityResult.Success);
            var sut = new AuthController(mock.Object);

            // Act
            var result = await sut.SignUp(signups[0]);

            // Assert
            Assert.IsType<OkObjectResult>(result as OkObjectResult);
        }

        [Fact]
        public async void SignUp_ShouldReturnBadRequestStatus()
        {
            // Arrange
            var mock = new Mock<IAuthRepository>();
            var signups = SignMockData.GetSignUpDetails();
            mock.Setup(m => m.SignUpAsync(signups[1])).ReturnsAsync(IdentityResult.Failed());
            var sut = new AuthController(mock.Object);

            // Act
            var result = await sut.SignUp(signups[1]);

            // Assert
            Assert.IsType<BadRequestObjectResult>(result as BadRequestObjectResult);
        }

        [Fact]
        public async void Login_ShouldReturn200Status()
        {
            // Arrange
            string token = "super-secret-token";
            var mock = new Mock<IAuthRepository>();
            var signins = SignMockData.GetSignInDetails();
            mock.Setup(m => m.LoginAsync(signins[0])).ReturnsAsync(token);
            var sut = new AuthController(mock.Object);

            // Act
            var result = await sut.LogIn(signins[0]);

            // Assert
            Assert.IsType<OkObjectResult>(result as OkObjectResult);
        }

        [Fact]
        public async void Login_ShouldReturnUnauthorizedStatus()
        {
            // Arrange
            string token = null;
            var mock = new Mock<IAuthRepository>();
            var signins = SignMockData.GetSignInDetails();
            mock.Setup(m => m.LoginAsync(signins[1])).ReturnsAsync(token);
            var sut = new AuthController(mock.Object);

            // Act
            var result = await sut.LogIn(signins[1]);

            // Assert
            Assert.IsType<UnauthorizedObjectResult>(result as UnauthorizedObjectResult);
        }
    }
}
