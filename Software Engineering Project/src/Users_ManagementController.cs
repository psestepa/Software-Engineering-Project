using Software_Engineering_Project.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Software_Engineering_Project.Controllers
{
    public class Users_ManagementController : Controller
    {
        // GET: Users_Management
        public ActionResult Index()
        {
            IEnumerable<Role> RoleNames = getRoleNames();
            IEnumerable<Status_Entity> Status = getStatus();
            IEnumerable<UsersData> Users = getUsersData();
            //We're using a tuple to return 3 models to the view
            var tuple = new Tuple<IEnumerable<UsersData>, IEnumerable<Role>, IEnumerable<Status_Entity>>(Users, RoleNames, Status);
            return View(tuple);
        }

        public IEnumerable<UsersData> getUsersData() //function to get Users and its corresponding role and status
        {
            using (portaldatabaseEntities db = new portaldatabaseEntities())
            {
                return db.Database.SqlQuery<UsersData>("select * from dbo.Accounts as users, dbo.Roles as roles, dbo.Status as status " +
                    "where users.RoleID = roles.RoleID and users.StatusID = status.StatusID").ToList();
            }
        }

        public IEnumerable<Role> getRoleNames() //function to get all roles from db
        {
            using (portaldatabaseEntities db = new portaldatabaseEntities())
            {
                return db.Database.SqlQuery<Role>("select * from dbo.Roles").ToList();
            }

        }

        public IEnumerable<Status_Entity> getStatus() //function to get all status from db
        {
            using (portaldatabaseEntities db = new portaldatabaseEntities())
            {
                return db.Database.SqlQuery<Status_Entity>("select * from dbo.Status").ToList();
            }

        }

        [HttpPost]
        public ActionResult EditUser(UsersData UserModel, Role RoleModel, Status_Entity StatusModel)
        {
            //Set username, rolename, status = from the view
            string Username = UserModel.Username;
            string Rolename = RoleModel.Role_Name;
            string Statusname = StatusModel.Status;
            //all fields have to be changed to edit a user
            if (Username == null || Rolename == null || Statusname == null)
            {
                return RedirectToAction("Index", "Users_Management");
            }
            else
            {
                //update the role and status of the user
                using (portaldatabaseEntities db = new portaldatabaseEntities())
                {
                    db.Database.ExecuteSqlCommand("update dbo.Accounts set RoleID = (select RoleID from dbo.Roles where" +
                    " Roles.Role_Name = '" + Rolename + "'), StatusID = (select StatusID from dbo.Status where Status.Status = '" + Statusname + "')" +
                    " where Accounts.Username = '" + Username + "'");
                }

                return RedirectToAction("Index", "Users_Management");
            }
        }

        [HttpPost]
        public ActionResult Register(UsersData userModel)
        {
            using (portaldatabaseEntities db = new portaldatabaseEntities())
            {
                //Set the URL name
                Account newUser = new Account();
                newUser.Username = userModel.Username;
                newUser.Password = "password"; //default password, can't make a trigger for this b/c password is not nullable
                //Check if user already exists in server
                if (checkExistingUser(userModel) == false && newUser.Username != null)
                {
                    //Call function to add to the database
                    AddUser(newUser);
                    return RedirectToAction("Index", "Users_Management");
                }
                else
                {
                    return RedirectToAction("Index", "Users_Management");
                }
            }
        }

        public void AddUser(Account newUser)
        {
            //create new database object
            using (portaldatabaseEntities db = new portaldatabaseEntities())
            {
                //add new user to database
                db.Accounts.Add(newUser);
                //save changes to database
                db.SaveChanges();
            }
        }

        public bool checkExistingUser(UsersData userModel)
        {
            using (portaldatabaseEntities db = new portaldatabaseEntities())
            {
                var Username = db.Accounts.Where(x => x.Username == userModel.Username).FirstOrDefault();
                //check if Username exists in the database already
                if (Username == null) //not in db
                {
                    return false;
                }
                else
                    return true; //return true if Username is in db
            }

        }

        [HttpPost]
        public ActionResult Remove(UsersData userModel)
        {
            string Username = userModel.Username;
            using (portaldatabaseEntities db = new portaldatabaseEntities())
            {
                //sql query to delete user from db
                db.Database.ExecuteSqlCommand("Delete from dbo.Accounts where Username = '" + Username + "'");
                return RedirectToAction("Index", "Users_Management");
            }
        }
    }
}