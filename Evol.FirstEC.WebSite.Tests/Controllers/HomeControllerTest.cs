﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Moq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Evol.First.WebSite;
using Evol.FirstEC.WebSite.Controllers;

namespace Evol.First.WebSite.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        private TestContext testContext;
        private HttpContextBase HttpContext { get; set; }

        private ControllerContext ControllerContext { get; set; }

        [TestInitialize()]
        public void Init()
        {
            ControllerContext = new ControllerContext();
            HttpContext = Mock.Of<HttpContextBase>();
            var MockHttpContext = new Mock<HttpContextBase>();
            MockHttpContext.Setup(c => c.Request.Cookies.Add(new HttpCookie("token", "323232323")));

        }

        [TestCleanup()]
        public void Cleanup()
        {

        }

        

        [TestMethod]
        public void Index()
        {
          
        }

        [TestMethod]
        public void About()
        {
       
        }

        [TestMethod]
        public void Contact()
        {
            //// Arrange
            //HomeController controller = new HomeController();

            //// Act
            //ViewResult result = controller.Contact() as ViewResult;

            //// Assert
            //Assert.IsNotNull(result);
        }
    }
}
