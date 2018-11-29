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
         
            //return to view a list of links that was based on the user logged in
            IEnumerable<Link> Li = getLinks();
            return View(Li);
            
        }

        public IEnumerable<Link> getLinks()
        {
            using (portaldatabaseEntities db = new portaldatabaseEntities())
            {
                if (Session["RoleID"] == null)
                {
                    return db.Links.ToList().Where(x => x.RoleID == 3 && x.StatusID == 1); //return all global links that are active
                }
                else
                {
                    int User_RoleID = (int)(Session["RoleID"]);
                    //return a list of links where roleID from db == roleID of the logged user or global and active
                    return db.Links.ToList().Where(x => (x.RoleID == User_RoleID || x.RoleID == 3) && x.StatusID == 1);
                } 
            }
        }

    }
}