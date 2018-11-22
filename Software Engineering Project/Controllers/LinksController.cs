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
                //return to view a list of links that was based on the user logged in
                IEnumerable<Link> Li = getLinks();
                return View(Li);
            }
        }

        public IEnumerable<Link> getLinks()
        {
            //checks if RoleID in the database == roleID in the links
            int User_RoleID = Convert.ToInt32(Session["RoleID"]);
            using (portaldatabaseEntities db = new portaldatabaseEntities())
            {
                //return a list of links where roleID from db == roleID of the logged user
                return db.Links.ToList().Where(x => x.RoleID == User_RoleID && x.StatusID == 1);
            }
        }

    }
}