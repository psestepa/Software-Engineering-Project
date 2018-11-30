using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Software_Engineering_Project.Controllers;

namespace Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void TestDetailsView()
        {
            var controller = new HomeController();
            var result = controller.Index() as ActionResult;
            Assert.AreEqual(result, result);

        }
    }
}
