using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Software_Engineering_Project.Controllers
{
    public class LinksController : Controller
    {
        // GET: Links
        public ActionResult Index()
        {
            if (Session["AccountID"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            else
                return View();
        }
    }
}