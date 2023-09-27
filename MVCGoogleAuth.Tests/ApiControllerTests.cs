using MVCGoogleAuth.Controllers;
using MVCGoogleAuth.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;
using MVCGoogleAuth.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using Xunit.Sdk;

namespace MVCGoogleAuth.Tests
{
    public class ApiControllerTests
    {
        [Fact]
        public void GetNews_ReturnsOk()
        {
            // Arrange
            var mockNewsService = new Mock<INewsService>();
            mockNewsService.Setup(service => service.GetNews()).Returns(new List<News>());

            var controller = new ApiController(mockNewsService.Object);

            // Act
            var result = controller.GetNews();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(new List<News>(), okResult.Value);
        }

        [Fact]
        public void UpdateNews_ReturnsOk()
        {
            // Arrange
            var id = 2;
            var newsDto = new NewsDTO();
            var expectedNews = new News();

            var mockNewsService = new Mock<INewsService>();
            mockNewsService.Setup(service => service.UpdateNews(id, newsDto)).Returns(expectedNews);

            var controller = new ApiController(mockNewsService.Object);

            // Act
            var result = controller.UpdateNews(id, newsDto);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(expectedNews, okResult.Value);
        }

        [Fact]
        public void DeleteNews_ReturnsOk_WhenIdExists()
        {
            // Arrange
            var id = 2;
            var expectedReturn = true;

            var mockNewsService = new Mock<INewsService>();
            mockNewsService.Setup(service => service.DeleteNews(id)).Returns(expectedReturn);

            var controller = new ApiController(mockNewsService.Object);

            // Act
            var result = controller.DeleteNews(id);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(expectedReturn, okResult.Value);
        }

        [Fact]
        public void DeleteNews_ReturnsNotFound_WhenIdDoesNotExist()
        {
            // Arrange
            var id = 999;
            var expectedReturn = false;

            var mockNewsService = new Mock<INewsService>();
            mockNewsService.Setup(service => service.DeleteNews(id)).Returns(expectedReturn);

            var controller = new ApiController(mockNewsService.Object);

            // Act
            var result = controller.DeleteNews(id);

            // Assert
            var notFoundResult = Assert.IsType<NotFoundObjectResult>(result);
            Assert.Equal("News with the given ID was not found.", notFoundResult.Value);
        }

    }
}