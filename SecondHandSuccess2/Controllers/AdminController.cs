using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using SecondHandSuccess2.Models;
using System.Data.Entity;

namespace SecondHandSuccess2.Controllers
{
    public class AdminController : Controller
    {
       
        Model model = new Model();

        public ActionResult AdminHome()
        {
            if (User.Identity.Name != "")
            {
                ViewBag.Modules = model.Modules;
                ViewBag.People = model.People;
                return View();
            }
            else
            {
                return RedirectToAction("LogIn", "Home");
            }
           
        }


    }
}