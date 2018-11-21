﻿using Software_Engineering_Project.Models;
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
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

        public ActionResult Login()
        { 
            return RedirectToAction("Index","Login");
        }

        public ActionResult User_Management()
        {
            return RedirectToAction("Index", "User_Management");
        }

    }
}