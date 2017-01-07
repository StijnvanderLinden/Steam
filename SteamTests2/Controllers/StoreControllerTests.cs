using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;
using Steam.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Steam.Controllers.Tests
{
    [TestClass()]
    public class StoreControllerTests
    {
        [TestMethod()]
        public void DetailsTest()
        {
            var controller = new StoreController();
            var result = controller.Details(2) as ViewResult;
            Assert.AreEqual("Details", result.ViewName);
        }
    }
}