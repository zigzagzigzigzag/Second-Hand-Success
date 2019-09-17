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
            if (Session["User"] != null)
            {
                ViewBag.Listings = model.Listings;
                return View();
            }
            else
            {
                return RedirectToAction("LogIn", "Home");
            }
        }
        public ActionResult LecturerHomePage()
        {
            if (Session["User"] != null)
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
            foreach (PERSON curP in model.People) {
                if (curP.PersonUserName == uName)
            { if (curP.PersonPassword == uPassword) {
                        Session["User"] = curP;
                        if (curP.PersonType.Equals("Person"))
                        {
                            return RedirectToAction("UserHomePage", "Home");
                        }else if (curP.PersonType.Equals("Lecturer"))
                        {
                            return RedirectToAction("LecturerHomePage", "Home");
                        }
                        else if (curP.PersonType.Equals("Admin"))
                        {
                            return RedirectToAction("AdminHome", "Admin");
                        }
                    }
                }
            }
            return null;
        }
        // public ActionResult About(){ViewBag.Message = "Your application description page.";return View();}

        // public ActionResult Contact(){ViewBag.Message = "Your contact page.";return View();}
    }
}