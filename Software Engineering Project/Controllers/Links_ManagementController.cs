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
            var tuple = new Tuple<IEnumerable<LinksData>,IEnumerable<Role>, IEnumerable<Status_Entity>>(Links,RoleNames,Status);
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

        public IEnumerable<Role> getRoleNames()
        {
            using (portaldatabaseEntities db = new portaldatabaseEntities())
            {
                return db.Database.SqlQuery<Role>("select * from dbo.Roles").ToList();
            }

        }

        public IEnumerable<Status_Entity> getStatus()
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
    
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString =
            "Data Source = den1.mssql8.gear.host;" +
            "Initial Catalog=portaldatabase;" +
            "User id=portaldatabase;" +
            "Password=Test1234!;";

            string commandText = "update dbo.links set RoleID = (select RoleID from dbo.Roles where" +
                " Roles.Role_Name = '"+Rolename+ "'), StatusID = (select StatusID from dbo.Status where Status.Status = '"+Statusname+"')" +
                " where links.URL = '" + URLname+"'";
            using (SqlCommand cmd = new SqlCommand(commandText, conn))
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            return RedirectToAction("Index", "Links_Management");
        }
    }
}