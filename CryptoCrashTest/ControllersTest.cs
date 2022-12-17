using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CryptoCrash;
using CryptoCrash.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace CryptoCrashTest
{
    [TestClass]
    public class NewsControllerTest
    {
        [TestMethod]
        public void TestNewsControllerView()
        {
            var controller = new NewsController();
            var result = controller.Details(2) as ViewResult;
            Assert.AreEqual("Details", result.ViewName);

        }


        [TestMethod]
        public void TestHomeControllerView()
        {
            var controller = new HomeController();
            var result = controller.Home(2) as ViewResult;
            Assert.AreEqual("HomeList", result.ViewName);

        }

        [TestMethod]
        public void TestNewsControllerListView()
        {
            var controller = new NewsController();
            var result = controller.Details(2) as ViewResult;
            Assert.AreEqual("Details", result.ListView);

        }


        [TestMethod]
        public async Task Index_ReturnsAViewResult_WithAListNews()
        {
            // Arrange
            var mockRepo = new Mock<HomeController>();
            mockRepo.Setup(repo => repo.ListAsync())
                .ReturnsAsync(GetReadLaterList());
            var controller = new HomeController(mockRepo.Object);

            // Act
            var result = await controller.Index();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<HomeController>>(
                viewResult.ViewData.Model);
            Assert.Equal(2, model.Count());
        }
    }
}

