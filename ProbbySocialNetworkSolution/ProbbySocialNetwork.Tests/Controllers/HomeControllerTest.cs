using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProbbySocialNetwork;
using ProbbySocialNetwork.Controllers;

namespace ProbbySocialNetwork.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void About()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.About() as ViewResult;

            // Assert
            Assert.AreEqual("Your application description page.", result.ViewBag.Message);
        }

        /*[TestMethod]
        public void Contact()
        {
            // Arrange
            //HomeController controller = new HomeController();

            // Act
            //ViewResult result = controller.Contact() as ViewResult;

            // Assert
<<<<<<< HEAD
           // Assert.IsNotNull(result);
        }
=======
            Assert.IsNotNull(result);
        }*/
>>>>>>> 96b8fa27c4e495574f147c348f57b36c26c1f71a
    }
}
