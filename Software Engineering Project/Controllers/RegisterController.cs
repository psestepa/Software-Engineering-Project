using Software_Engineering_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Software_Engineering_Project.Controllers
{
    public class RegisterController : Controller
    {
        // GET: Register
        public ActionResult Index()
        {
            return View();
        }


        [HttpPost] 
        public ActionResult Register(Account userModel)
        {
            using (portaldatabaseEntities db = new portaldatabaseEntities())
            {
                //Set the Username and password
                Account newUser = new Account();
                newUser.Username = userModel.Username;
                newUser.Password = userModel.Password;
                //Check if user already exists in server
                if(checkExistingUser(userModel)==false && newUser.Username != null && newUser.Password!= null)
                {
                    //Call function to add to the database
                    AddUser(newUser);
                    userModel.RegistrationSuccessMessage = "The Account is now registered!";
                    return View("Index", userModel);
                }
                else
                {
                    userModel.RegistrationSuccessMessage = "The Account already exists!!!";
                    return View("Index", userModel);
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

        public bool checkExistingUser(Account userModel)
        {
            using (portaldatabaseEntities db = new portaldatabaseEntities())
            {
                var User = db.Accounts.Where(x => x.Username == userModel.Username).FirstOrDefault();
                //check if user exists in the database already
                if (User == null) //not in db
                {
                    return false;
                }
                else
                    return true; //return true if user is in db
            }
            
        }
    }
}