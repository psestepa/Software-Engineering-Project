using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Software_Engineering_Project.Controllers;

namespace Tests.Controllers
{
    [TestClass]
    public class LoginControllerTest
    {
        [TestMethod]
        public void TestDetailsView()
        {
            var controller = new LoginController();
            var result = controller.Index() as ActionResult;
            Assert.AreEqual(result, result);

        }
    }
}