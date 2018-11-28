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

        [HttpPost]
        public ActionResult EditUsername(UserProfile userModel)
        {
            using (portaldatabaseEntities db = new portaldatabaseEntities())
            {
                //Set Username
                string oldUsername = Session["Name"].ToString();
                string newUsername = userModel.newUsername;
                string password = userModel.oldPassword;
                var userDetails = db.Accounts.Where(x => x.Username == oldUsername && x.Password == password).FirstOrDefault();

                if(userDetails == null) //wrong username/password
                {
                    return RedirectToAction("Index", "EditProfile");
                }
                    
                else
                {
                    db.Database.ExecuteSqlCommand("update dbo.Accounts set Username = '" + newUsername + "' where Username = '" + oldUsername + "'");
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
                //Set Password
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
                    int AccountID = (int)Session["AccountID"];
                    Session.Abandon();
                    return RedirectToAction("Index", "EditProfile");
                }

            }
        }
    }
}