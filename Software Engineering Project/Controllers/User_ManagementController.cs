using Software_Engineering_Project.Models;
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
            IEnumerable<UsersData> Li = getUsersData();
            return View(Li);
        }

        public IEnumerable<UsersData> getUsersData() //function to get links and its corresponding role and status
        {
            using (portaldatabaseEntities db = new portaldatabaseEntities())
            {
                return db.Database.SqlQuery<UsersData>("select * from dbo.Accounts as A, dbo.Roles as B, dbo.Status as C " +
                    "where A.RoleID = B.RoleID and A.StatusID = C.StatusID").ToList();
            }
        }
    }
}
