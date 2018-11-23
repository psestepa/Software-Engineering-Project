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


        [HttpPost] //important for logging in
        public ActionResult Register(Software_Engineering_Project.Models.Account userModel)
        {
            using (portaldatabaseEntities db = new portaldatabaseEntities())
            {
                //Set the Username and password
                Account newUser = new Account();
                newUser.Username = userModel.Username;
                newUser.Password = userModel.Password;
                //Call function to add to the database
                AddUser(newUser);
                userModel.RegistrationSuccessMessage= "The Account is now registered!";
                return View("Index", userModel);

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
    }
}