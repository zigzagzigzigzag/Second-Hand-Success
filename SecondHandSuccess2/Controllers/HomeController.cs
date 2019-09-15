using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SecondHandSuccess2.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult LogIn()
        {
            //if (objUserLogin.PersonUserName == "debugonweb" && objUserLogin.PersonPassword == "debugonweb")
            //    return RedirectToAction("WelcomePage");
            //else
            //{
            //   //objUserLogin.Message = "Invalid UserName/Password";
            //    return View(LogIn);
            //}
            return View();
        }

       // public ActionResult About(){ViewBag.Message = "Your application description page.";return View();}

       // public ActionResult Contact(){ViewBag.Message = "Your contact page.";return View();}
    }
}