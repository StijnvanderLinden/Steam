using Microsoft.VisualStudio.TestTools.UnitTesting;
using Steam.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Steam.Controllers.Tests
{
    [TestClass()]
    public class StoreControllerTests
    {
        [TestMethod()]
        public void DetailsTest()
        {
            var controller = new StoreController();
            var result = controller.Details(1) as ViewResult;
            Assert.AreEqual("", result.ViewName);
        }
    }
}