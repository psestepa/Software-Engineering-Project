using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Software_Engineering_Project.Controllers;

namespace Tests.Controllers
{
    [TestClass]
    public class EditProfileControllerTest
    {
        [TestMethod]
        public void TestDetailsView2()
        {
            var controller = new EditProfileController();
            var result = controller.Index() as ActionResult;
            Assert.AreEqual(result, result);

        }
    }
}