using Software_Engineering_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Software_Engineering_Project.Controllers
{
    public class Links_ManagementController : Controller
    {
        // GET: Links_Management
        public ActionResult Index()
        {
            IEnumerable<LinksData> Li = getLinksData();
            return View(Li);

        }

        public IEnumerable<LinksData> getLinksData() //function to get links and its corresponding role and status
        {
            using (portaldatabaseEntities db = new portaldatabaseEntities())
            {
                return db.Database.SqlQuery<LinksData>("select * from dbo.Links as links, dbo.Roles as roles, dbo.Status as status " +
                    "where links.RoleID = roles.RoleID and links.StatusID = status.StatusID").ToList();
            }
        }
    }
}