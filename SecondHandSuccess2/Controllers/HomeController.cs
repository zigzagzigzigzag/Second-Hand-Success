using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SecondHandSuccess2.Models;

namespace SecondHandSuccess2.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            Session.Contents.RemoveAll();
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

        Model model = new Model();

        public ActionResult UserHomePage()
        {
            if ((String)Session["UserId"] != null)
            {
                ViewBag.Listings = model.Listings;
                return View();
            }
            else
            {
                return RedirectToAction("LogIn", "Home");
            }
        }

        public ActionResult LecturerHomepage()
        {
            if ((String)Session["UserId"] != null)
            {
                ViewBag.Listings = model.Listings;
                return View();
            }
            else
            {
                return RedirectToAction("LogIn", "Home");
            }
        }

        [HttpPost]
        public ActionResult LogOn()
        {

            String uName = Request.Form["PersonUserName"];
            String uPassword = Request.Form["PersonPassword"];
            DbSet<PERSON> c = model.People.Where(p => p.PersonUserName == uName);
            Session["UserId"] = "BLEP BOI";
            return RedirectToAction("UserHomePage", "Home");
        }
        // public ActionResult About(){ViewBag.Message = "Your application description page.";return View();}

        // public ActionResult Contact(){ViewBag.Message = "Your contact page.";return View();}
    }
}