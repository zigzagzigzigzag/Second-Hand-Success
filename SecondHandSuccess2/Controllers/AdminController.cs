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
            if (Session["User"] != null)
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

        public ActionResult AddModule()
        {         
            List<PERSON> people = new List<PERSON>();
            foreach (var user in model.People)
            {
                if (user.PersonType.Equals("Lecturer"))
                {
                    people.Add(user);
                }
            }
            ViewBag.lecturers = people;
            return View();
        }

        [HttpPost]
        public ActionResult addModule()
        {
            String moduleName = Request.Form["moduleName"];
            String moduleCode = Request.Form["moduleCode"];
            String lecturer = Request.Form["personID"];

            bool exists = false;
            foreach (Module module in model.Modules)
            {
                if (module.moduleCode.Equals(moduleCode))
                {
                    exists = true;
                }
            }

            if (!exists)
            {
               
          
                if (ModelState.IsValid)
                {

                    Module module = new Module();
                    module.moduleCode = moduleCode;
                    module.moduleName = moduleName;
                    module.moduleLecturer = lecturer;
                
                    model.Modules.Add(module);
                    model.SaveChanges();
                }
            }
                return RedirectToAction("AdminHome", "Admin");
        }

        [HttpPost]
        public ActionResult add()
        {
            return RedirectToAction("AddModule", "Admin");
        }

        public ActionResult getLecturers()
        {
            List<PERSON> people = new List<PERSON>();         
            foreach (var user in model.People)
            {
                people.Add(user);
            //    if (user.PersonType.Equals("Lecturer"))
            //    {
            //        people.Add(user);
            //    }
            }

            ViewBag.lecturers = people;
            return View();
        }


    }
}