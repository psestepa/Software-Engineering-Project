using Software_Engineering_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace Software_Engineering_Project.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Login()
        { 
            return View();
        }

        [HttpPost] //important for logging in
        public ActionResult Authorize(Software_Engineering_Project.Models.Account userModel)
        {
            using (portaldatabaseEntities db = new portaldatabaseEntities())
            {
                var userDetails = db.Accounts.Where(x => x.Username == userModel.Username && x.Password == userModel.Password).FirstOrDefault();
                var account_status = db.Accounts.Where(x => x.Username == userModel.Username && x.Password == userModel.Password && x.StatusID == 1).FirstOrDefault();

                if (userDetails != null) //Correct username/password
                {
                    if (account_status != null) //check if status is good
                    {
                        Session["Account ID"] = userDetails.AccountID;
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        userModel.LoginErrorMessage = "The Account is blocked/deactivated";
                        return View("Login", userModel);
                    }
                }
                else
                {
                    userModel.LoginErrorMessage = "Wrong Username/Password";
                    return View("Login", userModel);
                }

            }
        }


    }
}