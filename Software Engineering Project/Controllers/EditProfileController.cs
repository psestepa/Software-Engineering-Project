using Software_Engineering_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Software_Engineering_Project.Controllers
{
    public class EditProfileController : Controller
    {
        // GET: EditProfile
        public ActionResult Index()
        {
 
            return View();
        }

        //checks if username already exists, if it does, you may not change your username
        public bool checkExistingUser(UserProfile userModel)
        {
            using (portaldatabaseEntities db = new portaldatabaseEntities())
            {
                var User = db.Accounts.Where(x => x.Username == userModel.newUsername).FirstOrDefault();
                //check if user exists in the database already
                if (User == null) //not in db
                {
                    return false;
                }
                else
                    return true; //return true if user is in db
            }

        }

        [HttpPost]
        public ActionResult EditUsername(UserProfile userModel)
        {
            using (portaldatabaseEntities db = new portaldatabaseEntities())
            {
                //Set Username and password from the view
                string oldUsername = Session["Name"].ToString();
                string newUsername = userModel.newUsername;
                string password = userModel.oldPassword;
                var userDetails = db.Accounts.Where(x => x.Username == oldUsername && x.Password == password).FirstOrDefault();

                if(userDetails == null || checkExistingUser(userModel) == true) //wrong username/password or username already exists
                {
                    return RedirectToAction("Index", "EditProfile");
                }
                    
                else
                {
                    db.Database.ExecuteSqlCommand("update dbo.Accounts set Username = '" + newUsername + "' where Username = '" + oldUsername + "'");
                    //log out user after the change
                    int AccountID = (int)Session["AccountID"];
                    Session.Abandon();
                    return RedirectToAction("Index", "EditProfile");
                }
               
            }
        }

        [HttpPost]
        public ActionResult EditPassword(UserProfile userModel)
        {
            using (portaldatabaseEntities db = new portaldatabaseEntities())
            {
                //Set Username Password
                string oldUsername = Session["Name"].ToString();
                string newPassword = userModel.newPassword;
                string oldPassword = userModel.oldPassword;
                var userDetails = db.Accounts.Where(x => x.Username == oldUsername && x.Password == oldPassword).FirstOrDefault();

                if (userDetails == null) //wrong username/password 
                {
                    return RedirectToAction("Index", "EditProfile");
                }

                else
                {
                    db.Database.ExecuteSqlCommand("update dbo.Accounts set Password = '" + newPassword + "' where Username = '" + oldUsername + "'");
                    //logout
                    int AccountID = (int)Session["AccountID"];
                    Session.Abandon();
                    return RedirectToAction("Index", "EditProfile");
                }

            }
        }
    }
}