﻿using System;
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
            return View();
        }

        Model model = new Model();

  
        public ActionResult LecturerHomePage()
        {
            if (Session["User"] != null)
            {
                ViewBag.Prescribed = model.PRESCRIBEDs;
                return View();
            }
            else
            {
                return RedirectToAction("LogIn", "Home");
            }
        }

        public ActionResult EditListing()
        {
            return View();
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
    }
}