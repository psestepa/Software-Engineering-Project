using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Software_Engineering_Project.Controllers
{
    public class User_ManagementController : Controller
    {
        // GET: UserManagement
        public ActionResult Index()
        {
            if (Convert.ToInt32(Session["RoleID"]) != 0 &&Session["AccountID"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            else
                return View();
        }
    }
}