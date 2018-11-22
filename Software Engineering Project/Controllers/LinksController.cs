using Software_Engineering_Project.Models;
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
            {

                IEnumerable<Link> Li = getLinks();
                ViewData["Links"] = Li;
                return View(Li);
            }
        }

        public IEnumerable<Link> getLinks()
        {
            int User_RoleID = Convert.ToInt32(Session["RoleID"]);
            using (portaldatabaseEntities db = new portaldatabaseEntities())
            {
                return db.Links.ToList().Where(x => x.RoleID == User_RoleID);
            }
        }

    }
}