using Software_Engineering_Project.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
            IEnumerable<Role> RoleNames = getRoleNames();
            IEnumerable<Status_Entity> Status = getStatus();
            IEnumerable<LinksData> Links = getLinksData();
            //we're returning 3 models to the view
            var tuple = new Tuple<IEnumerable<LinksData>, IEnumerable<Role>, IEnumerable<Status_Entity>>(Links, RoleNames, Status);
            return View(tuple);
        }

        public IEnumerable<LinksData> getLinksData() //function to get links and its corresponding role and status
        {
            using (portaldatabaseEntities db = new portaldatabaseEntities())
            {
                return db.Database.SqlQuery<LinksData>("select * from dbo.Links as links, dbo.Roles as roles, dbo.Status as status " +
                    "where links.RoleID = roles.RoleID and links.StatusID = status.StatusID").ToList();
            }
        }

        public IEnumerable<Role> getRoleNames()//function to get all the roles from the db to a list
        {
            using (portaldatabaseEntities db = new portaldatabaseEntities())
            {
                return db.Database.SqlQuery<Role>("select * from dbo.Roles").ToList();
            }

        }

        public IEnumerable<Status_Entity> getStatus()//function to get all the status from the db to list
        {
            using (portaldatabaseEntities db = new portaldatabaseEntities())
            {
                return db.Database.SqlQuery<Status_Entity>("select * from dbo.Status").ToList();
            }

        }

        [HttpPost]
        public ActionResult EditRole(LinksData LinkModel, Role RoleModel, Status_Entity StatusModel)
        {
            string URLname = LinkModel.URL;
            string Rolename = RoleModel.Role_Name;
            string Statusname = StatusModel.Status;
            //All fields have to be filled out to edit role
            if (URLname == null || Rolename == null || Statusname == null)
            {
                return RedirectToAction("Index", "Links_Management");
            }
            else
            {
                //updating the role for the link
                using (portaldatabaseEntities db = new portaldatabaseEntities())
                {
                    db.Database.ExecuteSqlCommand("update dbo.links set RoleID = (select RoleID from dbo.Roles where" +
                    " Roles.Role_Name = '" + Rolename + "'), StatusID = (select StatusID from dbo.Status where Status.Status = '" + Statusname + "')" +
                    " where links.URL = '" + URLname + "'");
                }
                
                    return RedirectToAction("Index", "Links_Management");
            }
        }

        [HttpPost]
        public ActionResult Register(LinksData linkModel)
        {
            using (portaldatabaseEntities db = new portaldatabaseEntities())
            {
                //Set the URL name
                Link newLink = new Link();
                newLink.URL = linkModel.URL;
                //Check if link already exists in server
                if (checkExistingLink(linkModel) == false && newLink.URL != null) //check if not in the db and the URL is not null
                {
                    //Call function to add to the database
                    AddLink(newLink);
                    return RedirectToAction("Index", "Links_Management");
                }
                else
                {
                    return RedirectToAction("Index", "Links_Management");
                }
            }
        }

        public void AddLink(Link newLink)
        {
            //create new database object
            using (portaldatabaseEntities db = new portaldatabaseEntities())
            {
                //add new link to database
                db.Links.Add(newLink);
                //save changes to database
                db.SaveChanges();
            }
        }

        public bool checkExistingLink(LinksData userModel)
        {
            using (portaldatabaseEntities db = new portaldatabaseEntities())
            {
                var URL = db.Links.Where(x => x.URL == userModel.URL).FirstOrDefault();
                //check if URL exists in the database already
                if (URL == null) //not in db
                {
                    return false;
                }
                else
                    return true; //return true if URL is in db
            }

        }

        [HttpPost]
        public ActionResult Remove(LinksData linkModel)
        {
            string URL = linkModel.URL;
            using (portaldatabaseEntities db = new portaldatabaseEntities())
            {
                //sql query to delete link from db
                db.Database.ExecuteSqlCommand("Delete from dbo.links where URL = '" + URL + "'");
                return RedirectToAction("Index", "Links_Management");
            }
        }
    }
}