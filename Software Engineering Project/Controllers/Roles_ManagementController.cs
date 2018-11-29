using Software_Engineering_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace Software_Engineering_Project.Controllers
{
    public class Roles_ManagementController : Controller
    {
        // GET: Roles_Management
        public ActionResult Index()
        {

            //return to view a list of links that was based on the user logged in
            IEnumerable<Role> Li = getRoles();
            return View(Li);

        }

        public IEnumerable<Role> getRoles()
        {
            using (portaldatabaseEntities db = new portaldatabaseEntities())
            {
                return db.Database.SqlQuery<Role>("select * from dbo.Roles").ToList();
            }

        }

        [HttpPost]
        public ActionResult Register(Role roleModel)
        {
            using (portaldatabaseEntities db = new portaldatabaseEntities())
            {
                //Set the Role name
                Role newRole = new Role();
                newRole.Role_Name = roleModel.Role_Name;
                newRole.Role_description = roleModel.Role_Name;
                //Check if Role already exists in server
                if (checkExistingRole(roleModel) == false && newRole.Role_Name != null)
                {
                    //Call function to add to the database
                    AddRole(newRole);
                    return RedirectToAction("Index", "Roles_Management");
                }
                else
                {
                    return RedirectToAction("Index", "Roles_Management");
                }
            }
        }

        public void AddRole(Role newRole)
        {
            //create new database object
            using (portaldatabaseEntities db = new portaldatabaseEntities())
            {
                //add new role to database
                db.Roles.Add(newRole);
                //save changes to database
                db.SaveChanges();
            }
        }

        public bool checkExistingRole(Role roleModel)
        {
            using (portaldatabaseEntities db = new portaldatabaseEntities())
            {
                var RoleName = db.Roles.Where(x => x.Role_Name == roleModel.Role_Name).FirstOrDefault();
                //check if role exists in the database already
                if (RoleName == null) //not in db
                {
                    return false;
                }
                else
                    return true; //return true if URL is in db
            }
        }

        [HttpPost]
        public ActionResult Remove(Role roleModel)
        {
            string RoleName = roleModel.Role_Name;
            bool checkRoles = checkRoleInLinksAndUsers(roleModel); 
            if(checkRoles == false) //role is not in db and not a default role
            {
                using (portaldatabaseEntities db = new portaldatabaseEntities())
                {
                    //sql query to delete role from db
                    db.Database.ExecuteSqlCommand("Delete from dbo.Roles where Role_Name = '" + RoleName + "'");
                    return RedirectToAction("Index", "Roles_management");
                }
            }
            else
                return RedirectToAction("Index", "Roles_Management");

        }

        //checks if a role is currently assigned to a user or a link
        public bool checkRoleInLinksAndUsers(Role roleModel)
        {
            using (portaldatabaseEntities db = new portaldatabaseEntities())
            {
                string rolename = roleModel.Role_Name;
                var result = db.Database.SqlQuery<Role>("select * from dbo.links,dbo.Roles,dbo.Accounts where (links.RoleID = Roles.RoleID " +
                    "or Accounts.RoleID=Roles.RoleID) and Roles.Role_Name = '" + rolename + "'").ToList();
                //check if role is assigned to a user 
                if (result.Count()==0 && rolename != "Global" && rolename != "Company Client" && rolename != "Portal Administrator" && rolename != "System Administrator") //not in db
                {
                    return false;
                }
                else
                    return true; //return true if URL is in db
            }
        }
    }
}
